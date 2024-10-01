using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PowerOnRentwebapp.ApprovalLevelMasterService;
using Obout.Interface;
using System.Collections;
using PowerOnRentwebapp.Login;
using WebMsgBox;
using System.Web.Services;
using PowerOnRentwebapp.ServiceTerritory;
using PowerOnRentwebapp.Territory;
namespace PowerOnRentwebapp.Approval
{
    public partial class ApprovalLevelMaster : System.Web.UI.Page
    {

        ApprovalLevelMasterService.iApprovalLevelMasterClient ApprovalClient = new ApprovalLevelMasterService.iApprovalLevelMasterClient();

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCFormHeader1.FormHeaderText = "Approval Master";
            if (!IsPostBack)
            {
                BindApprovalGrid();
                BindUserGrid();
                BinddlObjectNameDDL();
                hdnApprovalID.Value = null;
                setActiveTab(0);
            }
            this.UCToolbar1.ToolbarAccess("ApprovalLevelMaster");
            this.UCToolbar1.evClickAddNew += pageAddNew;
            this.UCToolbar1.evClickSave += pageSave;
            this.UCToolbar1.evClickClear += pageClear;
        }
        protected void setActiveTab(int ActiveTab)
        {
            Button btnSave = (Button)UCToolbar1.FindControl("btnSave");
            if (btnSave != null) btnSave.Enabled = false;
            if (ActiveTab == 0)
            {
                tabApproval.Visible = true;
                panApprovalDetail.Visible = false;
                tabApprovalLevelMaster.ActiveTabIndex = 0;
            }
            else
            {
                tabApproval.Visible = true;
                panApprovalDetail.Visible = true;
                tabApprovalLevelMaster.ActiveTabIndex = 1;
                if (btnSave != null) btnSave.Enabled = true;
            }
        }

