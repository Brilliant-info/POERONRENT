using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.Login;
using System.Web.Services;
using PowerOnRentwebapp.ToolbarService;

namespace PowerOnRentwebapp.PowerOnRent
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["invoker"].ToString() == "Request")
            {

                h4DivHead.InnerText = "List of Material Request";
                UCFormHeader1.FormHeaderText = "Material Request";
                iframePOR.Attributes.Add("src", "../PowerOnRent/GridRequestSummary.aspx?FillBy=UserID");
                Toolbar1.SetUserRights("MaterialRequest", "Summary", "");

            }
            else if (Request.QueryString["invoker"].ToString() == "Issue")
            {
                h4DivHead.InnerText = "List of Material Issue Notes";
                UCFormHeader1.FormHeaderText = "Material Issue";
                iframePOR.Attributes.Add("src", "../PowerOnRent/GridIssueSummary.aspx?FillBy=UserID");
                Toolbar1.SetUserRights("MaterialIssue", "Summary", "");
                Toolbar1.SetAddNewRight(false, "Click on pending Issue record [Red box] to Add New / Edit Issue");
            }
            else if (Request.QueryString["invoker"].ToString() == "Receipt")
            {
                h4DivHead.InnerText = "List of Material Receipts";
                UCFormHeader1.FormHeaderText = "Material Receipts";
                iframePOR.Attributes.Add("src", "../PowerOnRent/GridReceiptSummary.aspx?FillBy=UserID");
                Toolbar1.SetUserRights("MaterialReceipt", "Summary", "");
                Toolbar1.SetAddNewRight(false, "Click on pending Receipt record [Red box] to Add New / Edit Receipt");
            }
            else if (Request.QueryString["invoker"].ToString() == "Consumption")
            {
                h4DivHead.InnerText = "List of Consumption";
                UCFormHeader1.FormHeaderText = "Consumption";
                iframePOR.Attributes.Add("src", "../PowerOnRent/GridConsumptionSummary.aspx?FillBy=UserID");
                Toolbar1.SetUserRights("Consumption", "Summary", "");
            }
            else if (Request.QueryString["invoker"].ToString() == "HQReceipt")
            {
                h4DivHead.InnerText = "List of Goods Receipts [HQ]";
                UCFormHeader1.FormHeaderText = "Goods Receipts [HQ]";
                iframePOR.Attributes.Add("src", "../PowerOnRent/GridHQReceiptSummary.aspx?FillBy=UserID");
                Toolbar1.SetUserRights("GoodsReceipt", "Summary", "");
            }

            Toolbar1.SetSaveRight(false, "Not Allowed");
            Toolbar1.SetClearRight(false, "Not Allowed");
        }

        [WebMethod]
        public static string WMSetSessionAddNew(string ObjectName, string state)
        {
            HttpContext.Current.Session["PORstate"] = state;
            switch (ObjectName)
            {
                case "Request":
                    HttpContext.Current.Session["PORRequestID"] = 0;
                    break;
                case "Issue":
                    HttpContext.Current.Session["PORIssueID"] = 0;
                    break;
                case "Receipt":
                    HttpContext.Current.Session["PORReceiptID"] = 0;
                    break;
                case "Consumption":
                    HttpContext.Current.Session["PORConsumptionID"] = 0;
                    break;
                case "HQReceipt":
                    HttpContext.Current.Session["PORHQReceiptID"] = 0;
                    break;
            }

            return ObjectName;
        }

        [WebMethod]
        public static string WMSetSessionRequest(string ObjectName, long RequestID, string state)
        {
            ClearSession();
            HttpContext.Current.Session["PORRequestID"] = RequestID;
            HttpContext.Current.Session["PORstate"] = state;
            iUCToolbarClient objService = new iUCToolbarClient();
            mUserRolesDetail checkRole = new mUserRolesDetail();
            CustomProfile profile = CustomProfile.GetProfile();
            switch (ObjectName)
            {
                case "Request":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialRequest", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Approval":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialRequest", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Issue":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialIssue", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Receipt":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialReceipt", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Consumption":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("Consumption", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
            }
            if (checkRole.Add == false && checkRole.View == false)
            {
                ObjectName = "AccessDenied";
            }
            else if (ObjectName == "Approval" && checkRole.Approval == false)
            {
                ObjectName = "AccessDenied";
            }
            return ObjectName;
        }

        [WebMethod]
        public static string WMSetSessionIssue(string ObjectName, long IssueID, string state)
        {
            ClearSession();
            HttpContext.Current.Session["PORIssueID"] = IssueID;
            HttpContext.Current.Session["PORstate"] = state;
            iUCToolbarClient objService = new iUCToolbarClient();
            mUserRolesDetail checkRole = new mUserRolesDetail();
            CustomProfile profile = CustomProfile.GetProfile();
            switch (ObjectName)
            {
                case "Issue":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialIssue", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Receipt":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialReceipt", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Consumption":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("Consumption", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
            }
            if (checkRole.Add == false && checkRole.View == false)
            {
                ObjectName = "AccessDenied";
            }
            return ObjectName;
        }

        [WebMethod]
        public static string WMSetSessionReceipt(string ObjectName, long ReceiptID, string state)
        {
            ClearSession();
            HttpContext.Current.Session["PORReceiptID"] = ReceiptID;
            HttpContext.Current.Session["PORstate"] = state;
            iUCToolbarClient objService = new iUCToolbarClient();
            mUserRolesDetail checkRole = new mUserRolesDetail();
            CustomProfile profile = CustomProfile.GetProfile();
            switch (ObjectName)
            {
                case "Receipt":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("MaterialReceipt", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
                case "Consumption":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("Consumption", profile.Personal.UserID, profile.DBConnection._constr);
                    HttpContext.Current.Session["PORConsumptionID"] = null;
                    break;
            }
            if (checkRole.Add == false && checkRole.View == false)
            {
                ObjectName = "AccessDenied";
            }
            return ObjectName;
        }

        [WebMethod]
        public static string WMSetSessionConsumption(string ObjectName, long ConsumptionID, string state)
        {
            ClearSession();
            HttpContext.Current.Session["PORConsumptionID"] = ConsumptionID;
            HttpContext.Current.Session["PORstate"] = state;
            iUCToolbarClient objService = new iUCToolbarClient();
            mUserRolesDetail checkRole = new mUserRolesDetail();
            CustomProfile profile = CustomProfile.GetProfile();
            switch (ObjectName)
            {
                case "Consumption":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("Consumption", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
            }
            if (checkRole.Add == false && checkRole.View == false)
            {
                ObjectName = "AccessDenied";
            }
            return ObjectName;
        }

        [WebMethod]
        public static string WMSetSessionHQReceipt(string ObjectName, long ReceiptID, string state)
        {
            ClearSession();
            HttpContext.Current.Session["PORHQReceiptID"] = ReceiptID;
            HttpContext.Current.Session["PORstate"] = state;
            iUCToolbarClient objService = new iUCToolbarClient();
            mUserRolesDetail checkRole = new mUserRolesDetail();
            CustomProfile profile = CustomProfile.GetProfile();
            switch (ObjectName)
            {
                case "HQReceipt":
                    checkRole = objService.GetUserRightsBy_ObjectNameUserID("GoodsReceipt", profile.Personal.UserID, profile.DBConnection._constr);
                    break;
            }
            if (checkRole.Add == false && checkRole.View == false)
            {
                ObjectName = "AccessDenied";
            }
            return ObjectName;
        }

        static void ClearSession()
        {
            HttpContext.Current.Session["PORRequestID"] = null;
            HttpContext.Current.Session["PORIssueID"] = null;
            HttpContext.Current.Session["PORReceiptID"] = null;
            HttpContext.Current.Session["PORConsumptionID"] = null;
            HttpContext.Current.Session["PORHQReceiptID"] = null;
            HttpContext.Current.Session["PORstate"] = null;
        }
    }
}