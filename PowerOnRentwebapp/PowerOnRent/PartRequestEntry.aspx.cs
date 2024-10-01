using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.PORServiceUCCommonFilter;
using PowerOnRentwebapp.PORServicePartRequest;
using PowerOnRentwebapp.PORServiceEngineMaster;
using PowerOnRentwebapp.Login;
using System.Web.Services;
using PowerOnRentwebapp.ProductMasterService;
namespace PowerOnRentwebapp.PowerOnRent
{
    public partial class PartRequestEntry : System.Web.UI.Page
    {
        static string ObjectName = "RequestPartDetail";

        #region Page Events`

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillSites();
                if (Session["PORRequestID"] != null)
                {
                    {
                        if (Session["PORRequestID"].ToString() != "0")
                        {
                            lblApprovalDate.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
                            GetRequestHead();
                        }
                        else
                        {
                            WMpageAddNew();
                            ddlStatus.DataSource = WMFillStatus();
                            ddlStatus.DataBind();
                        }
                    }
                }
                divVisibility();
            }
            UC_DateRequestDate.DateIsRequired(true, "", "");

            //Add By Suresh
            ModelPopup1.Hide();
            //Add By Suresh
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile(); if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }            
        }

        //Add By Suresh
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ModelPopup1.Hide();
        }
        //Add By Suresh

        protected void Page_Load(Object sender, EventArgs e)
        {
            UCFormHeader1.FormHeaderText = "Material Request";

            if (!IsPostBack)
            {
                ddlSites.Attributes.Add("onchange", "jsFillUsersList();jsFillEnginList();");
                Toolbar1.SetUserRights("MaterialRequest", "EntryForm", "");
            }

        }
        #endregion

        #region Toolbar Code
        [WebMethod]
        public static void WMpageAddNew()
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                HttpContext.Current.Session["PORRequestID"] = "0";
                HttpContext.Current.Session["PORstate"] = "Add";
                objService.ClearTempDataFromDB(HttpContext.Current.Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, profile.DBConnection._constr);
            }
            catch { }
            finally { objService.Close(); }
        }
        #endregion

        #region Fill DropDown
        protected void FillSites()
        {
            iUCCommonFilterClient objService = new iUCCommonFilterClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                List<mTerritory> SiteList = new List<mTerritory>();
                SiteList = objService.GetSiteNameByUserID(profile.Personal.UserID, profile.DBConnection._constr).ToList();

                ddlSites.DataSource = SiteList;
                ddlSites.DataBind();

                ListItem lst = new ListItem { Text = "-Select-", Value = "0" };
                ddlSites.Items.Insert(0, lst);
            }
            catch { }
            finally { objService.Close(); }
        }

        [WebMethod]
        public static List<PORServicePartRequest.mStatu> WMFillStatus()
        {
            string state = HttpContext.Current.Session["PORstate"].ToString();
            iPartRequestClient objService = new iPartRequestClient();
            List<PORServicePartRequest.mStatu> StatusList = new List<PORServicePartRequest.mStatu>();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();

                if (HttpContext.Current.Session["PORRequestID"].ToString() == "0" && state == "Add")
                {
                    StatusList = objService.GetStatusListForRequest("All,Request", state, profile.Personal.UserID, profile.DBConnection._constr).ToList();
                }
                else if (HttpContext.Current.Session["PORRequestID"].ToString() != "0" && state == "Edit")
                {
                    StatusList = objService.GetStatusListForRequest("All,Request", state, profile.Personal.UserID, profile.DBConnection._constr).ToList();
                }
                else if (HttpContext.Current.Session["PORRequestID"].ToString() != "0" && state == "View")
                {
                    StatusList = objService.GetStatusListForRequest("", "", 0, profile.DBConnection._constr).ToList();
                }

                PORServicePartRequest.mStatu select = new PORServicePartRequest.mStatu() { ID = 0, Status = "-Select-" };
                StatusList.Insert(0, select);
            }
            catch { }
            finally { objService.Close(); }
            return StatusList;
        }

        [WebMethod]
        public static List<vGetUserProfileByUserID> WMFillUserList(long SiteID)
        {
            iUCCommonFilterClient objService = new iUCCommonFilterClient();
            List<vGetUserProfileByUserID> UsersList = new List<vGetUserProfileByUserID>();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                UsersList = objService.GetUserListBySiteID(SiteID, profile.DBConnection._constr).ToList();
                UsersList = UsersList.GroupBy(x => x.userID).Select(x => x.FirstOrDefault()).ToList();
                vGetUserProfileByUserID select = new vGetUserProfileByUserID() { userID = 0, userName = "-Select-" };
                UsersList.Insert(0, select);
            }
            catch { }
            finally { objService.Close(); }
            return UsersList;
        }

        [WebMethod]
        public static List<PORServiceUCCommonFilter.v_GetEngineDetails> WMFillEnginList(long SiteID)
        {
            iUCCommonFilterClient objService = new iUCCommonFilterClient();
            List<PORServiceUCCommonFilter.v_GetEngineDetails> EngineList = new List<PORServiceUCCommonFilter.v_GetEngineDetails>();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                EngineList = objService.GetEngineOfSite(SiteID.ToString(), profile.DBConnection._constr).ToList();
                PORServiceUCCommonFilter.v_GetEngineDetails select = new PORServiceUCCommonFilter.v_GetEngineDetails() { ID = 0, Container = "-Select-" };
                EngineList.Insert(0, select);
            }
            catch { }
            finally { objService.Close(); }
            return EngineList;
        }
        #endregion

        #region RequestHead
        protected void GetRequestHead()
        {
            iPartRequestClient objService = new iPartRequestClient();
            PORtPartRequestHead RequestHead = new PORtPartRequestHead();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                RequestHead = objService.GetRequestHeadByRequestID(Convert.ToInt64(HttpContext.Current.Session["PORRequestID"].ToString()), profile.DBConnection._constr);
                FillGrid1ByRequestID(RequestHead.PRH_ID, Convert.ToInt64(RequestHead.SiteID));

                txtTitle.Text = RequestHead.Title;
                ddlSites.SelectedIndex = ddlSites.Items.IndexOf(ddlSites.Items.FindByValue(RequestHead.SiteID.ToString()));
                lblRequestNo.Text = RequestHead.PRH_ID.ToString();

                ddlStatus.DataSource = WMFillStatus();
                ddlStatus.DataBind();
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "divVisibility123", "divVisibility()");

                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(RequestHead.StatusID.ToString()));
                UC_DateRequestDate.Date = RequestHead.RequestDate;
                ddlRequestType.SelectedIndex = ddlRequestType.Items.IndexOf(ddlRequestType.Items.FindByValue(RequestHead.RequestType.ToString()));
                ddlRequestByUserID.DataSource = WMFillUserList(Convert.ToInt64(RequestHead.SiteID));
                ddlRequestByUserID.DataBind();
                ddlRequestByUserID.SelectedIndex = ddlRequestByUserID.Items.IndexOf(ddlRequestByUserID.Items.FindByValue(RequestHead.RequestBy.ToString()));

                txtRemark.Text = RequestHead.Remark;

                ddlContainer.DataSource = WMFillEnginList(Convert.ToInt64(RequestHead.SiteID));
                ddlContainer.DataBind();
                ddlContainer.SelectedIndex = ddlContainer.Items.IndexOf(ddlContainer.Items.FindByText(RequestHead.Container.ToString()));

                lblEngineModel.Text = RequestHead.EngineModel;
                lblEngineSerial.Text = RequestHead.EngineSerial;
                txtFailureHours.Text = RequestHead.FailureHours;
                txtFailureCause.Text = RequestHead.FailureCause;
                txtFailureNature.Text = RequestHead.FailureNature;


                GetApprovalDetails();
            }
            catch { }
            finally { objService.Close(); }
        }

        [WebMethod]
        public static PORServiceEngineMaster.v_GetEngineDetails WMGetEngineDetails(int EngineID)
        {
            iEngineMasterClient objService = new iEngineMasterClient();
            PORServiceEngineMaster.v_GetEngineDetails EngineRec = new PORServiceEngineMaster.v_GetEngineDetails();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                EngineRec = objService.GetmEngineListByID(EngineID, profile.DBConnection._constr);
            }
            catch { }
            finally { objService.Close(); }
            return EngineRec;
        }

        [WebMethod]
        public static string WMSaveRequestHead(object objReq)
        {
            string result = "";
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();

                PORtPartRequestHead RequestHead = new PORtPartRequestHead();
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary = (Dictionary<string, object>)objReq;

                if (HttpContext.Current.Session["PORRequestID"] != null)
                {
                    if (HttpContext.Current.Session["PORRequestID"].ToString() == "0")
                    {
                        RequestHead.CreatedBy = profile.Personal.UserID;
                        RequestHead.CreationDt = DateTime.Now;
                    }
                    else
                    {
                        RequestHead = objService.GetRequestHeadByRequestID(Convert.ToInt64(HttpContext.Current.Session["PORRequestID"].ToString()), profile.DBConnection._constr);
                        RequestHead.LastModifiedBy = profile.Personal.UserID;
                        RequestHead.LastModifiedDt = DateTime.Now;
                    }

                    RequestHead.SiteID = Convert.ToInt64(dictionary["SiteID"]);
                    RequestHead.RequestNo = dictionary["RequestNo"].ToString();
                    RequestHead.RequestType = dictionary["RequestType"].ToString();
                    RequestHead.StatusID = Convert.ToInt64(dictionary["StatusID"]);
                    RequestHead.Title = dictionary["Title"].ToString();
                    RequestHead.RequestDate = Convert.ToDateTime(dictionary["RequestDate"]);
                    RequestHead.RequestBy = Convert.ToInt64(dictionary["RequestBy"]);
                    RequestHead.Remark = dictionary["Remark"].ToString();
                    RequestHead.FailureCause = dictionary["FailureCause"].ToString();
                    RequestHead.FailureHours = dictionary["FailureHours"].ToString();
                    RequestHead.FailureNature = dictionary["FailureNature"].ToString();
                    RequestHead.EngineSerial = dictionary["EngineSerial"].ToString();
                    RequestHead.EngineModel = dictionary["EngineModel"].ToString();
                    RequestHead.GeneratorModel = dictionary["GeneratorModel"].ToString();
                    RequestHead.GeneratorSerial = dictionary["GeneratorSerial"].ToString();
                    RequestHead.TransformerSerial = dictionary["TransformerSerial"].ToString();
                    RequestHead.Container = dictionary["Container"].ToString();
                    RequestHead.ProbableShippingDate = null;
                    RequestHead.IsSubmit = Convert.ToBoolean(dictionary["IsSubmit"]);

                    long RequestID = objService.SetIntoPartRequestHead(RequestHead, profile.DBConnection._constr);

                    if (RequestID > 0)
                    {
                        objService.FinalSaveRequestPartDetail(HttpContext.Current.Session.SessionID, ObjectName, RequestID, profile.Personal.UserID.ToString(), Convert.ToInt32(RequestHead.StatusID), profile.DBConnection._constr);
                        result = "Request saved successfully";
                    }
                }
            }
            catch { result = "Some error occurred"; }
            finally { objService.Close(); }
            return result;
        }

        protected void divVisibility()
        {
            divApprovalHead.Attributes.Add("style", "display:none");
            divApprovalDetail.Attributes.Add("style", "display:none");

            divIssueHead.Attributes.Add("style", "display:none");
            divIssueDetail.Attributes.Add("style", "display:none");

            divReceiptHead.Attributes.Add("style", "display:none");
            divReceiptDetail.Attributes.Add("style", "display:none");

            //divConsumptionHead.Attributes.Add("style", "display:none");
            //divConsumptionDetail.Attributes.Add("style", "display:none");

            if (ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Approved")) > 0)
            {
                divApprovalHead.Attributes.Add("style", "display:'';");
                divApprovalDetail.Attributes.Add("style", "display:'';");

            }
            if (ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Fully Issued")) > 0)
            {
                divIssueHead.Attributes.Add("style", "display:'';");
                divIssueDetail.Attributes.Add("style", "display:'';");
            }
            if (ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Received")) > 0)
            {
                divReceiptHead.Attributes.Add("style", "display:'';");
                divReceiptDetail.Attributes.Add("style", "display:'';");
            }
            if (ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText("Consumed")) > 0)
            {
                //divConsumptionHead.Attributes.Add("style", "display:'';");
                //divConsumptionDetail.Attributes.Add("style", "display:'';");
            }

            if (ddlStatus.Items.Count > 0)
            {
                if (Convert.ToInt32(ddlStatus.SelectedItem.Value) >= 2)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "changemodeRequest" + Session.SessionID, "changemode(true, 'divRequestDetail');LoadingOff();", true);
                    //disabled
                    Toolbar1.SetSaveRight(false, "Not Allowed");
                    Toolbar1.SetClearRight(false, "Not Allowed");
                }
                //else { ScriptManager.RegisterStartupScript(this, this.GetType(), "changemode" + Session.SessionID, "changemode(false, 'divRequestDetail');LoadingOff();", true); }

                if (Convert.ToInt32(ddlStatus.SelectedItem.Value) >= 3)
                {
                    CheckBoxApproved.Enabled = false;
                    CheckBoxRejected.Enabled = false;
                    txtApprovalRemark.Enabled = false;
                    btnSaveApproval.Attributes.Add("onclick", "showAlert('Not Allowed');");
                    btnSaveApproval.Attributes.Add("class", "Off buttonON");
                }
                else
                {
                    CheckBoxApproved.Enabled = true;
                    CheckBoxRejected.Enabled = true;
                    txtApprovalRemark.Enabled = true;
                    btnSaveApproval.Attributes.Add("onclick", "jsSaveApproval();");
                    btnSaveApproval.Attributes.Add("class", "buttonON");
                }
            }

            if (Session["PORstate"] != null)
            {
                if (Session["PORstate"].ToString() == "Add")
                {
                    CustomProfile profile = CustomProfile.GetProfile();
                    if (ddlSites.Items.Count > 0) ddlSites.SelectedIndex = 1;
                    if (ddlStatus.Items.Count > 0) ddlStatus.SelectedIndex = 1;
                    lblRequestNo.Text = "Generate when Save";
                    UC_DateRequestDate.Date = DateTime.Now;
                    ddlRequestType.SelectedIndex = 1;
                    ddlRequestByUserID.DataSource = null;
                    ddlRequestByUserID.DataBind();
                    ddlRequestByUserID.DataSource = WMFillUserList(Convert.ToInt64(ddlSites.SelectedItem.Value));
                    ddlRequestByUserID.DataBind();
                    ddlRequestByUserID.SelectedIndex = ddlRequestByUserID.Items.IndexOf(ddlRequestByUserID.Items.FindByValue(profile.Personal.UserID.ToString()));
                    ddlContainer.DataSource = null;
                    ddlContainer.DataBind();

                    ddlContainer.DataSource = WMFillEnginList(Convert.ToInt64(ddlSites.SelectedItem.Value));
                    ddlContainer.DataBind();
                }
            }
        }
        #endregion

        #region Request Part Detail
        protected void FillGrid1ByRequestID(long RequestID, long SiteID)
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                List<POR_SP_GetPartDetail_ForRequest_Result> RequestPartList = new List<POR_SP_GetPartDetail_ForRequest_Result>();
                RequestPartList = objService.GetRequestPartDetailByRequestID(RequestID, SiteID, Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, profile.DBConnection._constr).ToList();
                Grid1.DataSource = RequestPartList;
                Grid1.DataBind();
            }
            catch { }
            finally { objService.Close(); }
        }

        protected void Grid1_OnRebind(object sender, EventArgs e)
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                Grid1.DataSource = null;
                Grid1.DataBind();
                CustomProfile profile = CustomProfile.GetProfile();
                HiddenField hdn = (HiddenField)UCProductSearch1.FindControl("hdnProductSearchSelectedRec");
                List<POR_SP_GetPartDetail_ForRequest_Result> RequestPartList = new List<POR_SP_GetPartDetail_ForRequest_Result>();
                if (hdn.Value == "")
                {
                    RequestPartList = objService.GetExistingTempDataBySessionIDObjectName(Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, profile.DBConnection._constr).ToList();
                }
                else if (hdn.Value != "")
                {
                    RequestPartList = objService.AddPartIntoRequest_TempData(hdn.Value, Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, Convert.ToInt32(ddlSites.SelectedItem.Value), profile.DBConnection._constr).ToList();
                }

                //Add by Suresh
                if (hdnprodID.Value != "")
                {
                    RequestPartList = objService.AddPartIntoRequest_TempData(hdnprodID.Value, Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, Convert.ToInt32(ddlSites.SelectedItem.Value), profile.DBConnection._constr).ToList();
                    hdnprodID.Value = "";
                }

                Grid1.DataSource = RequestPartList;
                Grid1.DataBind();
            }
            catch { }
            finally { objService.Close(); }
        }

        [WebMethod]
        public static void WMUpdateRequestQty(object objRequest)
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary = (Dictionary<string, object>)objRequest;
                CustomProfile profile = CustomProfile.GetProfile();

                POR_SP_GetPartDetail_ForRequest_Result PartRequest = new POR_SP_GetPartDetail_ForRequest_Result();
                PartRequest.Sequence = Convert.ToInt64(dictionary["Sequence"]);
                PartRequest.RequestQty = Convert.ToDecimal(dictionary["RequestQty"]);

                objService.UpdatePartRequest_TempData(HttpContext.Current.Session.SessionID, ObjectName, profile.Personal.UserID.ToString(), PartRequest, profile.DBConnection._constr);
            }
            catch { }
            finally { objService.Close(); }
        }

        [WebMethod]
        public static void WMRemovePartFromRequest(Int32 Sequence)
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                CustomProfile profile = CustomProfile.GetProfile();
                objService.RemovePartFromRequest_TempData(HttpContext.Current.Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, Sequence, profile.DBConnection._constr);
            }
            catch { }
            finally { objService.Close(); }
        }

        #endregion

        #region Approval Code
        [WebMethod]
        public static string WMSaveApproval(string ApprovalStatus, string ApprovalRemark)
        {
            iPartRequestClient objService = new iPartRequestClient();
            string result = "";
            try
            {
                long id = Convert.ToInt64(HttpContext.Current.Session["PORRequestID"].ToString());
                CustomProfile profile = CustomProfile.GetProfile();
                result = objService.SaveApprovalStatus(Convert.ToInt64(HttpContext.Current.Session["PORRequestID"].ToString()), ApprovalStatus, ApprovalRemark, profile.Personal.UserID, profile.DBConnection._constr);

                if (result == "true")
                {
                    objService.ClearTempDataFromDB(HttpContext.Current.Session.SessionID, profile.Personal.UserID.ToString(), ObjectName, profile.DBConnection._constr);
                }                
            }
            catch { }
            finally
            { objService.Close(); }
            return result;
        }

        protected void GetApprovalDetails()
        {
            iPartRequestClient objService = new iPartRequestClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                tApprovalDetail ApprovalRec = new tApprovalDetail();
                ApprovalRec = objService.GetApprovalDetailsByReqestID(Convert.ToInt64(Session["PORRequestID"].ToString()), profile.DBConnection._constr);
                if (ApprovalRec != null)
                {
                    CheckBoxApproved.Checked = false; CheckBoxRejected.Checked = false;
                    if (ApprovalRec.Status == "Approved") { CheckBoxApproved.Checked = true; }
                    else if (ApprovalRec.Status == "Rejected") { CheckBoxRejected.Checked = true; }
                    lblApprovalDate.Text = ApprovalRec.ApprovedDate.Value.ToString("dd-MMM-yyyy hh:mm tt");
                    txtApprovalRemark.Text = ApprovalRec.Remark = ApprovalRec.Remark;

                    if (ApprovalRec.ApproverUserID != profile.Personal.UserID)
                    {
                        divApprovalDetail.Disabled = true;
                    }
                }
            }
            catch { }
            finally { objService.Close(); }
        }
        #endregion


         

        #region Add by Suresh 
        

        protected void btnSubmit_Onclick(object sender, EventArgs e)
        {
            //if (txtProductCode.Text == string.Empty)
            //{
            //    WebMsgBox.MsgBox.Show("Please Enter Product Code");
            //}
            if (txtProductName.Text == string.Empty)
            {
                WebMsgBox.MsgBox.Show("Please Enter Product Name");
            }

            try
            {
                string state;
                CustomProfile profile = CustomProfile.GetProfile();
                //if (checkduplicate() == "")
                //{
                    iProductMasterClient productclient = new iProductMasterClient();
                    mProduct obj = new mProduct();

                    state = "AddNew";
                    obj.CreatedBy = profile.Personal.UserID.ToString();
                    obj.CreationDate = DateTime.Now;

                    obj.ProductTypeID = 1;
                    obj.ProductCategoryID = 2;
                    obj.ProductSubCategoryID = 6;
                   // obj.ProductCode = txtProductCode.Text.ToString().Trim();
                    obj.ProductCode = "New Product"+ " " + DateTime.Now.ToString("ddMMyy HHmmss")+" " + profile.Personal.UserID.ToString();

                    obj.Name = txtProductName.Text.ToString().Trim();
                    obj.Description = txtDesc.Text.ToString().Trim();
                    obj.UOMID = 17;
                    obj.PrincipalPrice = 1;
                    obj.FixedDiscount = 0;
                    obj.FixedDiscountPercent =Convert.ToBoolean(0);
                    obj.Installable = Convert.ToBoolean(1);
                    obj.AMC = Convert.ToBoolean(0);
                    obj.WarrantyDays = 0;
                    obj.GuaranteeDays = 0;
                    obj.Active = "Y";

                    hdnprodID.Value = productclient.FinalSaveProductDetailByProductID(obj, profile.DBConnection._constr).ToString();

                    productclient.Close();

                    Grid1_OnRebind(sender,e);
                //}
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "PartRequestEntry", "btnSubmit_Onclick");
            }
            finally
            {
            }
            //txtProductCode.Text = "";
            txtProductName.Text = "";
            txtDesc.Text = "";
        }


        //public string checkduplicate()
        //{
        //    try
        //    {
        //        CustomProfile profile = CustomProfile.GetProfile();
        //        iProductMasterClient productclient = new iProductMasterClient();
        //        string result="";

        //        result = productclient.checkDuplicateRecord(txtProductName.Text.Trim(), profile.DBConnection._constr);
        //        if (result != string.Empty)
        //        {
        //            WebMsgBox.MsgBox.Show(result);
        //        }
        //        txtProductName.Focus();
        //        return result;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Login.Profile.ErrorHandling(ex, this, "PartRequestEntry", "checkDuplicate");
        //        string result = "";
        //        return result;
        //    }
        //    finally
        //    {
        //    }
        //}
        #endregion


    }
}