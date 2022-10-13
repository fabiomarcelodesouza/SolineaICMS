#region Usings

using System;
using System.Web.UI.WebControls;
using SolineaICMS.BLL;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class BackupEfetuar : PageBase
    {
        /// <summary>
        /// Evento chamado no Load da Página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SiteMaster)this.Master).Perfil = "A";

            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Efetuar Backup";
                lblMensagem.Text = String.Format("Tem certeza que deseja efetuar backup da base de dados <b>{0}</b>?", ConfigurationManager.NomeBancoDados);
            }
            else
            {
                ucMensagem.HideMessage();
            }
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            try
            {
                new bllBackup().EfetuarBackup(new voBackup(ConfigurationManager.NomeBancoDados));

                ucMensagem.MessageType = UtilEnums.MessageType.Success;
                ucMensagem.Mensagem = "Backup efetuado com sucesso.";
                ucMensagem.ShowMessage();
            }
            catch (Exception ex)
            {
                ucMensagem.MessageType = UtilEnums.MessageType.Error;
                ucMensagem.Mensagem = ex.Message;
                ucMensagem.ShowMessage();
            }            
        }
    }
}

#endregion