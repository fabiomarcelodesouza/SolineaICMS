#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Reporting.WebForms;
using SolineaICMS.BLL.Relatorios;
using SolineaICMS.VO.Relatorios;

#endregion

#region Classe

namespace SolineaICMS.WebUI.Relatorios
{
    public partial class RelatorioIcmsRestituir : PageBase
    {
        #region Propriedades

        private MetodoApuracao MetodoApuracaoSelecionado { get; set; }

        private enum MetodoApuracao
        {
            Peps,
            CustoMedio
        }

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MetodoApuracao"].ToString() == MetodoApuracao.Peps.ToString())
            {
                this.MetodoApuracaoSelecionado = MetodoApuracao.Peps;
            }
            else
            {
                this.MetodoApuracaoSelecionado = MetodoApuracao.CustoMedio;
            }

            this.RegistraScript("DefineMascara", "DefineMascaras()", 30);

            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Relatório de ICMS à Restituir";

                //Page.Form.DefaultButton = btnGerar.UniqueID;                

                pnlReportViewer.Visible = false;
                pnlMensagem.Visible = true;                
            }
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            switch (this.MetodoApuracaoSelecionado)
            {
                case MetodoApuracao.Peps:
                    this.FiltrarRelatorioPeps();
                    break;
                case MetodoApuracao.CustoMedio:
                    this.FiltrarRelatorioCustoMedio();
                    break;
                default:
                    break;
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            base.ResetControls(this);            
        }

        #endregion

        #region Métodos

