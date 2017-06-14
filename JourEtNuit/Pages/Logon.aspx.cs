using Common;
using JourEtNuit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JourEtNuit.Pages
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            //if (AuthentificationService.CheckUserValidity(tb_login.Text, tb_pwd.Text))
            if (AuthentificationService.CheckUserValidity("ludovic", "password"))
            {
                HttpContext.Current.Response.Redirect("~/Pages/Home.aspx");
            }
        }

        protected void Btn_AddUser_Click(object sender, EventArgs e)
        {
            AuthentificationService.RegisterUser(tb_login.Text, tb_pwd.Text, 1);
        }

        protected void pwdLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
    }
}