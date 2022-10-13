using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SolineaICMS.Util.Web
{
    public class SiteMapProvider : XmlSiteMapProvider
    {
        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            if ((context.Session["Perfil"].ToString().Equals("M")) || (node.Roles[0].Equals("*")))
            {
                return true;
            }            
            else
            {
                if (context.Session["Perfil"].ToString().Equals("A") && node.Roles[0].Equals("Administradores"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