        private void FiltrarRelatorioPeps()
        {
            voRelatorioIcmsRestituirPeps voRelatorioIcmsRestituirPeps = new voRelatorioIcmsRestituirPeps();

            if (rblTipoNota.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioIcmsRestituirPeps.DataInicioNotaSaida = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirPeps.DataInicioNotaSaida = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioIcmsRestituirPeps.DataFimNotaSaida = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirPeps.DataFimNotaSaida = null;
                }
            }
            else if (rblTipoNota.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioIcmsRestituirPeps.DataInicioNotaEntrada = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirPeps.DataInicioNotaEntrada = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioIcmsRestituirPeps.DataFimNotaEntrada = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirPeps.DataFimNotaEntrada = null;
                }
            }

            CarregarReportView(voRelatorioIcmsRestituirPeps);
        }

        private void FiltrarRelatorioCustoMedio()
        {
            voRelatorioIcmsRestituirCustoMedio voRelatorioIcmsRestituirCustoMedio = new voRelatorioIcmsRestituirCustoMedio();

            if (rblTipoNota.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioIcmsRestituirCustoMedio.DataInicioNotaSaida = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirCustoMedio.DataInicioNotaSaida = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioIcmsRestituirCustoMedio.DataFimNotaSaida = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirCustoMedio.DataFimNotaSaida = null;
                }
            }
            else if (rblTipoNota.SelectedIndex == 1)
            {
                if (!string.IsNullOrEmpty(txtDataInicio.Text.Trim()))
                {
                    voRelatorioIcmsRestituirCustoMedio.DataInicioNotaEntrada = Convert.ToDateTime(String.Format("{0} 00:00:00", txtDataInicio.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirCustoMedio.DataInicioNotaEntrada = null;

                }

                if (!string.IsNullOrEmpty(txtDataFinal.Text.Trim()))
                {
                    voRelatorioIcmsRestituirCustoMedio.DataFimNotaEntrada = Convert.ToDateTime(String.Format("{0} 23:59:59", txtDataFinal.Text.Trim()));
                }
                else
                {
                    voRelatorioIcmsRestituirCustoMedio.DataFimNotaEntrada = null;
                }
            }

            CarregarReportView(voRelatorioIcmsRestituirCustoMedio);
        }

        private void CarregarReportView(voRelatorioIcmsRestituirPeps voRelatorioIcmsRestituir)
        {
            bllRelatorioIcmsRestituirPeps bllRelatorioIcmsRestituirPeps = new bllRelatorioIcmsRestituirPeps();
            bllRelatorioIcmsRestituirResumoNotas bllRelatorioIcmsRestituirResumoNotas = new bllRelatorioIcmsRestituirResumoNotas();
            voRelatorioIcmsRestituirResumoNotas voRelatorioIcmsRestituirResumoNotas = new voRelatorioIcmsRestituirResumoNotas();

            this.rptvRelatorioIcmsRestituir.ProcessingMode = ProcessingMode.Local;
            LocalReport report = this.rptvRelatorioIcmsRestituir.LocalReport;
            string caminho = string.Empty;

            ReportDataSource rds = new ReportDataSource();
            ReportDataSource rdsResumoNotas = new ReportDataSource();

            voRelatorioIcmsRestituirResumoNotas.DataInicioNotaEntrada = voRelatorioIcmsRestituir.DataInicioNotaEntrada;
            voRelatorioIcmsRestituirResumoNotas.DataFimNotaEntrada = voRelatorioIcmsRestituir.DataFimNotaEntrada;
            voRelatorioIcmsRestituirResumoNotas.DataInicioNotaSaida = voRelatorioIcmsRestituir.DataInicioNotaSaida;
            voRelatorioIcmsRestituirResumoNotas.DataFimNotaSaida = voRelatorioIcmsRestituir.DataFimNotaSaida;

            IList<voRelatorioIcmsRestituirPeps> listItems = new List<voRelatorioIcmsRestituirPeps>();
            IList<voRelatorioIcmsRestituirResumoNotas> listItemsResumoNotas = new List<voRelatorioIcmsRestituirResumoNotas>();

            caminho = Server.MapPath(@"Design/RelatorioIcmsRestituirPeps.rdlc");

            rds.Name = "DataSetRelatorioIcmsRestituirPeps";
            rdsResumoNotas.Name = "DataSetRelatorioIcmsRestituirResumoNotas";

            if (File.Exists(caminho))
            {
                report.ReportPath = caminho;
            }

            listItems = bllRelatorioIcmsRestituirPeps.Select(voRelatorioIcmsRestituir);
            listItemsResumoNotas = bllRelatorioIcmsRestituirResumoNotas.Select(voRelatorioIcmsRestituirResumoNotas);

            if (listItems.Count > 0)
            {
                pnlReportViewer.Visible = true;
                pnlMensagem.Visible = false;

                rds.Value = listItems;
                rdsResumoNotas.Value = listItemsResumoNotas;

                report.DataSources.Clear();

                report.DataSources.Add(rds);
                report.DataSources.Add(rdsResumoNotas);
            }
            else
            {
                pnlReportViewer.Visible = false;
                pnlMensagem.Visible = true;

                report.DataSources.Clear();
            }
        }

        private void CarregarReportView(voRelatorioIcmsRestituirCustoMedio voRelatorioIcmsRestituirCustoMedio)
        {
            bllRelatorioIcmsRestituirCustoMedio bllRelatorioIcmsRestituirCustoMedio = new bllRelatorioIcmsRestituirCustoMedio();
            this.rptvRelatorioIcmsRestituir.ProcessingMode = ProcessingMode.Local;
            LocalReport report = this.rptvRelatorioIcmsRestituir.LocalReport;
            string caminho = string.Empty;
            ReportDataSource rds = new ReportDataSource();
            IList<voRelatorioIcmsRestituirCustoMedio> listItems = new List<voRelatorioIcmsRestituirCustoMedio>();

            caminho = Server.MapPath(@"Design/RelatorioIcmsRestituirCustoMedio.rdlc");
            rds.Name = "DataSetRelatorioIcmsRestituirCustoMedio";

            if (File.Exists(caminho))
            {
                report.ReportPath = caminho;
            }

            listItems = bllRelatorioIcmsRestituirCustoMedio.Select(voRelatorioIcmsRestituirCustoMedio);

            if (listItems.Count > 0)
            {
                pnlReportViewer.Visible = true;
                pnlMensagem.Visible = false;

                rds.Value = listItems;
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

        #endregion
    }
}

#endregion