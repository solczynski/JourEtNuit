using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JourEtNuit.MasterPages
{
    public partial class front : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userRole = HttpContext.Current.Session[Constants.Session.UserRole] as string;
            if (userRole != Constants.UserRoles.Admin.ToString())
            {
                TopMenu.Visible = false;
            }

            lbl_UserName.Text = HttpContext.Current.Session[Constants.Session.UserName] as string;
            lbl_UserRole.Text = HttpContext.Current.Session[Constants.Session.UserRole] as string;
        }
    }
}