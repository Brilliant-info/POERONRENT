using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections;
using Obout.Grid;
using System.IO;
using WebMsgBox;
using System.Web.Security;
using System.Web.UI.WebControls;


namespace PowerOnRentwebapp.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientLogo.ImageUrl = "#";
            lblSessionMsg.Visible = false;
            if (Request.QueryString["ID"] != null)
            {
                //ClientLogo.ImageUrl = "~/Company/Logo/" + Request.QueryString["ID"].ToString() + ".png";
                //loginuser.HyperLink1.NavigateUrl = "~/login/ForgotPassword.aspx?ID=" + Request.QueryString["ID"].ToString();
            }

            if (Request.QueryString["TimeOut"] != null)
            {
                if (Request.QueryString["TimeOut"] == "true") { lblSessionMsg.Visible = true; }
            }
        }

        protected void loginuser_OnLoggedIn(object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile(loginuser.UserName);
            if (profile != null)
            {
                Session.Abandon();
                Session.Clear();
                profile.Personal.Theme = "Blue";

                //profile.Personal.CLogoURL = "~/Company/Logo/14.png";
                //profile.Personal.CompanyID = 1;
                //if (Request.QueryString["ID"] != null) profile.Personal.CLogoURL = "~/Company/Logo/" + Request.QueryString["ID"].ToString() + ".png";

                //profile.Personal.UserID = 3;
                //profile.Personal.UserName = "Ashwini Kalekar";
                //profile.Personal.UserType = "Admin";

                //profile.DBConnection._constr[0] = "elegantcrm.db.11040877.hostedresource.com";
                //profile.DBConnection._constr[1] = "elegantcrm";
                //profile.DBConnection._constr[2] = "Password123#";
                //profile.DBConnection._constr[3] = "elegantcrm";

                //profile.DBConnection._constr[0] = "elegantcrm7.db.11040877.hostedresource.com";
                //profile.DBConnection._constr[1] = "elegantcrm7";
                //profile.DBConnection._constr[2] = "Password123#";
                //profile.DBConnection._constr[3] = "elegantcrm7";

                //profile.DBConnection._constr[0] = "164.52.198.68";
                //profile.DBConnection._constr[1] = "elegantcrm7";
                //profile.DBConnection._constr[2] = "Password123#";
                //profile.DBConnection._constr[3] = "sa";

                //                profile.DBConnection._constr[0] = "101.53.158.212,1433";
                profile.DBConnection._constr[0] = "10.1.1.4,6601";
                profile.DBConnection._constr[1] = "elegantcrm7";
                profile.DBConnection._constr[2] = "Password321#";
                profile.DBConnection._constr[3] = "sa";

                //profile.DBConnection._constr[0] = "server\\bisplserver";
                //profile.DBConnection._constr[1] = "elegantcrm7";
                //profile.DBConnection._constr[2] = "password123#";
                //profile.DBConnection._constr[3] = "sa";




                profile.Save();

               // Response.Redirect("../Inbox/Inbox.aspx");//For POR
                Response.Redirect("../PowerOnRent/Default.aspx?invoker=Request");
            }
        }

        protected void loginuser_OnLoginError(object sender, EventArgs e)
        {
            MembershipUser userInfo = Membership.GetUser(loginuser.UserName);
        }
    }
}
