#region Usings

using System;
using SolineaICMS.BLL;
using SolineaICMS.VO;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("UsuarioLogado");
            Session.Remove("CodigoUsuario");
            Session.Remove("Login");
            Session.Remove("NomeUsuario");
            Session.Remove("Perfil");
            Session.Remove("Usuario");
            UserName.Focus();
            
            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Bem Vindo ao Solinea ICMS";
            }         
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            string login = UserName.Text.Trim();
            string senha = UtilCriptografia.GetMd5Hash(Password.Text.Trim());

            voUsuario voUsuario = new voUsuario(login, senha);
            bllUsuario bllUsuario = new bllUsuario();

            if (bllUsuario.Login(voUsuario) != null)
            {
                Session["UsuarioLogado"] = true;
                Session["CodigoUsuario"] = voUsuario.CodigoUsuario;
                Session["Login"] = voUsuario.Login;
                Session["NomeUsuario"] = voUsuario.Nome;
                Session["Perfil"] = voUsuario.Perfil;
                Session["Usuario"] = voUsuario;      

                Response.Redirect("~/Default.aspx");
            }
            else
            {
                divMsgErroAutenticacao.Visible = true;
                divMsgInicial.Visible = false;
            }
        }

        #endregion

        #region Métodos

      

        #endregion
    }
}

#endregion