#region Usings

using System;

#endregion

#region Classe

namespace SolineaICMS.WebUI
{
    public partial class _Default : PageBase
    {
        #region Métodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Bem Vindo ao Solinea ICMS";                
            }
        }

        #endregion
    }
}

#endregion