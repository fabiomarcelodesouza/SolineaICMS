using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SolineaICMS.Util;
using SolineaICMS.BLL;
using SolineaICMS.VO;
using System.Threading;
using System.Reflection;

namespace SolineaICMS.WindowsUI
{
    public partial class frmImportarMovimentoEstoque : Form
    {
        #region Atributos e Propriedades

        /// <summary>
        /// Usuario
        /// </summary>
        public voUsuario Usuario { get; set; }

        /// <summary>
        /// Inverter a progressão da barra
        /// </summary>
        private bool ProgredirBarraAoContrario { get; set; }

        /// <summary>
        /// Propriedade utilizada para controlar se a aplicação está importando o arquivo ou se a importação já foi finalizada
        /// </summary>
        private bool Importando { get; set; }

        /// <summary>
        /// Tipo de arquivo
        /// </summary>
        private UtilEnums.FileType FileType;

        /// <summary>
        /// Business de Importar Movimento de Estoque
        /// </summary>
        bllImportarMovimentoEstoque bllImportarMovimentoEstoque;

        /// <summary>
        /// Delegate utilizado para atualizar a barra de progresso
        /// </summary>        
        delegate void SetControlValueCallback(Control oControl, int valorAtual, System.Windows.Forms.RightToLeft rightToLeft, bool rightToLeftLayout);

        #endregion

        #region Construtores

        public frmImportarMovimentoEstoque()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            this.ofdArquivo.ShowDialog();
        }

        private void btnImportarArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                this.bllImportarMovimentoEstoque = new bllImportarMovimentoEstoque(FileType, ofdArquivo.FileName, this.Usuario);
                this.bllImportarMovimentoEstoque.ImportarMovimentoEstoque();
                this.btnSelecionarArquivo.Enabled = false;
                this.btnImportarArquivo.Enabled = false;
                this.btnExcluirGeral.Enabled = false;
                this.Importando = true;

                string dataInicial = this.bllImportarMovimentoEstoque.SelectPeriodoCoincidente();

                //Se o período já foi importado, não deixa importar
                if (!string.IsNullOrEmpty(dataInicial))
                {
                    MessageBox.Show(string.Format("Os dados que estão sendo importados coincidem com algum período já importado."));
                    this.Close();
                }
                else
                {
                    //Dispara a thread de atualização da barra de progresso
                    this.backgroundWorkerProgressBar.RunWorkerAsync();

                    //Dispara a thread de importação
                    this.backgroundWorkerImportacao.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, UtilConstants.MSG_ERRO_IMPORTAR_ARQUIVO);
            }
        }

        private void btnExcluirGeral_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja excluir toda a movimentação da base de dados? Essa ação não pode ser revertida.", "Questionamento", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    new bllImportarMovimentoEstoque().DeleteGeral();

                    MessageBox.Show("Toda a movimentação foi exlcuida com sucesso.", "Sucesso");

                    this.Close();
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void ofdArquivo_FileOk(object sender, CancelEventArgs e)
        {
            Boolean fileOK = false;
            String fileExtension = null;
            fileExtension = System.IO.Path.GetExtension(ofdArquivo.FileName).ToLower();
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

            if (fileOK)
            {
                this.lblNomeArquivo.Text = ofdArquivo.FileName;
                this.lblNomeArquivo.Visible = true;

                this.btnImportarArquivo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Não é possível importar esse formato de arquivo, escolha um formato válido.", "Erro", MessageBoxButtons.OK);
            }
        }

        private void backgroundWorkerProgressBar_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (this.Importando)
            {
                SetControlPropertyValue(this.pbImportacao, this.pbImportacao.Value, this.pbImportacao.RightToLeft, this.pbImportacao.RightToLeftLayout);
                Thread.Sleep(50);
            }
        }      

        private void backgroundWorkerImportacao_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ProcessarMovimentoEstoque(false);
        }

        private void backgroundWorkerImportacao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Importando = false;

            if (e.Error == null)
            {
                MessageBox.Show("Arquivo importado com sucesso.", "Sucesso");
            }
            else
            {
                if (e.Error.GetType() == typeof(Util.CustomException))
                {
                    MessageBox.Show(((SolineaICMS.Util.CustomException)(e.Error)).CausaProvavel, e.Error.Message);
                }
                else
                {
                    MessageBox.Show(e.Error.Message, UtilConstants.MSG_ERRO_IMPORTAR_ARQUIVO);
                }
            }

            this.Close();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método utilizado para atualizar a barra de progresso
        /// </summary>       
        private void SetControlPropertyValue(Control oControl, int propValue, System.Windows.Forms.RightToLeft rightToLeft, bool rightToLeftLayout)
        {
            rightToLeft = System.Windows.Forms.RightToLeft.No;
            rightToLeftLayout = false;
            int incremento = 1;

            if (!this.ProgredirBarraAoContrario)
            {
                if (propValue < 100)
                {
                    rightToLeft = System.Windows.Forms.RightToLeft.No;
                    rightToLeftLayout = false;
                    propValue += incremento;
                }
                else
                {
                    rightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    rightToLeftLayout = true;
                    propValue -= incremento;

                    this.ProgredirBarraAoContrario = !(propValue == 0);
                }
            }
            else
            {
                if (propValue > 0)
                {
                    rightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    rightToLeftLayout = true;
                    propValue -= incremento;

                    this.ProgredirBarraAoContrario = !(propValue == 0);
                }
                else
                {
                    rightToLeft = System.Windows.Forms.RightToLeft.No;
                    rightToLeftLayout = false;
                    propValue += incremento;

                    this.ProgredirBarraAoContrario = !(propValue == 100);
                }
            }

            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propValue, rightToLeft, rightToLeftLayout });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == "VALUE")
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                    else if (p.Name.ToUpper() == "RIGHTTOLEFT")
                    {
                        p.SetValue(oControl, rightToLeft, null);
                    }
                    else if (p.Name.ToUpper() == "RIGHTTOLEFTLAYOUT")
                    {
                        p.SetValue(oControl, rightToLeftLayout, null);
                    }
                }
            }
        }

        private void ProcessarMovimentoEstoque(bool retornoConfirmacao)
        {
            this.bllImportarMovimentoEstoque = new bllImportarMovimentoEstoque(FileType, lblNomeArquivo.Text, this.Usuario);

            this.bllImportarMovimentoEstoque.ProcessarMovimentoEstoque(this.Usuario);
        }

        #endregion
    }
}
