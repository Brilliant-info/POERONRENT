using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.DashBoard;
using System.Web.UI.DataVisualization.Charting;
using PowerOnRentwebapp.Login;
using PowerOnRentwebapp.PORServiceSiteMaster;
using Microsoft.Reporting.WebForms;
using PowerOnRentwebapp.UserCreationService;
using PowerOnRentwebapp.PORServiceUCCommonFilter;
using PowerOnRentwebapp.PORServicePartRequest;
using PowerOnRentwebapp.PORServicePartIssue;
using PowerOnRentwebapp.PORServicePartReceipts;
using PowerOnRentwebapp.ProductCategoryService;
using PowerOnRentwebapp.UCProductSearchService;
using System.Data;
using System.Collections;

//namespace WebClientElegantCRM.PowerOnRent
  namespace PowerOnRentwebapp.PowerOnRent
{
    public partial class UCCommonFilter : System.Web.UI.UserControl
    {
        public string hfCount_lcl, hdnEngineSelectedRec_lcl, hdnProductSelectedRec_lcl, frmdt_lcl, todt_lcl, hdnRequestSelectedRec_lcl, hdnIssueSelectedRec_lcl, hdnReceiptSelectedRec_lcl, hdnProductCategory_lcl;

        protected void Page_Load(object sender, EventArgs e)
        {
            hndGroupByGrid.Value = GVEngineInfo.GroupBy;
            hndGroupByPrd.Value = GVProductInfo.GroupBy;
            if (!IsPostBack)
            {
                fillsite();
                fillCategory();
                GVRequestInfo_OnRebind(sender, e);
                GVEngineInfo_OnRebind(sender, e);
                GVIssueInfo_OnRebind(sender, e);
                GVReceiptInfo_OnRebind(sender, e);
                GVProductInfo_OnRebind(sender, e);
                FrmDate.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                To_Date.Date = DateTime.Now.Date;
            }

            hfCount_lcl = hfCount.Value;
            hdnEngineSelectedRec_lcl = hdnEngineSelectedRec.Value;
            hdnProductSelectedRec_lcl = hdnProductSelectedRec.Value;
            frmdt_lcl = FrmDate.Date.Value.ToString("yyyy/MM/dd");
            todt_lcl = To_Date.Date.Value.ToString("yyyy/MM/dd");
            hdnRequestSelectedRec_lcl = hdnRequestSelectedRec.Value;
            hdnIssueSelectedRec_lcl = hdnIssueSelectedRec.Value;
            hdnReceiptSelectedRec_lcl = hdnReceiptSelectedRec.Value;
            hdnProductCategory_lcl = hdnProductCategory.Value;
        }

        public void fillsite()
        {
            iUCCommonFilterClient UCCommonFilter = new iUCCommonFilterClient();
            CustomProfile profile = CustomProfile.GetProfile();
            ddlSite.DataSource = UCCommonFilter.GetSiteNameByUserID(profile.Personal.UserID, profile.DBConnection._constr);
            ddlSite.DataBind();
            ListItem lst = new ListItem();
            lst.Text = "--Select--";
            lst.Value = "0";
            ddlSite.Items.Insert(0, lst);
            ListItem l = new ListItem();
            l.Text = "Select All";
            l.Value = "1";
            ddlSite.Items.Insert(1, l);

            ddlFrmSite.DataSource = UCCommonFilter.GetSiteNameByUserID_Transfer(profile.Personal.UserID, profile.DBConnection._constr);
            ddlFrmSite.DataBind();
            ListItem lstfrm = new ListItem();
            lstfrm.Text = "--Select--";
            lstfrm.Value = "0";
            ddlFrmSite.Items.Insert(0, lstfrm);
        }

        public void fillCategory()
        {
            iUCCommonFilterClient UCCommonFilter = new iUCCommonFilterClient();
            iProductCategoryMasterClient ProductCategory = new iProductCategoryMasterClient();
            CustomProfile profile = CustomProfile.GetProfile();
            ddlCategory.DataSource = ProductCategory.GetProductCategoryList(profile.DBConnection._constr);
            ddlCategory.DataBind();
            ListItem lst1 = new ListItem();
            lst1.Text = "--Select--";
            lst1.Value = "0";
            ddlCategory.Items.Insert(0, lst1);
        }

