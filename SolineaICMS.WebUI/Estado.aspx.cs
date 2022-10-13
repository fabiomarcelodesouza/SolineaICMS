#region Usings

using System;
using System.Web.UI.WebControls;
using SolineaICMS.BLL;
using SolineaICMS.VO;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class Estado : PageBase
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetControls(this);
                UpdateGrid(new voEstado());

                ((SiteMaster)this.Master).Legend = "Alíquotas de ICMS";
            }
            else
            {
                ucMensagem.HideMessage();
            }
        }

        protected void gvItens_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TextBox textBox;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                textBox = ((TextBox)e.Row.FindControl("txtAliquotaIcms"));
                textBox.Text = ((int)((voEstado)(e.Row.DataItem)).AliquotaICMS).ToString();
                textBox.MaxLength = 2;
                textBox.Attributes.Add("onKeyPress", "return validaTecla(this, event)");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bllEstado bllEstado = new bllEstado();
            voEstado voEstado = new voEstado();
            decimal? aliquota;

            int cont = 0;

            ucMensagem.HideMessage();

            try
            {
                foreach (GridViewRow row in gvItens.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        if (!String.IsNullOrEmpty(((TextBox)row.Cells[2].FindControl("txtAliquotaIcms")).Text))
                        {
                            aliquota = Convert.ToDecimal(((TextBox)row.Cells[2].FindControl("txtAliquotaIcms")).Text);

                            voEstado.CodigoEstado = Convert.ToInt32(gvItens.DataKeys[cont]["CodigoEstado"]);
                            voEstado.AliquotaICMS = aliquota;

                            bllEstado.Update(voEstado);

                            cont++;
                        }
                        else
                        {
                            throw new Exception("É obrigatório preencher todas as alíquotas de ICMS.");
                        }
                    }
                }

                ucMensagem.MessageType = UtilEnums.MessageType.Success;
                ucMensagem.Mensagem = "Alíquotas de ICMS salvas com sucesso.";
                ucMensagem.ShowMessage();                
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateGrid(new voEstado());
        }

        #endregion

        #region Métodos

        private void UpdateGrid(voEstado voEstado)
        {
            try
            {
                bllEstado bllEstado = new bllEstado();

                gvItens.DataSource = bllEstado.Select(voEstado);
                gvItens.DataBind();
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }
        }

        #endregion
    }
}

#endregion