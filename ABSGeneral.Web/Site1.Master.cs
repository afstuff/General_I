using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSGeneral.Model;

namespace ABSGeneral.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check session
                GetSession();
            }
        }

        private void GetSession()
        {
            if (Session["absuser"] != null)
            {
                lnkRegister.Visible = false;
                lnkLogin.Visible = false;
                GetUserDetails();
            }
            else
            {
                lnkRegister.Visible = true;
                lnkLogin.Visible = true;
            }
        }

        //get user details
        private void GetUserDetails()
        {
            ABSPASSTAB absuser = (ABSPASSTAB)Session["absuser"];
            lnkUserName.Text = absuser.PWD_USER_NAME.Trim();
            userImage.ImageUrl = "Content/profilePics/User-icon.png";
        }

    }
}