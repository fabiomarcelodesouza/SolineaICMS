#region Usings

using System;
using System.Web;
using SolineaICMS.BLL;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class ImportarSaldoEstoque : PageBase
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Acao"].Equals("CargaInicial"))
            {
                ((SiteMaster)this.Master).Perfil = "M";
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["Acao"].Equals("CargaInicial"))
                {
                    ((SiteMaster)this.Master).Legend = "Carga Inicial";
                    this.Page.Title = "Solinea ICMS - Carga Inicial";
                }
                else
                {
                    ((SiteMaster)this.Master).Legend = "Saldo Final de Estoque";
                    this.Page.Title = "Solinea ICMS - Saldo Final de Estoque";
                }

                if (fupFile.HasFile)
                {
                    fupFile.ClearAllFilesFromPersistedStore();
                }
            }
            else
            {
                ucMensagem.HideMessage();
            }
        }

        protected void btnImportarArquivo_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = null;
            Boolean fileOK = false;
            String fileExtension = null;
            UtilEnums.FileType FileType = UtilEnums.FileType.xls;
            String path = Server.MapPath("~/ArquivosMovimentacaoEstoque/");
            DateTime now = DateTime.Now;
            bllImportarSaldoEstoque bllImportarSaldoEstoque = new bllImportarSaldoEstoque();

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
                    string newPath = System.IO.Path.Combine(activeDir, "ArquivosSaldoEstoque");

                    // Create the subfolder
                    System.IO.Directory.CreateDirectory(newPath);

                    string fileName = "SaldoEstoque_" + now.Hour.ToString().PadLeft(2, '0') + "_" + now.Minute.ToString().PadLeft(2, '0') + "_" + now.Second.ToString().PadLeft(2, '0') + "_" + now.Day.ToString().PadLeft(2, '0') + "_" + now.Month.ToString().PadLeft(2, '0') + "_" + now.Year.ToString() + fileExtension;

                    file.SaveAs(newPath + "\\" + fileName);

                    bllImportarSaldoEstoque.ProcessarSaldoEstoque(FileType, newPath + "\\" + fileName);

                    ucMensagem.MessageType = UtilEnums.MessageType.Success;
                    ucMensagem.Mensagem = String.Format("Arquivo importado com sucesso, clique <a href='InconsistenciasEstoque.aspx?Acao={0}'>AQUI</a> para visualizar as inconsistências de estoque.", Request.QueryString["Acao"]);
                    ucMensagem.ShowMessage();
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
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }
        }

        protected void ScriptManager1_AsyncPostBackError(object sender, System.Web.UI.AsyncPostBackErrorEventArgs e)
        {
            ScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message;
        }

        #endregion
    }
}

#endregion