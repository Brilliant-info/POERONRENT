using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.Login;
using System.Web.Services;
using System.Data;
using Microsoft.Reporting.WebForms;
using PowerOnRentwebapp.PORServiceUCCommonFilter;
using PowerOnRentwebapp.CommonControls;

//namespace WebClientElegantCRM.PowerOnRent
namespace PowerOnRentwebapp.PowerOnRent
{
    public partial class CommonReport : System.Web.UI.Page
    {
        string QueryParameter, ObjectName;


        protected void Page_Load(object sender, EventArgs e)
        {
            //UCCommonFilter1.fillDetail();
            if (!IsPostBack)
            {
                QueryParameter = Request.QueryString["invoker"];
            }
            if (QueryParameter == null) { UCCommonFilter1.GridVisible(); }

            if (QueryParameter == "partrequest")
            { lblRptName.Text = "Part Requisition Report"; }
            else if (QueryParameter == "partissue")
            { lblRptName.Text = "Part Issue Report"; }
            else if (QueryParameter == "partstock")
            { lblRptName.Text = "Part Stock Report"; }
            else if (QueryParameter == "partreceipt")
            { lblRptName.Text = "Part Receipt Report"; }
            else if (QueryParameter == "partconsumption")
            { lblRptName.Text = "Part Consumption Report"; }
            else if (QueryParameter == "monthly")
            { lblRptName.Text = "PR-Report Monthly"; }
            else if (QueryParameter == "weeklylst")
            { lblRptName.Text = "Weekly Analysis"; }
            else if (QueryParameter == "consumabletracker")
            { lblRptName.Text = "Consumable Tracker"; }
            else if (QueryParameter == "productdtl")
            { lblRptName.Text = "Product Report"; }
            else if (QueryParameter == "transfer")
            { lblRptName.Text = "Transfer Report"; }
            else if (QueryParameter == "asset")
            { lblRptName.Text = "Site Wise Asset & Equipment Report"; }

            if (QueryParameter != null) UCCommonFilter1.GridVisibleTF(QueryParameter);

            changecolor(QueryParameter);
        }


