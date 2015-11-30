using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABSGeneral.Web
{
    public partial class Site0 : System.Web.UI.MasterPage
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
            var user = Session["absuser"].ToString();



        }
    }
}