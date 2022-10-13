#region Usings

using System;
using SolineaICMS.Util;

#endregion

#region Class

namespace SolineaICMS.WebUI.UC
{
    public partial class UCMensagens : System.Web.UI.UserControl
    {
        #region Properties

        public UtilEnums.MessageType MessageType { get; set; }
        public string Mensagem { get; set; }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Methods

        public void ShowMessage()
        {
            if (this.MessageType == UtilEnums.MessageType.Error)
            {
                this.imgMensagem.ImageUrl = "/SolineaICMS_App/Images/Icons/error32px.png";
            }
            else if (this.MessageType == UtilEnums.MessageType.Information)
            {
                this.imgMensagem.ImageUrl = "/SolineaICMS_App/Images/Icons/information32px.png";
            }
            else if (this.MessageType == UtilEnums.MessageType.Question)
            {
                this.imgMensagem.ImageUrl = "/SolineaICMS_App/Images/Icons/question32px.png";
            }
            else if (this.MessageType == UtilEnums.MessageType.Success)
            {
                this.imgMensagem.ImageUrl = "/SolineaICMS_App/Images/Icons/success32px.png";
            }
            else if (this.MessageType == UtilEnums.MessageType.Warning)
            {
                this.imgMensagem.ImageUrl = "/SolineaICMS_App/Images/Icons/warning32px.png";
            }

            this.lblMensagem.Text = this.Mensagem;
            this.imgMensagem.ToolTip = this.Mensagem;
            this.pnlMensagem.Style.Add("display", "");
        }

        public void HideMessage()
        {
            this.pnlMensagem.Style.Add("display", "none");
        }

        #endregion
    }
}

#endregion