        protected void fillDataSet()
        {
            DataSet dsCmnRpt = new DataSet();
            iUCCommonFilterClient UCCommonFilterClient = new iUCCommonFilterClient();
            CustomProfile profile = CustomProfile.GetProfile();
            QueryParameter = Request.QueryString["invoker"];
            try
            {
                if (QueryParameter.ToLower() == "partconsumption")
                {
                    ObjectName = "PartConsumption";
                    Session["ReportHeading"] = "Consumption Report";
                    dsCmnRpt = UCCommonFilterClient.GetReportData(UCCommonFilter1.hfCount_lcl, UCCommonFilter1.hdnEngineSelectedRec_lcl, UCCommonFilter1.hdnProductSelectedRec_lcl, UCCommonFilter1.frmdt_lcl, UCCommonFilter1.todt_lcl, ObjectName, profile.DBConnection._constr);
                }
                else if (QueryParameter.ToLower() == "partrequest")
                {
                    ObjectName = "PartRequisition";
                    Session["ReportHeading"] = "Part Requisition Register";
                    dsCmnRpt = UCCommonFilterClient.GetRequisitionData(UCCommonFilter1.hfCount_lcl, UCCommonFilter1.hdnRequestSelectedRec_lcl, UCCommonFilter1.hdnProductSelectedRec_lcl, UCCommonFilter1.frmdt_lcl, UCCommonFilter1.todt_lcl, ObjectName, profile.DBConnection._constr);
                }
                else if (QueryParameter.ToLower() == "partissue")
                {
                    ObjectName = "PartIssue";
                    Session["ReportHeading"] = "Issue Register";
                    dsCmnRpt = UCCommonFilterClient.GetIssueData(UCCommonFilter1.hfCount_lcl, UCCommonFilter1.hdnIssueSelectedRec_lcl, UCCommonFilter1.hdnProductSelectedRec_lcl, UCCommonFilter1.frmdt_lcl, UCCommonFilter1.todt_lcl, ObjectName, profile.DBConnection._constr);
                }
                else if (QueryParameter.ToLower() == "partreceipt")
                {
                    ObjectName = "partreceipt";
                    Session["ReportHeading"] = "Receipt Register";
                    dsCmnRpt = UCCommonFilterClient.GetReceiptData(UCCommonFilter1.hfCount_lcl, UCCommonFilter1.hdnReceiptSelectedRec_lcl, UCCommonFilter1.hdnProductSelectedRec_lcl, UCCommonFilter1.frmdt_lcl, UCCommonFilter1.todt_lcl, ObjectName, profile.DBConnection._constr);
                }

                Session["ReportDS"] = dsCmnRpt;
                Session["FromDt"] = UCCommonFilter1.frmdt_lcl;
                Session["ToDt"] = UCCommonFilter1.todt_lcl;
                Session["SelObject"] = QueryParameter;

                DataSet ds = new DataSet();
                ds = dsCmnRpt;
                ds.Tables[0].TableName = "dsSiteConsumption";
                ReportDataSource rds = new ReportDataSource
                    (ds.Tables[0].TableName, ds.Tables[0]);
                //Response.Redirect("<script>window.open('../POR/Reports/ReportViewer.aspx', null, 'height=510, width=990,status= 0, resizable= 0, scrollbars=0, toolbar=0,location=0,menubar=0, screenX=0; screenY=0');</script>");
                Response.Redirect("../POR/Reports/ReportViewer.aspx");
            }
            catch (System.Exception ex)
            {
                //Login.Profile.ErrorHandling(ex, this, "CommonReport", "fillDataSet");
            }
            finally
            {
                UCCommonFilterClient.Close();
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            QueryParameter = Request.QueryString["invoker"];

            if (QueryParameter.ToLower() == "partrequest")
            {
                if (UCCommonFilter1.hdnRequestSelectedRec_lcl == "")
                {
                    WebMsgBox.MsgBox.Show("Please Select Request");
                }
                else if (UCCommonFilter1.hdnProductSelectedRec_lcl == "")
                {
                    WebMsgBox.MsgBox.Show("Please Select Product");
                }
                else
                {
                    fillDataSet();
                }
            }


        }

        protected void changecolor(string qrypara)
        {
            switch (qrypara)
            {
                case "partrequest":
                    partrequisition.Attributes.Add("style", "color:Navy");
                    break;
                case "partissue":
                    partissue.Attributes.Add("style", "color:Navy");
                    break;
                case "partreceipt":
                    partreceipt.Attributes.Add("style", "color:Navy");
                    break;
                case "partconsumption":
                    partconsumption.Attributes.Add("style", "color:Navy");
                    break;
                case "monthly":
                    monthly.Attributes.Add("style", "color:Navy");
                    break;
                case "weeklylst":
                    weeklylst.Attributes.Add("style", "color:Navy");
                    break;
                case "consumabletracker":
                    consumabletracker.Attributes.Add("style", "color:Navy");
                    break;
                case "productdtl":
                    productdtl.Attributes.Add("style", "color:Navy");
                    break;
            }
        }

        [WebMethod]
        public static int WMGetReportData(string invoker, string SeletedParts, string SeletedRefIDs, string FromDt, string ToDt, string Site,string ChkAll,string ChkPrd)
        {
            int result = 0;
            DataSet dsCmnRpt = new DataSet();
            iUCCommonFilterClient UCCommonFilterClient = new iUCCommonFilterClient();
            CustomProfile profile = CustomProfile.GetProfile();

            if (invoker.ToLower() == "partconsumption")
            {
                HttpContext.Current.Session["ReportHeading"] = "Consumption Report";
                if (ChkAll!= "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetReportData(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetAllReportData(Site, FromDt, ToDt, profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd != "1")
                {
                  //  dsCmnRpt = UCCommonFilterClient.GetReportDataAllEngine(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll != "1" && ChkPrd == "1")
                {
                //    dsCmnRpt = UCCommonFilterClient.GetReportDataAllPrd(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }

            }
            else if (invoker.ToLower() == "partrequest")
            {
                HttpContext.Current.Session["ReportHeading"] = "Part Requisition Register";
                if (ChkAll != "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetRequisitionData(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetAllRequisitionData(Site,FromDt, ToDt,profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetAllRequisitionDataAllRequest(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll != "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetAllRequisitionDataAllPrd(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
            }
            else if (invoker.ToLower() == "partissue")
            {
                HttpContext.Current.Session["ReportHeading"] = "Issue Register";
                if (ChkAll != "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetIssueData(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetAllIssueData(Site, FromDt, ToDt, profile.DBConnection._constr);
                }
                else if(ChkAll == "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetIssueDataAllIssue(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll != "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetIssueDataAllPrd(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
            }
            else if (invoker.ToLower() == "partreceipt")
            {
                HttpContext.Current.Session["ReportHeading"] = "Receipt Register";
                if (ChkAll != "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetReceiptData(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if(ChkAll == "1" && ChkPrd == "1")
                {
                   dsCmnRpt = UCCommonFilterClient.GetAllReceiptData(Site, FromDt, ToDt, profile.DBConnection._constr);
                }
                else if (ChkAll == "1" && ChkPrd != "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetReceiptDataAllReceipt(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
                else if (ChkAll != "1" && ChkPrd == "1")
                {
                    dsCmnRpt = UCCommonFilterClient.GetReceiptDataAllPrd(Site, SeletedRefIDs, SeletedParts, FromDt, ToDt, "", profile.DBConnection._constr);
                }
            }
            else if (invoker.ToLower() == "monthly")
            {
                HttpContext.Current.Session["ReportHeading"] = "PR-Report Monthly";
                dsCmnRpt = UCCommonFilterClient.GetPenComRequestData(Site, FromDt, ToDt, profile.DBConnection._constr);
            }
            else if (invoker.ToLower() == "weeklylst")
            {
                HttpContext.Current.Session["ReportHeading"] = "Weekly Analysis";
                dsCmnRpt = UCCommonFilterClient.GetWeeklyConsumption(Site,FromDt, ToDt, profile.DBConnection._constr);
            }
            else if (invoker.ToLower() == "consumabletracker")
            {
                HttpContext.Current.Session["ReportHeading"] = "Consumable Tracker";
                dsCmnRpt = UCCommonFilterClient.GetConsumableStock(SeletedRefIDs,Site,FromDt, ToDt, profile.DBConnection._constr);
            }

            else if (invoker.ToLower() == "productdtl")
            {
                HttpContext.Current.Session["ReportHeading"] = "productdtl";
                dsCmnRpt = UCCommonFilterClient.GetProductBalanceOfSite(Site, SeletedParts, ChkPrd, ChkAll,profile.DBConnection._constr);
            }

            else if (invoker.ToLower() == "transfer")
            {
                HttpContext.Current.Session["ReportHeading"] = "transfer";
                dsCmnRpt = UCCommonFilterClient.GetTransferRptData(SeletedParts, SeletedRefIDs, FromDt, ToDt, profile.DBConnection._constr);
            }

            else if (invoker.ToLower() == "asset")
            {
                HttpContext.Current.Session["ReportHeading"] = "asset";
                dsCmnRpt = UCCommonFilterClient.GetAssetRptData(SeletedParts, SeletedRefIDs, FromDt, ToDt, profile.DBConnection._constr);
            }

            dsCmnRpt.Tables[0].TableName = "dsSiteConsumption";
            HttpContext.Current.Session["ReportDS"] = dsCmnRpt;
            HttpContext.Current.Session["FromDt"] = FromDt;
            HttpContext.Current.Session["ToDt"] = ToDt;
            HttpContext.Current.Session["SelObject"] = invoker;


            if (invoker.ToLower() == "partconsumption")
            {
                int EngCount;

                if (ChkAll == "1")
                {
                    EngCount = UCCommonFilterClient.GetEngineCountAll(profile.DBConnection._constr);
                    HttpContext.Current.Session["Generator"] = EngCount;
                }
                else
                {
                    EngCount = UCCommonFilterClient.GetEngineCount(SeletedRefIDs, profile.DBConnection._constr);
                    HttpContext.Current.Session["Generator"] = EngCount;
                }
            }
            
            //DataSet ds = new DataSet();
            //ds = dsCmnRpt;
            //ds.Tables[0].TableName = "dsSiteConsumption";
            //ReportDataSource rds = new ReportDataSource(ds.Tables[0].TableName, ds.Tables[0]);
            result = Convert.ToInt16(dsCmnRpt.Tables[0].Rows.Count);
            return result;
        }

        [WebMethod]
        public static List<mTerritory> WMGetFromSite(long FrmSiteID)
        {
            List<mTerritory> SiteLst = new List<mTerritory>();
            iUCCommonFilterClient UCCommonFilter = new iUCCommonFilterClient();
            CustomProfile profile=CustomProfile.GetProfile();

            SiteLst = UCCommonFilter.GetToSiteName_Transfer(FrmSiteID, profile.DBConnection._constr).ToList();

            return SiteLst;
        }
    }
}