        protected void BindApprovalGrid()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                gvApprovalLevelM.DataSource = ApprovalClient.GetApprovalRecordToBindGrid(profile.DBConnection._constr);
                gvApprovalLevelM.DataBind();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Approval Level Master", "BindApprovalGrid");
            }
            finally
            {
            }
        }

        protected void BindUserGrid()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                gvUserCreation.DataSource = ApprovalClient.GetUserListForEditbySP(0, profile.DBConnection._constr);
                gvUserCreation.DataBind();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Approval Level Master", "BindUserGrid");
            }
            finally
            {
            }
        }

        protected void BinddlObjectNameDDL()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                ddlObjectName.DataSource = ApprovalClient.GetObjectList(profile.DBConnection._constr);
                ddlObjectName.DataBind();
                ListItem lst = new ListItem();
                lst.Text = "-Select-";
                lst.Value = "0";
                ddlObjectName.Items.Insert(0, lst);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Approval Level Master", "BinddlObjectNameDDL");
            }
            finally
            {
            }
        }

        [WebMethod]
        public static string PMGetApprovalLevelByObjectName(string objectName, long territoryID)
        {
            iApprovalLevelMasterClient ApprovalClient = new iApprovalLevelMasterClient();
            string NewLevel = "";
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                NewLevel = ApprovalClient.GetApprovalLevelMax(objectName, territoryID, profile.DBConnection._constr).ToString();
            }
            catch (System.Exception ex)
            { Login.Profile.ErrorHandling(ex, "Approval Level Master", "PMGetApprovalLevelByObjectName"); }
            finally
            { ApprovalClient.Close(); }
            return NewLevel;
        }

        protected void clear()
        {
            hdnApprovalID.Value = null;
            ddlObjectName.SelectedIndex = -1;
            lblApprovalLevel.Text = "";
            txtApprovalNo.Text = "";
            //ddlMinApproval.Items.Clear();
            //ddlMinApproval.SelectedIndex = -1;
            //chkIsApproval.Checked = false;
            //txtMaxAmount.Text = "";
            rbtnYes.Checked = true;
            rbtnNo.Checked = false;
            hdnStatus.Value = "";
            setActiveTab(1);
            BindUserGrid();
        }

        protected void pageAddNew(Object sender, ToolbarService.iUCToolbarClient e)
        {
            clear();

            //tabApprovalLevelMaster.ActiveTabIndex = 1;
        }

        protected void pageSave(Object sender, ToolbarService.iUCToolbarClient e)
        {
            try
            {
                string[] strings = new string[] { };
                strings = hdnApprovalUserID.Value.Split(',');

                if (strings.Length.ToString() == txtApprovalNo.Text)
                {
                    CustomProfile profile = CustomProfile.GetProfile();
                    mApprovalLevel ObjApproval = new mApprovalLevel();

                    if (hdnStatus.Value == "Edit")
                    {
                        ObjApproval = ApprovalClient.GetApprovalRecordByID(Convert.ToInt32(hdnApprovalID.Value), profile.DBConnection._constr);
                    }
                    ObjApproval.ObjectName = ddlObjectName.SelectedValue;
                    ObjApproval.ApprovalLevel = Convert.ToByte(lblApprovalLevel.Text);
                    ObjApproval.NoOfApprovers = Convert.ToByte(txtApprovalNo.Text);
                    //ObjApproval.MinApprovalReq = Convert.ToByte(ddlMinApproval.SelectedValue);
                    ObjApproval.MinApprovalReq = Convert.ToByte(txtApprovalNo.Text);
                    //if (chkIsApproval.Checked == true)
                    //{ ObjApproval.IsLowerLevelApprovalReq = true; }
                    //else
                    //{ ObjApproval.IsLowerLevelApprovalReq = false; }
                    ObjApproval.IsLowerLevelApprovalReq = true;
                    //ObjApproval.MaxAmount = Convert.ToDecimal(txtMaxAmount.Text);
                    ObjApproval.MaxAmount = 0;
                    if (rbtnYes.Checked == true)
                    { ObjApproval.Active = "Y"; }
                    else
                    { ObjApproval.Active = "N"; }

                    // hdnApprovalUserID.Value = "";
                    string UserId = hdnApprovalUserID.Value;
                    mApprovalLevelDetail ObjApprovalDetail = new mApprovalLevelDetail();

                    ObjApprovalDetail.Active = "Y";
                    ObjApprovalDetail.CreatedBy = profile.Personal.UserID.ToString();
                    ObjApprovalDetail.CreationDate = DateTime.Now;
                    ObjApprovalDetail.LastModifiedBy = profile.Personal.UserID.ToString();
                    ObjApprovalDetail.LastModifiedDate = DateTime.Now;
                    ObjApprovalDetail.CompanyID = profile.Personal.CompanyID; ;
                    if (hdnStatus.Value != "Edit")
                    {
                        ObjApproval.CreatedBy = profile.Personal.UserID.ToString();
                        ObjApproval.CreationDate = DateTime.Now;
                        int result = ApprovalClient.InsertmApprovalLevel(ObjApproval, profile.DBConnection._constr);
                        ObjApprovalDetail.ApprovalLevelID = result;
                        if (hdnApprovalUserID.Value != "")
                        {
                            //ApprovalClient.SaveApprovalLevelDetail(hdnApprovalUserID.Value, result, ObjApprovalDetail);
                            ApprovalClient.SaveApprovalLevelDetail(UserId, result, ObjApprovalDetail, profile.DBConnection._constr);

                        }
                        if (result != 0)
                        {
                            WebMsgBox.MsgBox.Show("Record saved successfully");
                        }
                    }
                    if (hdnStatus.Value == "Edit")
                    {
                        ObjApproval.LastModifiedBy = profile.Personal.UserID.ToString();
                        ObjApproval.LastModifiedDate = DateTime.Now;
                        int result = ApprovalClient.updatemApprovalLevel(ObjApproval, profile.DBConnection._constr);
                        ObjApprovalDetail.ApprovalLevelID = Convert.ToInt32(hdnApprovalID.Value);
                        if (hdnApprovalUserID.Value != "")
                        {
                            // ApprovalClient.SaveApprovalLevelDetail(hdnApprovalUserID.Value, Convert.ToInt32(hdnApprovalID.Value), ObjApprovalDetail);
                            ApprovalClient.SaveApprovalLevelDetail(UserId, Convert.ToInt32(hdnApprovalID.Value), ObjApprovalDetail, profile.DBConnection._constr);
                        }
                        if (hdnApprovalUserID.Value == "")
                        {
                            ApprovalClient.SaveApprovalLevelDetail("0", Convert.ToInt32(hdnApprovalID.Value), ObjApprovalDetail, profile.DBConnection._constr);
                        }
                        if (result == 1)
                        {
                            WebMsgBox.MsgBox.Show("Record updated successfully");
                        }
                    }
                    clear();
                    BindApprovalGrid();
                    hdnStatus.Value = "";
                    hdnApprovalUserID.Value = "";
                }
                else
                {
                    if (strings.Length > Convert.ToInt64(txtApprovalNo.Text))
                    {
                        WebMsgBox.MsgBox.Show("You can't select more than " + txtApprovalNo.Text + " users");
                    }
                    else
                    {
                        WebMsgBox.MsgBox.Show("You must select " + txtApprovalNo.Text + " users");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Approval Level Master", "pageSave");
            }
            finally
            {
            }
        }

        protected void pageClear(Object sender, ToolbarService.iUCToolbarClient e)
        { clear(); }


        protected void gvApprovalLevelM_Select(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                rbtnNo.Checked = false;
                rbtnYes.Checked = false;
                Hashtable selectedrec = (Hashtable)gvApprovalLevelM.SelectedRecords[0];
                hdnApprovalID.Value = selectedrec["ID"].ToString();
                lblApprovalLevel.Text = selectedrec["ApprovalLevel"].ToString();
                ddlObjectName.SelectedIndex = ddlObjectName.Items.IndexOf(ddlObjectName.Items.FindByValue(selectedrec["ObjectName"].ToString()));
                txtApprovalNo.Text = selectedrec["NoOfApprovers"].ToString();

                if (selectedrec["Active"].ToString() == "No")
                { rbtnNo.Checked = true; }
                else
                { rbtnYes.Checked = true; }

                List<SP_GetUserForApprovalMaster_Result> getlst = new List<SP_GetUserForApprovalMaster_Result>();
                getlst = ApprovalClient.GetUserListForEditbySP(Convert.ToInt32(hdnApprovalID.Value), profile.DBConnection._constr).ToList();
                gvUserCreation.DataSource = getlst;
                gvUserCreation.DataBind();

                foreach (SP_GetUserForApprovalMaster_Result item in getlst)
                {
                    hdnApprovalUserID.Value = item.SelectedRec;
                    break;
                }
                //tabApprovalLevelMaster.ActiveTabIndex = 1;
                setActiveTab(1);
                hdnStatus.Value = "Edit";
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Approval Level Master", "gvApprovalLevelM_Select");
            }
            finally
            {
            }
        }

        #region Fill Territory
        [WebMethod]
        public static List<mTerritory> PMFillddlLevel(long level, long parentID)
        {
            List<mTerritory> TerritoryList = new List<mTerritory>();
            try
            {
                UC_Territory uc_territory = new UC_Territory();
                TerritoryList = uc_territory.GetTerritoryList(level, parentID).ToList();
            }
            catch { }
            finally { }
            return TerritoryList;
        }
        #endregion
    }
}
