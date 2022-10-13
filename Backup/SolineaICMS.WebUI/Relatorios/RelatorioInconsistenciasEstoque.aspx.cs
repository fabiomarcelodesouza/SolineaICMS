using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Reporting.WebForms;
using SolineaICMS.BLL.Relatorios;
using SolineaICMS.VO.Relatorios;
using SolineaICMS.BLL;
using SolineaICMS.VO;
using System.Web.UI.WebControls;

namespace SolineaICMS.WebUI.Relatorios
{
    public partial class RelatorioInconsistenciasEstoque : PageBase
    {
        bllRelatorioInconsistenciasEstoque bllRelatorioInconsistenciasEstoque = new bllRelatorioInconsistenciasEstoque();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegistraScript("DefineMascara", "DefineMascaras()", 30);

            if (!IsPostBack)
            {
                txtCodigoProduto.Attributes.Add("onblur", "javascript:fctPreencheNomeProduto();");
                ((SiteMaster)this.Master).Legend = "Relatório de ICMS à Restituir";
                bllRelatorioInconsistenciasEstoque bllRelatorioInconsistenciasEstoque = new bllRelatorioInconsistenciasEstoque();
                CarregarReportView(bllRelatorioInconsistenciasEstoque.Select(new voRelatorioInconsistenciasEstoque()));
            }
        }

        public void CarregarReportView(IList<voRelatorioInconsistenciasEstoque> listVO)
        {
            this.rptvRelatorioInconsistenciasEstoque.ProcessingMode = ProcessingMode.Local;

            LocalReport report = this.rptvRelatorioInconsistenciasEstoque.LocalReport;

            string caminho = Server.MapPath(@"Design/RelatorioInconsistenciasEstoque.rdlc");

            if (File.Exists(caminho))
            {
                report.ReportPath = caminho;
            }

            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSetRelatorioInconsistenciasEstoque";

            report.DataSources.Clear();
            report.DataSources.Add(rds);

            if (listVO.Count > 0)
            {
                pnlReportViewer.Visible = true;
                pnlMensagem.Visible = false;

                rds.Value = listVO;

                report.DataSources.Clear();

                report.DataSources.Add(rds);
            }
            else
            {
                pnlReportViewer.Visible = false;
                pnlMensagem.Visible = true;

                report.DataSources.Clear();
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            base.ResetControls(this);
            CarregarReportView(bllRelatorioInconsistenciasEstoque.Select(new voRelatorioInconsistenciasEstoque()));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            voRelatorioInconsistenciasEstoque voRelatorioInconsistenciasEstoque = new voRelatorioInconsistenciasEstoque();

            if (rblTipoNota.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioInconsistenciasEstoque.DataInicioNotaSaida = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioInconsistenciasEstoque.DataInicioNotaSaida = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioInconsistenciasEstoque.DataFimNotaSaida = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioInconsistenciasEstoque.DataFimNotaSaida = null;
                }
            }
            else if (rblTipoNota.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioInconsistenciasEstoque.DataInicioNotaEntrada = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioInconsistenciasEstoque.DataInicioNotaEntrada = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioInconsistenciasEstoque.DataFimNotaEntrada = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioInconsistenciasEstoque.DataFimNotaEntrada = null;
                }
            }

            if (!String.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                voRelatorioInconsistenciasEstoque.CodigoProdutoCliente = txtCodigoProduto.Text;
            }

            CarregarReportView(bllRelatorioInconsistenciasEstoque.Select(voRelatorioInconsistenciasEstoque));
        }

        protected void btnRecuperaNomeProduto_Click(object sender, EventArgs e)
        {
            RecuperaNomeProduto();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] ListaAutoComplete(string prefixText, int count)
        {
            voProduto voProduto = new voProduto();
            bllProduto bllProduto = new bllProduto();
            List<string> items = new List<string>(count);

            voProduto.Nome = prefixText;

            IList<voProduto> listProdutos = bllProduto.Select(voProduto);


            foreach (var item in listProdutos)
            {
                items.Add(item.Nome);
            }

            return items.ToArray();
        }

        public void RecuperaNomeProduto()
        {
            voProduto voProduto = new voProduto();
            bllProduto bllProduto = new bllProduto();
            IList<voProduto> listProdutos = null;

            if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                voProduto.CodigoProdutoCliente = txtCodigoProduto.Text.Trim();
                listProdutos = bllProduto.Select(voProduto);

                if (listProdutos.Count > 0)
                {
                    txtNomeProduto.Text = listProdutos[0].Nome;
                }
                else
                {
                    txtNomeProduto.Text = string.Empty;
                }
            }
            else
            {
                txtNomeProduto.Text = string.Empty;
            }
        }
    }
}