        public void fillDetail()
        {
            iUCCommonFilterClient UCCommonFilter = new iUCCommonFilterClient();
            iPartRequestClient PartRequest = new iPartRequestClient();
            iPartIssueClient PartIssue = new iPartIssueClient();
            iPartReceiptClient PartReceipt = new iPartReceiptClient();
            CustomProfile profile = CustomProfile.GetProfile();

            if (ddlSite.SelectedIndex >= -1)
            {

                if (Request.QueryString["invoker"] == "partrequest")
                {
                    try
                    {
                        List<POR_SP_GetRequestBySiteIDsOrUserID_Result> RequestList = new List<POR_SP_GetRequestBySiteIDsOrUserID_Result>();
                        List<POR_SP_GetRequestBySiteIDsOrUserID_Result> FinalRequestList = new List<POR_SP_GetRequestBySiteIDsOrUserID_Result>();

                        //GVRequestInfo.DataSource = null;
                        //GVRequestInfo.DataBind();

                        RequestList = PartRequest.GetRequestSummayBySiteIDs(hfCount.Value, profile.DBConnection._constr).ToList();
                        RequestList = RequestList.Where(l => (l.RequestDate >= FrmDate.Date)).ToList();
                        RequestList = RequestList.Where(l => (l.RequestDate <= To_Date.Date)).ToList();
                        //if (txtRequestSearch.Text != "")
                        //{
                        //    FinalRequestList = RequestList.Where(e => e.RequestNo.Contains(txtRequestSearch.Text) || e.RequestByUserName.Contains(txtRequestSearch.Text)).ToList();
                        //    RequestList = new List<POR_SP_GetRequestBySiteIDsOrUserID_Result>();
                        //    RequestList = FinalRequestList;
                        //}
                        //GVRequestInfo.DataSource = RequestList;
                        //GVRequestInfo.DataBind();

                        if (hdnRequestSelectedRec.Value == "0")
                        {
                            GVRequestInfo.SelectedRecords = new ArrayList();                            
                            foreach (POR_SP_GetRequestBySiteIDsOrUserID_Result rec in RequestList)
                            {
                                Hashtable row = new Hashtable();
                                row["PRH_ID"] = rec.PRH_ID;
                                row["RequestDate"] = rec.RequestDate;
                                row["RequestByUserName"] = rec.RequestByUserName;
                                GVRequestInfo.SelectedRecords.Add(row);
                                if (hdnRequestSelectedRec.Value != "") { hdnRequestSelectedRec.Value = hdnRequestSelectedRec.Value + "," + rec.PRH_ID.ToString(); }
                                else if (hdnRequestSelectedRec.Value == "") { hdnRequestSelectedRec.Value = rec.PRH_ID.ToString(); }
                            }
                        }
                        GVRequestInfo.DataSource = RequestList;
                        GVRequestInfo.DataBind();
                    }
                    catch { }
                    finally { PartRequest.Close(); }
                }
                else
                    if (Request.QueryString["invoker"] == "partconsumption")
                    {
                        try
                        {
                            //  UCProductSearchService.iUCProductSearchClient productSearchService = new UCProductSearchService.iUCProductSearchClient();

                           // GVEngineInfo.DataSource = null;
                           // GVEngineInfo.DataBind();

                            List<v_GetEngineDetails> EngineList = new List<v_GetEngineDetails>();
                            List<v_GetEngineDetails> FinalEngineList = new List<v_GetEngineDetails>();
                            EngineList = UCCommonFilter.GetEngineOfSite(hfCount.Value, profile.DBConnection._constr).ToList();
                            //if (txtEngineSearch.Text != "")
                            //{
                            //    FinalEngineList = EngineList.Where(e => e.EngineSerial.Contains(txtEngineSearch.Text) || e.GeneratorSerial.Contains(txtEngineSearch.Text)).ToList();
                            //    EngineList = new List<v_GetEngineDetails>();
                            //    EngineList = FinalEngineList;
                            //}

                            //GVEngineInfo.DataSource = EngineList;
                            //GVEngineInfo.GroupBy = hndGroupByGrid.Value;
                            //if (!Page.IsPostBack) { GVEngineInfo.GroupBy = "ProductCategory"; }
                            //GVEngineInfo.DataBind();
                            //productSearchService.Close();
                            //ID EngineSerial Container  EngineModel  EngineSerial GeneratorModel Territory
                            if (hdnEngineSelectedRec.Value == "0")
                            {
                                GVEngineInfo.SelectedRecords = new ArrayList();
                                foreach (v_GetEngineDetails rec in EngineList)
                                {
                                    Hashtable row = new Hashtable();

                                    row["ID"] = rec.ID;
                                    row["EngineSerial"] = rec.EngineSerial;
                                    row["Container"] = rec.Container;
                                    row["EngineModel"] = rec.EngineModel;
                                    row["EngineSerial"] = rec.EngineSerial;
                                    row["GeneratorModel"] = rec.GeneratorModel;
                                    row["Territory"] = rec.Territory;
                                    GVEngineInfo.SelectedRecords.Add(row);
                                    if (hdnEngineSelectedRec.Value != "") { hdnEngineSelectedRec.Value = hdnEngineSelectedRec.Value + "," + rec.ID.ToString(); }
                                    else if (hdnEngineSelectedRec.Value == "") { hdnEngineSelectedRec.Value = rec.ID.ToString(); }
                                }
                            }
                            GVEngineInfo.DataSource = EngineList;
                            GVEngineInfo.DataBind();

                        }
                        catch { }
                        finally { UCCommonFilter.Close(); }
                    }
                    else
                        if (Request.QueryString["invoker"] == "partissue")
                        {
                            try
                            {
                                List<POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result> IssueList = new List<POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result>();
                                List<POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result> FinalList = new List<POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result>();

                                //GVIssueInfo.DataSource = null;
                                //GVIssueInfo.DataBind();

                                IssueList = PartIssue.GetIssueSummayBySiteIDs(hfCount.Value, profile.DBConnection._constr).ToList();
                                IssueList = IssueList.Where(i => (i.IssueDate >= FrmDate.Date)).ToList();
                                IssueList = IssueList.Where(i => (i.IssueDate <= To_Date.Date)).ToList();
                                //if (txtIssueSearch.Text != "")
                                //{
                                //    FinalList = IssueList.Where(e => e.IssueNo.Contains(txtIssueSearch.Text) || e.IssuedByUserName.Contains(txtIssueSearch.Text)).ToList();
                                //    IssueList = new List<POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result>();
                                //    IssueList = FinalList;
                                //}
                                //GVIssueInfo.DataSource = IssueList;
                                //GVIssueInfo.DataBind();

                                if (hdnIssueSelectedRec.Value == "0")
                                {
                                    GVIssueInfo.SelectedRecords = new ArrayList();
                                    foreach (POR_SP_GetIssueSummaryBySiteIDsOrUserIDOrRequestIDOrIssueIDs_Result rec in IssueList)
                                    {
                                        Hashtable row = new Hashtable();
                                        //MINH_ID IssueDate IssuedByUserName
                                        row["MINH_ID"] = rec.MINH_ID;
                                        row["IssueDate"] = rec.IssueDate;
                                        row["IssuedByUserName"] = rec.IssuedByUserName;                                       
                                        GVIssueInfo.SelectedRecords.Add(row);
                                        if (hdnIssueSelectedRec.Value != "") { hdnIssueSelectedRec.Value = hdnIssueSelectedRec.Value + "," + rec.MINH_ID.ToString(); }
                                        else if (hdnIssueSelectedRec.Value == "") { hdnIssueSelectedRec.Value = rec.MINH_ID.ToString(); }
                                    }
                                }
                                GVIssueInfo.DataSource = IssueList;
                                GVIssueInfo.DataBind();

                            }
                            catch { }
                            finally { PartIssue.Close(); }
                        }
                        else
                            if (Request.QueryString["invoker"] == "partreceipt")
                            {
                                try
                                {
                                    List<POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result> ReceiptList = new List<POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result>();
                                    List<POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result> FinalReceiptList = new List<POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result>();

                                    //GVReceiptInfo.DataSource = null;
                                    //GVReceiptInfo.DataBind();

                                    ReceiptList = PartReceipt.GetReceiptSummaryBySiteIDs(hfCount.Value, profile.DBConnection._constr).ToList();
                                    ReceiptList = ReceiptList.Where(i => (i.GRN_Date >= FrmDate.Date)).ToList();
                                    ReceiptList = ReceiptList.Where(i => (i.GRN_Date <= To_Date.Date)).ToList();
                                    //if (txtReceiptSearch.Text != "")
                                    //{
                                    //    FinalReceiptList = ReceiptList.Where(e => e.GRNNo.Contains(txtReceiptSearch.Text) || e.ReceiptByUserName.Contains(txtReceiptSearch.Text)).ToList();
                                    //    ReceiptList = new List<POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result>();
                                    //    ReceiptList = FinalReceiptList;
                                    //}
                                    //GVReceiptInfo.DataSource = ReceiptList;
                                    //GVReceiptInfo.DataBind();

                                    if (hdnReceiptSelectedRec.Value == "0")
                                    {
                                        GVReceiptInfo.SelectedRecords = new ArrayList();
                                        foreach (POR_SP_GetReceiptSummaryBySiteIDsOrUserIDOrRequestID_Result rec in ReceiptList)
                                        {
                                            Hashtable row = new Hashtable();
                                            //GRNH_ID GRN_Date ReceiptByUserName
                                            row["GRNH_ID"] = rec.GRNH_ID;
                                            row["GRN_Date"] = rec.GRN_Date;
                                            row["ReceiptByUserName"] = rec.ReceiptByUserName;
                                            GVReceiptInfo.SelectedRecords.Add(row);
                                            if (hdnReceiptSelectedRec.Value != "") { hdnReceiptSelectedRec.Value = hdnReceiptSelectedRec.Value + "," + rec.GRNH_ID.ToString(); }
                                            else if (hdnReceiptSelectedRec.Value == "") { hdnReceiptSelectedRec.Value = rec.GRNH_ID.ToString(); }
                                        }
                                    }
                                    GVReceiptInfo.DataSource = ReceiptList;
                                    GVReceiptInfo.DataBind();

                                }
                                catch { }
                                finally { PartReceipt.Close(); }

                            }
            }
        }

