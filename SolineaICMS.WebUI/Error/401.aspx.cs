﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolineaICMS.WebUI;

namespace SolineaICMS.WebUI.Error
{
    public partial class _401 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((SiteMaster)this.Master).Legend = "Acesso negado";
            }
        }        
    }
}