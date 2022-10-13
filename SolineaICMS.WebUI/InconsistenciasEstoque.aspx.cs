#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SolineaICMS.BLL;
using SolineaICMS.VO;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class InconsistenciasEstoque : PageBase
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
                int qtdeInconsistencias = UpdateGrid(new voInconsistenciasEstoque());

                AtualizaInformacoes(qtdeInconsistencias);

                ((SiteMaster)this.Master).Legend = "Inconsistências de Estoque";

                if (((SiteMaster)this.Master).Perfil != "M")
                {
                    btnCorrigir.Visible = false;
                    gvItens.Columns[7].Visible = false;
                }
            }
        }

        protected void btnCorrigir_Click(object sender, EventArgs e)
        {
            GerarCargaInicial();
        }

        protected void gvItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (((SiteMaster)this.Master).Perfil == "M")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = ((CheckBox)e.Row.Cells[7].FindControl("chkCorrigir"));
                    double quantidade = Convert.ToDouble(e.Row.Cells[3].Text);

                    if (quantidade > 0)
                    {
                        check.Checked = false;
                        check.Enabled = false;
                    }
                }
            }
        }

        protected void gvItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItens.PageIndex = e.NewPageIndex;
            this.UpdateGrid(new voInconsistenciasEstoque());
        }

        #endregion

        #region Métodos

        private int UpdateGrid(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            bllInconsistenciasEstoque bllInconsistenciasEstoque = new BLL.bllInconsistenciasEstoque();
            IList<voInconsistenciasEstoque> listItems = bllInconsistenciasEstoque.Select(voInconsistenciasEstoque);

            gvItens.DataSource = listItems;
            gvItens.DataBind();

            return listItems.Count;
        }

        private void GerarCargaInicial()
        {
            lblMensagemInc1.Visible = true;

            bllInconsistenciasEstoque bllInconsistenciasEstoque = new BLL.bllInconsistenciasEstoque();
            CheckBox check;
            List<voInconsistenciasEstoque> listaInconsistencias = new List<voInconsistenciasEstoque>();
            voInconsistenciasEstoque objInconsistencia;

            foreach (GridViewRow row in gvItens.Rows)
            {
                check = ((CheckBox)row.FindControl("chkCorrigir"));

                if (check.Checked)
                {
                    objInconsistencia = new voInconsistenciasEstoque();

                    objInconsistencia.CodigoProdutoCliente = row.Cells[0].Text;
                    objInconsistencia.NomeProduto = row.Cells[1].Text;
                    objInconsistencia.Ncm = Convert.ToInt64(row.Cells[2].Text);
                    objInconsistencia.Quantidade = Convert.ToDecimal(row.Cells[3].Text) * (-1);
                    objInconsistencia.UnidadeMedida = row.Cells[6].Text;
                    objInconsistencia.CodigoUsuario = (int)Session["CodigoUsuario"];

                    listaInconsistencias.Add(objInconsistencia);
                }
            }

            bllInconsistenciasEstoque = new bllInconsistenciasEstoque();
            bllInconsistenciasEstoque.CorrigirInconsistencias(listaInconsistencias);

            int qtdeInconsistencias = UpdateGrid(new voInconsistenciasEstoque());

            AtualizaInformacoes(qtdeInconsistencias);
        }

        private void AtualizaInformacoes(int qtdeInconsistencias)
        {
            if (qtdeInconsistencias == 0)
            {
                lblMensagemInc1.Visible = false;
                btnCorrigir.Visible = false;
            }
            else if (qtdeInconsistencias == 1)
            {
                lblMensagemInc1.Visible = true;
                lblMensagemInc1.Text = String.Format("Foi encontrada 1 inconsistência de estoque:");
            }
            else if (qtdeInconsistencias > 1)
            {
                lblMensagemInc1.Visible = true;
                lblMensagemInc1.Text = String.Format("Foram encontradas {0} inconsistências de estoque:", qtdeInconsistencias);
            }
        }

        #endregion
    }
}

#endregion