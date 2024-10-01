using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.InboxService;
using System.Web.Services;
using PowerOnRentwebapp.Approval;


namespace PowerOnRentwebapp.Inbox
{
    public partial class InboxPOR : System.Web.UI.Page
    {
        static Page staticThispage;
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; } }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            iInboxClient InboxService = new iInboxClient();
            if (hndLinkValue.Value == "") hndLinkValue.Value = "All";
            GVInboxPOR.DataSource = InboxService.GetInboxDetailBySiteUserID(profile.Personal.UserID, hndLinkValue.Value, profile.DBConnection._constr).ToList();
            GVInboxPOR.DataBind();

        }

        [WebMethod]
        public static string wmUpdateApproval(string Status, string Remark, string tApprovalIDs)
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                UC_Approval uc = new UC_Approval();
                return uc.FinalUpdateApproval(Status, Remark, tApprovalIDs, profile.Personal.UserID);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, staticThispage, "PartRequisition", "imgBtnEdit_Click");
                return "";
            }

        }
    }
}