        public void fillProduct()
        {
            iUCCommonFilterClient UCCommonFilter = new iUCCommonFilterClient();
            CustomProfile profile = CustomProfile.GetProfile();
            GVProductInfo.DataSource = null;
            GVProductInfo.DataBind();
            try
            {
                //UCProductSearchService.iUCProductSearchClient productSearchService = new UCProductSearchService.iUCProductSearchClient();
                //List<GetProductDetail> ProductList = new List<GetProductDetail>();
                //List<GetProductDetail> FinalProductList = new List<GetProductDetail>();
                DataSet prdlist = new DataSet();

                GVProductInfo.DataSource = null;
                GVProductInfo.DataBind();

                if (Request.QueryString["invoker"] == "partconsumption")
                {
                    if (hdnEngineSelectedRec.Value == "")
                    {
                        GVProductInfo.DataSource = null;
                        GVProductInfo.DataBind();
                    }
                    else
                    {                    
                        var frmdt = FrmDate.Date.ToString();
                        var todt = To_Date.Date.ToString();

                        
                        prdlist = UCCommonFilter.GetProductOfSelectedEngine(hdnEngineSelectedRec.Value, hdnFilterText.Value, frmdt, todt, profile.DBConnection._constr);
                        if (hdnProductSelectedRec.Value == "0")
                        {
                            GVProductInfo.SelectedRecords = new ArrayList();
                            foreach (DataRow rec in prdlist.Tables[0].Rows)
                            {
                                Hashtable row = new Hashtable();
                                //row["ID"] = rec.ID;
                                row["ID"] = rec["ID"];
                                //row["ProductCode"] = rec.ProductCode;
                                row["ProductCode"] = rec["ProductCode"];
                                //row["Name"] = rec.Name;
                                row["Name"] = rec["Name"];
                                GVProductInfo.SelectedRecords.Add(row);
                                if (hdnProductSelectedRec.Value != "") { hdnProductSelectedRec.Value = hdnProductSelectedRec.Value + "," + ID.ToString(); }
                                else if (hdnProductSelectedRec.Value == "") { hdnProductSelectedRec.Value = ID.ToString(); }
                            }
                        }
                        GVProductInfo.DataSource = prdlist;
                        GVProductInfo.DataBind();
                    }
                }
                else if (Request.QueryString["invoker"] == "partrequest")
                {
                    if (hdnRequestSelectedRec.Value == "")
                    {
                        GVProductInfo.DataSource = null;
                        GVProductInfo.DataBind();
                    }
                    else
                    {
                        prdlist = UCCommonFilter.GetProductofRequest(hdnRequestSelectedRec.Value, hdnFilterText.Value, profile.DBConnection._constr);

                        if (hdnProductSelectedRec.Value == "0")
                        {
                            GVProductInfo.SelectedRecords = new ArrayList();
                            foreach (DataRow rec in prdlist.Tables[0].Rows)
                            {
                                Hashtable row = new Hashtable();                    
                                //row["ID"] = rec.ID;
                                row["ID"] = rec["ID"];
                                //row["ProductCode"] = rec.ProductCode;
                                row["ProductCode"] = rec["ProductCode"];
                                //row["Name"] = rec.Name;
                                row["Name"] = rec["Name"];
                                GVProductInfo.SelectedRecords.Add(row);
                                if (hdnProductSelectedRec.Value != "") { hdnProductSelectedRec.Value = hdnProductSelectedRec.Value + "," + ID.ToString(); }
                                else if (hdnProductSelectedRec.Value == "") { hdnProductSelectedRec.Value = ID.ToString(); }
                            }
                        }
                        
                        GVProductInfo.DataSource = prdlist;
                        GVProductInfo.DataBind();
                    }
                }
                else if (Request.QueryString["invoker"] == "partissue")
                {
                    if (hdnIssueSelectedRec.Value == "")
                    {
                        GVProductInfo.DataSource = null;
                        GVProductInfo.DataBind();
                    }

                    else
                    {
                        prdlist = UCCommonFilter.GetProductofIssue(hdnIssueSelectedRec.Value, hdnFilterText.Value, profile.DBConnection._constr);
                        if (hdnProductSelectedRec.Value == "0")
                        {
                            GVProductInfo.SelectedRecords = new ArrayList();
                            foreach (DataRow rec in prdlist.Tables[0].Rows)
                            {
                                Hashtable row = new Hashtable();
                                //row["ID"] = rec.ID;
                                row["ID"] = rec["ID"];
                                //row["ProductCode"] = rec.ProductCode;
                                row["ProductCode"] = rec["ProductCode"];
                                //row["Name"] = rec.Name;
                                row["Name"] = rec["Name"];
                                GVProductInfo.SelectedRecords.Add(row);
                                if (hdnProductSelectedRec.Value != "") { hdnProductSelectedRec.Value = hdnProductSelectedRec.Value + "," + ID.ToString(); }
                                else if (hdnProductSelectedRec.Value == "") { hdnProductSelectedRec.Value = ID.ToString(); }
                            }
                        }
                        GVProductInfo.DataSource = prdlist;
                        GVProductInfo.DataBind();
                    }
                }
                else if (Request.QueryString["invoker"] == "partreceipt")
                {
                    if (hdnReceiptSelectedRec.Value == "")
                    {
                        GVProductInfo.DataSource = null;
                        GVProductInfo.DataBind();
                    }
                    else
                    {
                        prdlist = UCCommonFilter.GetProductofReceipt(hdnReceiptSelectedRec.Value, hdnFilterText.Value, profile.DBConnection._constr);
                        if (hdnProductSelectedRec.Value == "0")
                        {
                            GVProductInfo.SelectedRecords = new ArrayList();
                            foreach (DataRow rec in prdlist.Tables[0].Rows)
                            {
                                Hashtable row = new Hashtable();
                                //row["ID"] = rec.ID;
                                row["ID"] = rec["ID"];
                                //row["ProductCode"] = rec.ProductCode;
                                row["ProductCode"] = rec["ProductCode"];
                                //row["Name"] = rec.Name;
                                row["Name"] = rec["Name"];
                                GVProductInfo.SelectedRecords.Add(row);
                                if (hdnProductSelectedRec.Value != "") { hdnProductSelectedRec.Value = hdnProductSelectedRec.Value + "," + ID.ToString(); }
                                else if (hdnProductSelectedRec.Value == "") { hdnProductSelectedRec.Value = ID.ToString(); }
                            }
                        }
                        GVProductInfo.DataSource = prdlist;
                        GVProductInfo.DataBind();
                    }
                }

                else if (Request.QueryString["invoker"] == "productdtl")
                {
                    List<GetPrdDetail> PrdList = new List<GetPrdDetail>();

                    PrdList = UCCommonFilter.AllProductOnSite(profile.DBConnection._constr).ToList();

                    if (hdnProductSelectedRec.Value == "0")
                    {
                       
                            GVProductInfo.SelectedRecords = new ArrayList();
                            foreach (GetPrdDetail rec in PrdList)
                            {
                                Hashtable row = new Hashtable();
                                row["ID"] = rec.ID;
                                row["ProductCode"] = rec.ProductCode;
                                row["Name"] = rec.Name;
                                GVProductInfo.SelectedRecords.Add(row);
                                if (hdnProductSelectedRec.Value != "") { hdnProductSelectedRec.Value = hdnProductSelectedRec.Value + "," + ID.ToString(); }
                                else if (hdnProductSelectedRec.Value == "") { hdnProductSelectedRec.Value = ID.ToString(); }
                            }
                      }
                    if (hdnFilterText.Value != "")
                    {
                        try
                        {
                            iUCProductSearchClient productSearchService = new iUCProductSearchClient();
                            CustomProfile profile1 = CustomProfile.GetProfile();
                            List<GetProductDetail> SProductList = new List<GetProductDetail>();
                            SProductList = productSearchService.GetProductList1(GVProductInfo.CurrentPageIndex, hdnFilterText.Value, profile1.DBConnection._constr).ToList();

                            GVProductInfo.DataSource = SProductList;
                            GVProductInfo.DataBind();
                            productSearchService.Close();
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                    else
                    {

                        GVProductInfo.DataSource = PrdList;
                        GVProductInfo.DataBind();
                    }

                }
            }

            catch (SystemException ex)
            {
            }

        }

        protected void GVEngineInfo_OnRebind(object sender, EventArgs e)
        {
            if (Request.QueryString["invoker"] == "partconsumption")
            {
                fillDetail();
            }
        }

        protected void GVRequestInfo_OnRebind(object sender, EventArgs e)
        {
            if (Request.QueryString["invoker"] == "partrequest")
            {
                fillDetail();
            }
        }

        protected void GVIssueInfo_OnRebind(object sender, EventArgs e)
        {
            if (Request.QueryString["invoker"] == "partissue")
            {
                fillDetail();
            }
        }

        protected void GVReceiptInfo_OnRebind(object sender, EventArgs e)
        {
            if (Request.QueryString["invoker"] == "partreceipt")
            {
                fillDetail();
            }
        }

        protected void GVProductInfo_OnRebind(object sender, EventArgs e)
        {
            fillProduct();
        }

        public void GridVisibleTF(string invoker)
        {
            tblProduct.Attributes.Add("style", "display:table;");
            if (invoker == "partconsumption")
            {
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblEngine.Attributes.Add("style", "display:table;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "partrequest")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:table;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "partissue")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:table;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "partreceipt")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:table;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "monthly")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:none;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "weeklylst")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:none;");
                //SiteList.Attributes.Add("style", "display:none;");
                PrdCategory.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "consumabletracker")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:none;");
                //SiteList.Attributes.Add("style", "display:none;");

                ExcludeZero.Attributes.Add("style", "display:none;");

                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");

            }

            else if (invoker == "productdtl")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:table;");
                PrdCategory.Attributes.Add("style", "display:none;");
                FDate.Attributes.Add("style", "display:none;");
                TDate.Attributes.Add("style", "display:none;");
                ExcludeZero.Attributes.Add("style", "display:table;");
                frmSite.Attributes.Add("style", "display:none;");
                toSite.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "transfer")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:none;");
                PrdCategory.Attributes.Add("style", "display:none;");               
                ExcludeZero.Attributes.Add("style", "display:none;");
                frmSite.Attributes.Add("style", "display:table;");
                toSite.Attributes.Add("style", "display:table;");
                SiteList.Attributes.Add("style", "display:none;");
            }
            else if (invoker == "asset")
            {
                tblEngine.Attributes.Add("style", "display:none;");
                tblRequest.Attributes.Add("style", "display:none;");
                tblIssue.Attributes.Add("style", "display:none;");
                tblReceipt.Attributes.Add("style", "display:none;");
                tblProduct.Attributes.Add("style", "display:none;");
                PrdCategory.Attributes.Add("style", "display:none;");
                ExcludeZero.Attributes.Add("style", "display:none;");
                frmSite.Attributes.Add("style", "display:table;");
                toSite.Attributes.Add("style", "display:table;");
                SiteList.Attributes.Add("style", "display:none;");
            }

        }

        public void GridVisible()
        {
            tblRequest.Attributes.Add("style", "display:none;");
            tblEngine.Attributes.Add("style", "display:none;");
            tblProduct.Attributes.Add("style", "display:none;");
            tblIssue.Attributes.Add("style", "display:none;");
            tblReceipt.Attributes.Add("style", "display:none");
        }

    }
}