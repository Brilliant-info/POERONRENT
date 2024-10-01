using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.CompanySetupService;

namespace PowerOnRentwebapp.POR.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }
        protected void ShowReport()
        {

            DataSet ds = new DataSet();
            if (Session["ReportDS"] != null)
            {
                string Teststr;
                Teststr = Session["SelObject"].ToString();

                ds = (DataSet)Session["ReportDS"];
                if (ds.Tables[0].TableName == "dsPartRequisitions")
                {

                    ReportDataSource rds = new ReportDataSource(ds.Tables[0].TableName, ds.Tables[0]);

                    RptViewer1.LocalReport.DataSources.Clear();
                    RptViewer1.LocalReport.DataSources.Add(rds);


                    //if (Teststr == "PartRequisition")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/PartRequestList.rdlc";
                    //}
                    //else if (Session["SelObject"].ToString() == "PartIssue")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/PartIssueList.rdlc";
                    //}
                    //else if (Session["SelObject"].ToString() == "PartReceipt")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/PartReceiptList.rdlc";
                    //}
                    //else if (Session["SelObject"].ToString() == "PartConsumption")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/PartConsumptionList.rdlc";
                    //}
                    //else if (Session["SelObject"].ToString() == "PartStock")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/PartStockList.rdlc";
                    //}
                    //else if (Session["SelObject"].ToString() == "SiteWiseConsumption")
                    //{
                    //    RptViewer1.LocalReport.ReportPath = "POR/Reports/SiteWiseConsumption.rdlc";
                    //}

                    RptViewer1.LocalReport.SetParameters(RptParameters());
                    RptViewer1.ShowParameterPrompts = false;
                    RptViewer1.ShowPromptAreaButton = false;
                    RptViewer1.LocalReport.Refresh();
                }
                else if (ds.Tables[0].TableName == "dsSiteConsumption")
                {
                    ReportDataSource rds1 = new ReportDataSource(ds.Tables[0].TableName, ds.Tables[0]);

                    RptViewer1.LocalReport.DataSources.Clear();
                    RptViewer1.LocalReport.DataSources.Add(rds1);

                    if (Session["SelObject"].ToString() == "partconsumption")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/SiteWiseConsumption.rdlc";
                    }

                    else if (Session["SelObject"].ToString() == "partrequest")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/PartRequestList.rdlc";
                    }

                    else if (Session["SelObject"].ToString() == "partissue")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/PartIssueList.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "partreceipt")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/PartReceiptList.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "monthly")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/PrReportMonthly.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "weeklylst")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/WeeklyAnalysis.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "consumabletracker")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/ConsumableTracker.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "productdtl")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/ProductBalance.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "transfer")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/TransferRpt.rdlc";
                    }
                    else if (Session["SelObject"].ToString() == "asset")
                    {
                        RptViewer1.LocalReport.ReportPath = "POR/Reports/AssetTransferRpt.rdlc";
                    }


                    if (Session["SelObject"].ToString() == "productdtl")
                    {
                    }
                    else if (Session["SelObject"].ToString() == "partconsumption")
                    {
                        RptViewer1.LocalReport.SetParameters(RptParameters1());
                    }
                    else
                    {
                        RptViewer1.LocalReport.SetParameters(RptParameters());
                    }
                    RptViewer1.ShowParameterPrompts = false;
                    RptViewer1.ShowPromptAreaButton = false;
                    RptViewer1.LocalReport.Refresh();
                }
            }
        }
        private List<ReportParameter> RptParameters()
        {
            CustomProfile profile = CustomProfile.GetProfile();
            List<ReportParameter> parameters = new List<ReportParameter>();
            mCompany compdetails = new mCompany();
            iCompanySetupClient compclient = new iCompanySetupClient();
            compdetails = compclient.GetCompanyById(profile.Personal.CompanyID, profile.DBConnection._constr);
            parameters.Add(new ReportParameter("CompName", compdetails.Name));
            parameters.Add(new ReportParameter("CompAdd", compdetails.AddressLine1));
            parameters.Add(new ReportParameter("FromDt", Session["FromDt"].ToString()));
            parameters.Add(new ReportParameter("ToDt", Session["ToDt"].ToString()));
            parameters.Add(new ReportParameter("ReportHeading", Session["ReportHeading"].ToString()));
            // parameters.Add(new ReportParameter("CompLogo","../MasterPage/Logo/" + compdetails.LogoPath));
            return parameters;
        }
        private List<ReportParameter> RptParameters1()
        {
            CustomProfile profile = CustomProfile.GetProfile();
            List<ReportParameter> parameters = new List<ReportParameter>();
            mCompany compdetails = new mCompany();
            iCompanySetupClient compclient = new iCompanySetupClient();
            compdetails = compclient.GetCompanyById(profile.Personal.CompanyID, profile.DBConnection._constr);
            parameters.Add(new ReportParameter("CompName", compdetails.Name));
            parameters.Add(new ReportParameter("CompAdd", compdetails.AddressLine1));
            parameters.Add(new ReportParameter("FromDt", Session["FromDt"].ToString()));
            parameters.Add(new ReportParameter("ToDt", Session["ToDt"].ToString()));
            parameters.Add(new ReportParameter("ReportHeading", Session["ReportHeading"].ToString()));
            parameters.Add(new ReportParameter("Generator", Session["Generator"].ToString()));
            // parameters.Add(new ReportParameter("CompLogo","../MasterPage/Logo/" + compdetails.LogoPath));
            return parameters;
        }
    }
}