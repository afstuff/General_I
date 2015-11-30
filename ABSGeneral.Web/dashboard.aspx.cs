using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSGeneral.Model;

namespace ABSGeneral.Web
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSession();
        }

        private void GetSession()
        {
            if (Session["absuser"] != null)
            {
                GetUserDetails();
            }
            else
            {
                Response.Redirect("LogOut.aspx");
            }
        }

        private void GetUserDetails()
        {
            ABSPASSTAB absuser = (ABSPASSTAB) Session["absuser"];
            lblUserName.Text = absuser.PWD_USER_NAME.Trim();

        }



    }
}