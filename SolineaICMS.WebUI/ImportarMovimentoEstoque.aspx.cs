#region Usings

using System;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using SolineaICMS.BLL;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    /// <summary>
    /// Classe responsável pela importação do arquivo de movimento de estoque
    /// </summary>
    public partial class ImportarMovimentacaoEstoque : PageBase
    {
        #region Atributos e Propriedades

        private voUsuario voUsuario;
        private Button btnRespostaConfirmacao { get; set; }
        private UtilEnums.FileType FileType { get; set; }
        private string FilePath { get; set; }
        bllImportarMovimentoEstoque bllImportarMovimentoEstoque;

        #endregion

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);
            base.RetornoConfirmacaoPagina += new ConfirmacaoSim(btnRespostaConfirmacao_Click);
        }

        private void btnRespostaConfirmacao_Click(object sender, EventArgs e)
        {
            ProcessarMovimentoEstoque(true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Movimentação";

                if (fupFile.HasFile)
                {
                    fupFile.ClearAllFilesFromPersistedStore();
                }
            }
            else
            {
                ucMensagem.HideMessage();
            }

            this.btnRespostaConfirmacao = this.Master.FindControl("btnRespostaConfirmacao") as Button; //specify your button id 
            this.btnRespostaConfirmacao.Click += new System.EventHandler(btnRespostaConfirmacao_Click);
        }

        protected void btnImportarArquivo_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = null;
            Boolean fileOK = false;
            String fileExtension = null;
            String path = Server.MapPath("~/ArquivosMovimentacaoEstoque/");
            DateTime now = DateTime.Now;

            ucMensagem.HideMessage();

            try
            {
                if (fupFile.PostedFile != null)
                {
                    // Get a reference to PostedFile object
                    file = fupFile.PostedFile;

                    //Limpa o AsynFileUpload
                    fupFile.ClearAllFilesFromPersistedStore();

                    fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                    String[] allowedExtensions = { ".xls", ".xlsx", ".xml" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension.Equals(allowedExtensions[i]))
                        {
                            fileOK = true;

                            switch (fileExtension)
                            {
                                case ".xls":
                                    FileType = UtilEnums.FileType.xls;
                                    break;
                                case ".xlsx":
                                    FileType = UtilEnums.FileType.xlsx;
                                    break;
                                case ".xml":
                                    FileType = UtilEnums.FileType.xml;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                if (fileOK)
                {
                    // Specify a "currently active folder"
                    string activeDir = AppDomain.CurrentDomain.BaseDirectory;

                    //Create a new subfolder under the current active folder
                    string newPath = System.IO.Path.Combine(activeDir, "ArquivosMovimentoEstoque");

                    // Create the subfolder
                    System.IO.Directory.CreateDirectory(newPath);

                    string fileName = "MovimentoEstoque_" + now.Hour.ToString().PadLeft(2, '0') + "_" + now.Minute.ToString().PadLeft(2, '0') + "_" + now.Second.ToString().PadLeft(2, '0') + "_" + now.Day.ToString().PadLeft(2, '0') + "_" + now.Month.ToString().PadLeft(2, '0') + "_" + now.Year.ToString() + fileExtension;

                    FilePath = newPath + "\\" + fileName;

                    file.SaveAs(FilePath);

                    bllImportarMovimentoEstoque = new bllImportarMovimentoEstoque(FileType, FilePath, ((voUsuario)Session["Usuario"]));

                    bllImportarMovimentoEstoque.ImportarMovimentoEstoque();

                    string dataInicial = bllImportarMovimentoEstoque.SelectPeriodoCoincidente();

                    if (!string.IsNullOrEmpty(dataInicial))
                    {
                        //Session["DataInicial"] = dataInicial;
                        //base.GeraConfirmacao("Deseja sobrepor os dados?", string.Format("Os dados que estão sendo importados coincidem com algum período já importado. Se a importação continuar, a movimentação existente a partir de {0} será descartada. Deseja continuar?", dataInicial));

                        ucMensagem.MessageType = UtilEnums.MessageType.Error;
                        ucMensagem.Mensagem = "Os dados que estão sendo importados coincidem com algum período já importado.";
                        ucMensagem.ShowMessage();
                    }
                    else
                    {
                        this.ProcessarMovimentoEstoque(false);
                    }
                }
                else
                {
                    ucMensagem.MessageType = UtilEnums.MessageType.Error;
                    ucMensagem.Mensagem = "Não é possível importar esse formato de arquivo, escolha um formato válido.";
                    ucMensagem.ShowMessage();
                }
            }
            catch (CustomException ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;

                if (!string.IsNullOrEmpty(((SolineaICMS.Util.CustomException)(ex)).CausaProvavel))
                {
                    ucMensagem.Mensagem = ((SolineaICMS.Util.CustomException)(ex)).CausaProvavel;
                }
                else
                {
                    ucMensagem.Mensagem = ex.Message;
                }

                ucMensagem.ShowMessage();

                uppnlPrincipal.Update();
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }
        }

        public void ProcessarMovimentoEstoque(bool retornoConfirmacao)
        {
            this.voUsuario = new voUsuario((int)Session["CodigoUsuario"]);

            bllImportarMovimentoEstoque = new bllImportarMovimentoEstoque(FileType, FilePath, ((voUsuario)Session["Usuario"]));

            if (retornoConfirmacao)
            {
                bllImportarMovimentoEstoque.DeletePeriodoCoincidente(Session["DataInicial"].ToString());
            }

            bllImportarMovimentoEstoque.ProcessarMovimentoEstoque(this.voUsuario);

            ucMensagem.MessageType = UtilEnums.MessageType.Success;
            ucMensagem.Mensagem = "Arquivo importado com sucesso.";
            ucMensagem.ShowMessage();
        }

        protected void btnApagaTudo_Click(object sender, EventArgs e)
        {
            bllImportarMovimentoEstoque = new bllImportarMovimentoEstoque(this.FileType, this.FilePath, ((voUsuario)Session["Usuario"]));
            bllImportarMovimentoEstoque.DeleteGeral();
        }

        protected void ScriptManager1_AsyncPostBackError(object sender, System.Web.UI.AsyncPostBackErrorEventArgs e)
        {
            ScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message;
        }
    }
}

#endregion