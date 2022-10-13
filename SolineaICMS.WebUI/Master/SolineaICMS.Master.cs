#region Usings

using System;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region Propiedades

        /// <summary>
        /// Legend dos fieldsets principais das páginas
        /// </summary>
        public string Legend
        {
            set
            {
                lblLegend.Text = value;
            }
        }

        /// <summary>
        /// Título da página
        /// </summary>
        public string Title
        {
            set
            {
                //lblTitle.Text = value;
            }
        }

        /// <summary>
        /// Perfil do usuário que tem permissão à pagina
        /// </summary>
        public string Perfil { get; set; }

        #endregion

        #region Eventos

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.Error += new System.EventHandler(this.Page_Error);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgShadowLeft.Style.Add("height", "100%");
                imgShadowRight.Style.Add("height", "100%");
            }

            //Verifica se o perfil do usuário logado tem permissão de acesso à página
            if (this.Perfil != null)
            {
                if (!Session["Perfil"].ToString().Equals("M"))
                {
                    if (!Session["Perfil"].ToString().Equals(this.Perfil))
                    {
                        Response.Redirect("~/Error/401.aspx");
                    }
                }
            }

            this.ConfigurarMenu();
            this.ConfigurarSaudacao();
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Session["Erro"] = Server.GetLastError();
            Response.Redirect("~/Error/Erro.aspx");
        }

        #endregion

        #region Métodos

        private void ConfigurarMenu()
        {
            if ((Session["UsuarioLogado"] == null) || ((bool)Session["UsuarioLogado"] != true))
            {
                MenuPrincipal.Visible = false;
                divMenu.Visible = false;
            }
            else
            {
                MenuPrincipal.DataSource = SiteMapDataSourceSolineaIcms;
                MenuPrincipal.DataBind();

                MenuPrincipal.Visible = true;
                divMenu.Visible = true;
            }
        }

        private void ConfigurarSaudacao()
        {
            if ((Session["UsuarioLogado"] == null) || ((bool)Session["UsuarioLogado"] != true))
            {
                divSaudacao.Visible = false;
            }
            else
            {                                
                divSaudacao.Visible = true;
                spnNomeUsuarioLogado.InnerText = Session["NomeUsuario"].ToString();                
                lblNomeEmpresa.Text = ConfigurationManager.NomeEmpresa;
                lblCnpjEmpresa.Text = ConfigurationManager.CnpjEmpresa;
            }
        }

        #endregion
    }
}

#endregion