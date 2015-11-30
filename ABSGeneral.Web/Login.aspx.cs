using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using ABSGeneral.Model;
using ABSGeneral.Repository;

namespace ABSGeneral.Web
{
    public partial class Login : Page
    {
        // instantiate a serializer to return json string
        static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        // INSTANTIATE A USER_ACCOUNT CLASS
        private UserAccount UserAccount = new UserAccount();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string GetUserIdName(string userId)
        {
            var userName = UserAccount.GetUserIdName(userId);
            return userName;
        }

        [WebMethod(EnableSession = true)]
        public static int GetUserIdLogin(string userId, string userPwd)
        {
            ABSPASSTAB absuser = UserAccount.GetUserIdLogin(userId, userPwd);
            if (absuser != null)
            {
                var ctx = HttpContext.Current;
                ctx.Session["absuser"] = absuser;

                return 1;
            }
            return 0;
        }
    }
}
