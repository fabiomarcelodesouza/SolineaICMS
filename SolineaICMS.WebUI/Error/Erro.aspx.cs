#region Usings

using System;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.WebUI.Error
{
    public partial class Erro : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                string mensagem = string.Empty;
                string nomeProcedure = string.Empty;
                string causaProvavel = string.Empty;
                string tipoExcecao = string.Empty;
                string msgErro = string.Empty;
                string stackTrace = string.Empty;
                string telefoneSuporte = ConfigurationManager.TelefoneSuporte;
                string emailSuporte = ConfigurationManager.EmailSuporte;

                lblTelefoneSuporte.Text = telefoneSuporte;
                spnEmailSuporte.InnerHtml = String.Format("<a href='mailto:{0}'>{0}</a>", emailSuporte);

                if (Session["Erro"].GetType().Name == "CustomException")
                {
                    mensagem = ((CustomException)Session["Erro"]).Mensagem;
                    nomeProcedure = ((CustomException)Session["Erro"]).NomeProcedure;
                    causaProvavel = ((CustomException)Session["Erro"]).CausaProvavel;
                    tipoExcecao = ((CustomException)Session["Erro"]).InnerException.GetType().FullName;
                    msgErro = ((CustomException)Session["Erro"]).InnerException.Message;
                    stackTrace = ((CustomException)Session["Erro"]).InnerException.StackTrace;
                }
                else
                {
                    mensagem = "Ocorreu um erro no sistema";                                        
                    tipoExcecao = ((Exception)Session["Erro"]).GetType().FullName;
                    msgErro = ((Exception)Session["Erro"]).Message;
                    stackTrace = ((Exception)Session["Erro"]).StackTrace;
                }

                ((SiteMaster)this.Master).Legend = mensagem;

                if (!string.IsNullOrEmpty(nomeProcedure))
                {
                    lblTitNomeProcedure.Visible = true;
                    lblNomeProcedure.Visible = true;

                    lblNomeProcedure.Text = nomeProcedure;
                }

                if (!string.IsNullOrEmpty(causaProvavel))
                {
                    lblTitCausaProvavel.Visible = true;
                    lblCausaProvavel.Visible = true;

                    lblCausaProvavel.Text = causaProvavel;
                }

                lblTipoExcecao.Text = tipoExcecao;
                lblMsgErro.Text = msgErro;
                lblStackTrace.Text = stackTrace;

                Server.ClearError();
            }
        }

        #endregion
    }
}

#endregion