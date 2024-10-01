using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Security;

namespace PowerOnRentwebapp.Login
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomProfile profile = CustomProfile.GetProfile();
                lblLoginName.Text = profile.UserName;
            }
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }
        }

        [WebMethod]
        public static string PMSaveChangePassword(string loginname, string currentpassword, string newpassword)
        {
            try
            {
                MembershipUser u = Membership.GetUser(loginname);
                if (u.IsLockedOut == true) u.UnlockUser();
                if (u.ChangePassword(currentpassword, newpassword) == true)
                {
                    return "Saved";
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex) { return ""; }
            finally { }
        }

    }
}