#region Usings

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    /// <summary>
    /// Classe "PageBase"
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        #region Atributos e Propriedades

        internal delegate void ConfirmacaoSim(object sender, EventArgs e);
        internal event ConfirmacaoSim RetornoConfirmacaoPagina;
       
        private ScriptManager _scriptManager;

        public ScriptManager AjaxScriptManager
        {
            get
            {
                if (_scriptManager == null)
                {
                    _scriptManager = ScriptManager.GetCurrent(this);
                }

                return _scriptManager;
            }
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento disparado no Load da página
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if ((Session["UsuarioLogado"] == null) || ((bool)Session["UsuarioLogado"] != true))
            {
                Response.Redirect("~/Login.aspx");
            }

            base.OnLoad(e);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Gera a modal de confirmação
        /// </summary>
        /// <param name="mensagem">Mensagem da Modal</param>
        /// <param name="titulo">Título da Modal</param>
        protected void GeraConfirmacao(string mensagem, string titulo)
        {
            string funcao = null;

            try
            {
                mensagem = mensagem.Replace("'", string.Empty).Replace("(", " ").Replace(")", " ");

                if (string.IsNullOrEmpty(titulo))
                {
                    titulo = "Solinea ICMS";
                }

                funcao = string.Format("fctChamaModalConfirmacao('{0}', '{1}');", mensagem, titulo);                

                this.RegistraScript("GeraConfirmacao", funcao, 30);
            }
            catch
            {
                throw;
            }
            finally
            {
                funcao = null;
            }
        }

        /// <summary>
        /// Método que registra o script
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="script"></param>
        /// <param name="timeout"></param>
        protected void RegistraScript(string chave, string script, int timeout)
        {
            string scriptFinal = "window.setTimeout(\"" + script + "\", " + timeout + ");";

            if (AjaxScriptManager == null)
            {
                if (!ClientScript.IsStartupScriptRegistered(chave))
                {
                    ClientScript.RegisterStartupScript(Type.GetType("System.String"), chave, scriptFinal, true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Type.GetType("System.String"), chave, scriptFinal, true);
            }
        }

        /// <summary>
        /// Reseta todos os controles filhos do controle passado por parâmetro
        /// </summary>
        /// <param name="control"></param>
        protected void ResetControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c is DropDownList)
                {
                    ((DropDownList)c).SelectedIndex = 0;
                }
                else if (c.Controls.Count > 0)
                {
                    ResetControls(c);
                }
            }
        }

        /// <summary>
        /// Através da string passada por parâmetro, cria uma hash MD%
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        #endregion         
    }
}

#endregion