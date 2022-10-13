using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SolineaICMS.WebUI
{
    public partial class Sobre : PageBase
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                ((SiteMaster)this.Master).Legend = "Sobre o Solinea ICMS";
            }
        }

        #endregion

        #region Métodos
     

        #endregion
    }
}