using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using PowerOnRentwebapp.DesignationService;
using PowerOnRentwebapp.RoleMasterService;
using PowerOnRentwebapp.UserCreationService;
using System.Web.Services;
using PowerOnRentwebapp.Login;
using System.Web.Security;
using WebMsgBox;
using Obout.Grid;
using PowerOnRentwebapp.ServiceTerritory;
using PowerOnRentwebapp.Territory;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace PowerOnRentwebapp.UserManagement
{

    public partial class UserCreation : System.Web.UI.Page
    {
        static string sessionID = "";

        #region UserForm
        #region PageCode
        protected void Page_PreInit(Object sender, EventArgs e)
        { CustomProfile profile = CustomProfile.GetProfile(); if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            UCAddress1.DefaultAddressColumn(true, false, "Default", "Shipping");
            UCFormHeader1.FormHeaderText = "User Creation";
            sessionID = Session.SessionID;

            TextBox txtstartdate = (TextBox)UC_DateofBirth.FindControl("txtDate");
            TextBox txtenddate = (TextBox)UC_Dateofjoining.FindControl("txtDate");

            txtstartdate.Attributes.Add("onchange", "validateDate('" + txtstartdate.ClientID + "','" + txtenddate.ClientID + "','Start','Birth Date Should Not Be Less Than Registration Date')");
            txtenddate.Attributes.Add("onchange", "validateDate('" + txtstartdate.ClientID + "','" + txtenddate.ClientID + "','End','Registration Date Should Be Greater Than Birth Date')");
            if (IsPostBack != true)
            {
                ActiveTab("");
                BindDepartment();
                BindGrid();
                BindReportingTo();
                ResetUserControl(0);

                if (profile.Personal.CompanyID == 14)
                {
                    Button btnExport = (Button)UCToolbar1.FindControl("btnExport");
                    btnExport.Visible = false;
                    Button btnImport = (Button)UCToolbar1.FindControl("btnImport");
                    btnImport.Visible = false;
                    Button btmMail = (Button)UCToolbar1.FindControl("btmMail");
                    btmMail.Visible = false;
                    Button btnPrint = (Button)UCToolbar1.FindControl("btnPrint");
                    btnPrint.Visible = false;
                }
            }
            this.UCToolbar1.ToolbarAccess("UserCreation");
            this.UCToolbar1.evClickSave += pageSave;
            this.UCToolbar1.evClickAddNew += pageAddNew;
            this.UCToolbar1.evClickClear += pageClear;

            //HtmlTable tbl = (HtmlTable)UC_Territory1.FindControl("tblUCTerritory_UserList");
            UC_Territory1.VisiableUserList = false;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (ddlRoleList.Items.Count >= 1)
            {
                //ListItem lst1 = ddlRoleList.Items[1];
               // lst1.Attributes.Add("style", "color:red");
            }
        }

        #endregion PageCode

        #region Toolbar Code
        protected void pageAddNew(Object sender, ToolbarService.iUCToolbarClient e)
        {
            ClearAll();
            ResetUserControl(0);
            FillRoleDropDown();
            GridRoleConfiguration.DataSource = null;
            GridRoleConfiguration.DataBind();

            GridRoleConfiguration.GroupBy = "DisplayModuleName,DisplayPhaseName";
            GridRoleConfiguration.ShowHeader = true;
            //GridRoleConfiguration.HideColumnsWhenGrouping = true;
            lblPassword.Visible = lblConfirmPass.Visible = true;
            txtLoginId1.Visible = txtPassword1.Visible = txtConfirmPassword.Visible = true;
            req_txtLoginId.Visible = req_txtPassword.Visible = rfValtxtConfirmPassword.Visible = cmpValtxtPassword.Visible = true;

            ActiveTab("Add");
            UC_Territory1.BindListviewWithGroupTitle();
        }

        protected void pageClear(Object sender, ToolbarService.iUCToolbarClient e)
        { if (hndstate.Value == "Edit") { GetUserByID(); } else { ClearAll(); FillRoleDropDown(); ResetUserControl(0); } }

        protected void pageSave(Object sender, ToolbarService.iUCToolbarClient e)
        {
            try
            {
                bool chkDuplicate_aspnetmember = false;

                if (hndstate.Value != "Edit")
                {
                    if (Membership.GetUser(txtLoginId1.Text.Trim()) != null) { chkDuplicate_aspnetmember = true; }
                }

                if (chkDuplicate_aspnetmember == true)
                {
                    txtLoginId1.Text = "";
                    MsgBox.Show("Login name already exist");
                }
                else if (chkDuplicate_aspnetmember == false)
                {
                    iUserCreationClient userClient = new iUserCreationClient();
                    if (checkDuplicate() == "")
                    {

                        UserCreationService.mUserProfileHead objuser = new UserCreationService.mUserProfileHead();
                        CustomProfile profile = CustomProfile.GetProfile();


                        if (hndstate.Value == "Edit")
                        { objuser = userClient.GetUserByID(Convert.ToInt64(hnduserID.Value), profile.DBConnection._constr); }
                        objuser.RoleID = 0;
                        if (ddlRoleList.SelectedIndex > 1) { objuser.RoleID = Convert.ToInt64(ddlRoleList.SelectedItem.Value); }
                        objuser.FirstName = txtFirstName.Text.Trim();
                        objuser.MiddelName = txtMiddleName.Text.Trim();
                        objuser.LastName = txtLastName.Text.Trim();
                        objuser.EmployeeID = txtEmpNo.Text.Trim();
                        objuser.DepartmentID = Convert.ToInt64(ddlDepartment.SelectedValue);
                        //iDesignationMasterClient DesignationMasterClient = new iDesignationMasterClient();
                        //long i = DesignationMasterClient.GetDesignationIDByName((hndDesignationValue.Value), profile.DBConnection._constr);

                        //Add By Suresh
                        if (hndDesignationValue.Value == "")
                        {
                            ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(objuser.DesignationID.ToString()));
                            objuser.DesignationID = Convert.ToInt64(ddlDesignation.SelectedIndex);
                        }
                        else
                        {
                            objuser.DesignationID = Convert.ToInt64(hndDesignationValue.Value);
                        }

                        objuser.DateOfJoining = UC_Dateofjoining.Date;
                        objuser.DateOfBirth = UC_DateofBirth.Date;
                        objuser.PhoneNo = txtPhone.Text.Trim();
                        objuser.MobileNo = txtMobile.Text.Trim();
                        objuser.EmailID = txtEmail.Text.Trim();
                        objuser.ReportingTo = ddlReportingTo.SelectedValue;
                        objuser.UserType = ddlUserType.SelectedValue;
                        objuser.Gender = ddlUserGender.SelectedValue;
                        objuser.InterestedIn = txtinstrated.Text.Trim();
                        objuser.Hobbies = "";
                        objuser.OtherID = txtotherID.Text.Trim();
                        objuser.HighestQualification = txtHighestQuali.Text.Trim();
                        objuser.CollegeOrUniversity = "";
                        objuser.HighSchool = "";
                        objuser.Remark = "";
                        objuser.Active = true;
                        if (rbtnNo.Checked == true) objuser.Active = false;
                        objuser.CompanyID = profile.Personal.CompanyID;
                        objuser.ProfileImg = (byte[])Session["ProfileImg"];
                        objuser.DefaultAddress = UCAddress1.BillingSeq.Trim();



                        if (hndstate.Value != "Edit")
                        {
                            hndRoleSate.Value = "";
                            objuser.CreatedBy = profile.Personal.UserID.ToString();
                            objuser.CreationDate = DateTime.Now;
                            hnduserID.Value = userClient.InsertUserCreation(objuser, profile.DBConnection._constr).ToString();
                            Membership.CreateUser(txtLoginId1.Text, txtPassword1.Text, txtEmail.Text);
                            CreateProfile(txtLoginId1.Text, Convert.ToInt64(hnduserID.Value));
                        }
                        else if (hndstate.Value == "Edit")
                        {
                            hndRoleSate.Value = "Edit";
                            objuser.LastModifiedBy = profile.Personal.UserID.ToString();
                            objuser.LastModifiedDate = DateTime.Now;
                            hnduserID.Value = userClient.UpdateUserProfile(objuser, profile.DBConnection._constr).ToString();
                            //var u = Membership.GetUser(txtLoginId.Text.Trim());
                            //u.Email = txtEmail.Text;
                            //u.ChangePassword(u.GetPassword(), txtPassword.Text);                      
                        }

                        if (hnduserID.Value != "0" && hnduserID.Value != "")
                        {
                            UCAddress1.FinalSaveAddress(Address.ReferenceObjectName.User, Convert.ToInt64(hnduserID.Value));
                            //UC_AddressInformation1.FinalSaveToDBttAddress(Convert.ToInt64(hnduserID.Value));
                            bool roelSaveResult = false;
                            if (ddlRoleList.SelectedIndex == -1 || ddlRoleList.SelectedIndex == 0) roelSaveResult = userClient.FinalSaveUserRoles(getSessionList().ToArray(), profile.Personal.UserID.ToString(), Convert.ToInt64(hnduserID.Value), profile.Personal.CompanyID, 0, profile.DBConnection._constr);
                            if (ddlRoleList.SelectedIndex > 1) roelSaveResult = userClient.FinalSaveUserRoles(getSessionList().ToArray(), profile.Personal.UserID.ToString(), Convert.ToInt64(hnduserID.Value), profile.Personal.CompanyID, Convert.ToInt64(ddlRoleList.SelectedItem.Value), profile.DBConnection._constr);
                            if (hdnSelectedLocation.Value != "")
                            {
                                userClient.SaveUsersLocationDetails(Convert.ToInt64(hnduserID.Value), (ddlDesignation.SelectedIndex + 1), hdnSelectedLocation.Value, profile.Personal.UserID.ToString(), profile.DBConnection._constr);
                            }
                            if (roelSaveResult == true)
                                if (hndstate.Value != "Edit") MsgBox.Show("Record save successfully");
                            if (hndstate.Value == "Edit") MsgBox.Show("Record update successfully");

                            hndstate.Value = "Edit";
                            BindGrid();
                            lblPassword.Visible = lblConfirmPass.Visible = false;
                            txtLoginId1.Visible = txtPassword1.Visible = txtConfirmPassword.Visible = false;
                            req_txtLoginId.Visible = req_txtPassword.Visible = rfValtxtConfirmPassword.Visible = cmpValtxtPassword.Visible = false;
                        }
                    }
                    userClient.Close();
                }
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "pageSave");
            }
        }

        protected void ActiveTab(string state)
        {

            if (state == "Add" || state == "Edit")
            {
                TabPanelUsersList.Visible = true;
                TabContainerUserCreation1.ActiveTabIndex = 1;
                TabPanelUserInformation.Visible = true;
                TabPanelAddressInfo.Visible = true;
                TabPanelRoleConfiguration.Visible = true;
            }
            else
            {
                TabPanelUsersList.Visible = true;
                TabContainerUserCreation1.ActiveTabIndex = 0;
                TabPanelUserInformation.Visible = false;
                TabPanelAddressInfo.Visible = false;
                TabPanelRoleConfiguration.Visible = false;

            }
        }
        #endregion

        #region FillDropDown
        public void BindReportingTo()
        {
            iUserCreationClient userClient = new iUserCreationClient();
            CustomProfile profile = CustomProfile.GetProfile();
            ddlReportingTo.DataSource = userClient.GetUserCreationList(profile.DBConnection._constr);
            ddlReportingTo.DataBind();
            userClient.Close();

            ListItem lst = new ListItem();
            lst.Text = "-Select-";
            lst.Value = "0";
            ddlReportingTo.Items.Insert(0, lst);
        }
        public void BindDepartment()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                DepartmentService.iDepartmentMasterClient DepartmentService = new DepartmentService.iDepartmentMasterClient();
                ddlDepartment.DataSource = DepartmentService.GetDeparmentList(profile.DBConnection._constr);
                ddlDepartment.DataBind();
                ListItem lst = new ListItem();
                lst.Text = "-Select-";
                lst.Value = "0";
                ddlDepartment.Items.Insert(0, lst);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "BindDepartment");

            }
            finally
            {
            }
        }

        [WebMethod]
        public static List<DesignationService.mDesignation> PMfillDesignation(int departmentID)
        {
            DesignationService.iDesignationMasterClient DesignationService = new DesignationService.iDesignationMasterClient();
            List<DesignationService.mDesignation> DesignationList = new List<DesignationService.mDesignation>();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                DesignationList = DesignationService.GetDesignationListByDepartmentID(departmentID, profile.DBConnection._constr).ToList();
                DesignationService.mDesignation select = new DesignationService.mDesignation() { ID = 0, Name = "-Select-" };
                DesignationList.Insert(0, select);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, "User Creation", "PMfillDesignation");
            }
            finally
            { DesignationService.Close(); }
            return DesignationList;
        }
        #endregion

        #region DropDownSelectedIndexChanged
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlDesignation.DataSource = null;
                ddlDesignation.DataBind();
                int did = Convert.ToInt32(ddlDepartment.SelectedValue);
                //BindDesignation(did);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "ddlDepartment_SelectedIndexChanged");

            }
            finally
            {
            }
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e) { FillRoleDropDown(); }
        #endregion

        #region GVUserCreationCode
        protected void gvUserCreationM_Select(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            try
            {
                hndRoleSate.Value = "Edit";
                Hashtable selectedrec = (Hashtable)gvUserCreationM.SelectedRecords[0];
                hnduserID.Value = selectedrec["userID"].ToString();
                FillRoleDropDown();
                GetUserByID();
                ActiveTab("Edit");
                lblPassword.Visible = lblConfirmPass.Visible = false;
                txtLoginId1.Visible = txtPassword1.Visible = txtConfirmPassword.Visible = false;
                req_txtLoginId.Visible = req_txtPassword.Visible = rfValtxtConfirmPassword.Visible = cmpValtxtPassword.Visible = false;
                //BindRoleDetailsGridView();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "gvUserCreationM_Select");

            }
            finally
            {
            }
        }
        private void GetUserByID()
        {
            iUserCreationClient userClient = new iUserCreationClient();
            try
            {
                string LocationList = "";
                Session["ProfileImg"] = null;
                UC_Territory1.BindListviewWithGroupTitle();

                CustomProfile profile = CustomProfile.GetProfile();
                UserCreationService.mUserProfileHead objuser = new UserCreationService.mUserProfileHead();

                objuser = userClient.GetUserByID(Convert.ToInt64(hnduserID.Value), profile.DBConnection._constr);
                LocationList = userClient.GetLocationListByUserID(objuser.ID, profile.DBConnection._constr);

                ResetUserControl(Convert.ToInt64(hnduserID.Value));
                //UC_AddressInformation1.FillAddressByObjectNameReferenceID(Convert.ToInt64(hnduserID.Value));
                UCAddress1.FillAddressByObjectNameReferenceID("User", Convert.ToInt64(hnduserID.Value), "User");
                txtFirstName.Text = objuser.FirstName;
                txtMiddleName.Text = objuser.MiddelName;
                txtLastName.Text = objuser.LastName;
                txtEmpNo.Text = objuser.EmployeeID;
                ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByValue(objuser.DepartmentID.ToString()));
                ddlUserType.SelectedValue = objuser.UserType;
                ddlReportingTo.SelectedIndex = ddlReportingTo.Items.IndexOf(ddlReportingTo.Items.FindByValue(objuser.ReportingTo.ToString()));

              //  ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(objuser.DesignationID.ToString()));

                lblAsgLocation.Text = LocationList;
                if (ddlDepartment.SelectedValue != "0")
                {
                    ddlDesignation.DataSource = null;
                    ddlDesignation.DataBind();
                    ddlDesignation.DataSource = PMfillDesignation(Convert.ToInt16(ddlDepartment.SelectedValue));
                    ddlDesignation.DataBind();
                    //BindDesignation(Convert.ToInt16(ddlDepartment.SelectedValue));
                    //ddlDesignation.SelectedValue = objuser.DesignationID.ToString();
                    ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(objuser.DesignationID.ToString()));
                    FillRoleDropDown();
                    //if (objuser.RoleID == 0) { ddlRoleList.SelectedIndex = 1; }
                    //else { 
                    ddlRoleList.SelectedIndex = ddlRoleList.Items.IndexOf(ddlRoleList.Items.FindByValue(objuser.RoleID.Value.ToString()));
                   //}
                    hndRoleSate.Value = "Edit";
                    hndstate.Value = "Edit";
                    BindRoleDetailsGridView();
                }
                UC_Dateofjoining.Date = objuser.DateOfJoining;
                UC_DateofBirth.Date = objuser.DateOfBirth;
                txtEmail.Text = objuser.EmailID;
                txtPhone.Text = objuser.PhoneNo;
                txtMobile.Text = objuser.MobileNo;
                txtHighestQuali.Text = objuser.HighestQualification;
                txtinstrated.Text = objuser.InterestedIn;
                txtotherID.Text = objuser.OtherID;
                if (objuser.Active.ToString() == "True")
                { rbtnYes.Checked = true; rbtnNo.Checked = false; }
                else { rbtnYes.Checked = false; rbtnNo.Checked = true; }

                ddlUserGender.SelectedValue = objuser.Gender;
                if (objuser.ProfileImg != null)
                {
                    Session["ProfileImg"] = objuser.ProfileImg;
                    Img1.Src = "../Image.aspx";
                }
                else
                {
                    Img1.Src = "../App_Themes/Blue/img/Male.png";
                    if (objuser.Gender == "F")
                        Img1.Src = "../App_Themes/Blue/img/Female.png";

                }
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "GetUserByID");
            }
            finally
            {
                userClient.Close();
            }
        }

        public void BindGrid()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                iUserCreationClient userClient = new iUserCreationClient();
                //gvUserCreationM.DataSource = userClient.GetUserCreationList(profile.DBConnection._constr);
                gvUserCreationM.DataSource = userClient.GetUserList(profile.DBConnection._constr);
                gvUserCreationM.DataBind();
                userClient.Close();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "GetUserByID");
            }

        }
        #endregion
        #endregion

        private void ResetUserControl(long referenceID)
        {
            try
            {
                if (hnduserID.Value.ToString() == "")
                {
                    hnduserID.Value = "0";
                }
                CustomProfile profile = CustomProfile.GetProfile();
                //UC_AddressInformation1.ResetAddress("User", Convert.ToInt64(hnduserID.Value), profile.Personal.UserID.ToString(), Session.SessionID, "UserCreation");
                UCAddress1.ClearAddress("User");
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "GetUserByID");

            }
            finally
            {
            }
        }

        public string checkDuplicate()
        {
            try
            {
                string result = "";
                CustomProfile profile = CustomProfile.GetProfile();
                if (txtEmpNo.Text != "")
                {
                    iUserCreationClient userClient = new iUserCreationClient();
                    if (hnduserID.Value == string.Empty)
                    {
                        result = userClient.checkDuplicateRecord(txtEmpNo.Text, profile.DBConnection._constr);
                        userClient.Close();
                        if (result != string.Empty)
                        {
                            WebMsgBox.MsgBox.Show(result);
                            txtEmpNo.Text = "";
                        }

                    }
                    else
                    {
                        int id = Convert.ToInt32(hnduserID.Value);
                        result = userClient.checkDuplicateRecordEdit(txtEmpNo.Text, id, profile.DBConnection._constr);
                        userClient.Close();
                        if (result != string.Empty)
                        {
                            WebMsgBox.MsgBox.Show(result);
                            txtEmpNo.Text = "";
                        }
                    }
                }
                return result;
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "checkDuplicate");
                string result = "";
                return result;
            }
            finally
            {
            }
        }

        private void ClearAll()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtEmpNo.Text = "";
            ddlDepartment.SelectedIndex = -1;
            //BindDesignation(Convert.ToInt16(ddlDepartment.SelectedValue));
            ddlDesignation.SelectedIndex = -1;
            UC_Dateofjoining.Date = null;
            UC_DateofBirth.Date = null;
            txtEmail.Text = ""; ;
            txtPhone.Text = "";
            txtMobile.Text = "";
            GridRoleConfiguration.DataSource = null;
            GridRoleConfiguration.DataBind();
            rbtnYes.Checked = true;
            txtLoginId1.Text = "";
            hndstate.Value = "";
            hnduserID.Value = "";
            txtHighestQuali.Text = "";
            txtotherID.Text = "";

            txtinstrated.Text = "";
            ddlUserType.SelectedIndex = -1;
            ddlReportingTo.SelectedIndex = -1;
            ddlUserGender.SelectedIndex = -1;
            txtPassword1.Text = "";
            //lblPassword.Text = "";
            ActiveTab("Add");
        }

        #region RoleConfiguration

        protected void BindRoleDetailsGridView()
        {
            UserCreationService.iUserCreationClient UserCreationService = new UserCreationService.iUserCreationClient();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                GridRoleConfiguration.DataSource = null;
                GridRoleConfiguration.DataBind();

                List<SP_GetUserRoleDetail_Result> sessionList = new List<SP_GetUserRoleDetail_Result>();
                RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
                if (hndRoleSate.Value != "Edit")
                {
                    if (Convert.ToInt32(hdnDDLRoleSelectedValue.Value) > 1)
                    {
                        sessionList = UserCreationService.GetDataToBindRoleMasterDetailsByRoleID(Convert.ToInt32(hdnDDLRoleSelectedValue.Value), 0, profile.Personal.CompanyID, profile.DBConnection._constr).ToList();
                    }
                    else if (Convert.ToInt32(hdnDDLRoleSelectedValue.Value) == 1)
                    {
                        sessionList = UserCreationService.GetDataToBindRoleMasterDetailsByRoleID(1, 0, profile.Personal.CompanyID, profile.DBConnection._constr).ToList();
                    }
                    GridRoleConfiguration.GroupBy = "DisplayModuleName,DisplayPhaseName";
                    GridRoleConfiguration.ShowHeader = true;
                }

                if (hndRoleSate.Value == "Edit")
                {
                    sessionList = UserCreationService.GetDataToBindRoleMasterDetailsByRoleID(0, Convert.ToInt64(hnduserID.Value), profile.Personal.CompanyID, profile.DBConnection._constr).ToList();
                    hndRoleSate.Value = "";
                }


                if (sessionList != null)
                {
                    if (sessionList.Count > 0)
                    {
                        GridRoleConfiguration.DataSource = sessionList;
                        GridRoleConfiguration.DataBind();
                        Session.Add("sessionRoleList", sessionList);
                    }
                }
                roleMasterService.Close();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "BindRoleDetailsGridView");
            }
            finally
            {
                UserCreationService.Close();
            }
        }

        [WebMethod]
        public static void UpdateRole(object role, object rowIndex)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary = (Dictionary<string, object>)role;

            SP_GetUserRoleDetail_Result updateRole = new SP_GetUserRoleDetail_Result();
            updateRole.mSequence = Convert.ToInt64(dictionary["mSequence"]);
            updateRole.pSequence = Convert.ToInt64(dictionary["pSequence"]);
            updateRole.oSequence = Convert.ToInt64(dictionary["oSequence"]);

            //updateRole.Add = Convert.ToBoolean(dictionary["Add"]);
            //updateRole.Edit = Convert.ToBoolean(dictionary["Edit"]);
            //updateRole.View = Convert.ToBoolean(dictionary["View"]);
            //updateRole.Delete = Convert.ToBoolean(dictionary["Delete"]);
            //updateRole.Approval = Convert.ToBoolean(dictionary["Approval"]);
            //updateRole.AssignTask = Convert.ToBoolean(dictionary["AssignTask"]);
            updateRole.Add = Convert.ToBoolean(dictionary["Add"]);
            if (updateRole.Add == true) { updateRole.Edit = true; updateRole.View = true; }
            else { updateRole.Edit = false; }
            //updateRole.View = true;
            updateRole.Delete = false;
            updateRole.Approval = Convert.ToBoolean(dictionary["Approval"]);
            if (updateRole.Approval == true) { updateRole.View = true; }
            updateRole.AssignTask = Convert.ToBoolean(dictionary["AssignTask"]);
            if (updateRole.AssignTask == true) { updateRole.View = true; }
            if (updateRole.Add == true && updateRole.Approval == false && updateRole.AssignTask == false && Convert.ToBoolean(dictionary["View"]) == true)
            { updateRole.View = true; }

            UserCreationService.iUserCreationClient UserCreationService = new UserCreationService.iUserCreationClient();
            HttpContext.Current.Session["sessionRoleList"] = UserCreationService.UpdateRoleIntoSessionList(getSessionList().ToArray(), updateRole, Convert.ToInt32(rowIndex)).ToList();
            UserCreationService.Close();
        }

        protected static List<SP_GetUserRoleDetail_Result> getSessionList()
        {
            List<SP_GetUserRoleDetail_Result> sessionList = new List<SP_GetUserRoleDetail_Result>();
            if (HttpContext.Current.Session["sessionRoleList"] != null) sessionList = (List<SP_GetUserRoleDetail_Result>)HttpContext.Current.Session["sessionRoleList"];
            return sessionList;
        }

        [WebMethod]
        public static List<vGetRoleMasterData> PMfillRoleDDL(long DepartmentID, long DesignationID)
        {
            RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
            List<vGetRoleMasterData> rolelist = new List<vGetRoleMasterData>();
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                rolelist = roleMasterService.GetRoleMasterListByDepartmentIDDesignationID(DepartmentID, DesignationID, profile.DBConnection._constr).ToList();

            }
            catch { }
            finally { roleMasterService.Close(); }
            return rolelist;
        }

        protected void FillRoleDropDown()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                ddlRoleList.DataSource = null;
                ddlRoleList.DataBind();
                ddlRoleList.Items.Clear();

                if (ddlDepartment.SelectedIndex > 0 && ddlDesignation.SelectedIndex > 0)
                {

                    RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
                    ddlRoleList.DataSource = roleMasterService.GetRoleMasterListByDepartmentIDDesignationID(Convert.ToInt64(ddlDepartment.SelectedItem.Value), Convert.ToInt64(ddlDesignation.SelectedItem.Value), profile.DBConnection._constr);
                    ddlRoleList.DataBind();
                   // roleMasterService.Close();
                    //ListItem lst = new ListItem { Text = "-Select-", Value = "0" };
                    //ddlRoleList.Items.Insert(0, lst);
                    //ListItem lst1 = new ListItem { Text = "Custom", Value = "0.1" };
                    //ddlRoleList.Items.Insert(1, lst1);

                }

            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "User Creation", "FillRoleDropDown");

            }
            finally
            {
            }
        }

        protected void ddlRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRoleDetailsGridView();
        }

        #endregion RoleConfiguration

        protected void CreateProfile(string LoginName, long userID)
        {
            CustomProfile Cprofile = CustomProfile.GetProfile();
            CustomProfile profile = CustomProfile.GetProfile(LoginName);

            //profile.DBConnection._constr[0] = Cprofile.DBConnection._constr[0];
            //profile.DBConnection._constr[1] = Cprofile.DBConnection._constr[1];
            //profile.DBConnection._constr[2] = Cprofile.DBConnection._constr[2];
            //profile.DBConnection._constr[3] = Cprofile.DBConnection._constr[3];

            profile.DBConnection._constr[0] = "10.1.1.4,6601"; //"GWCQA.db.11040877.hostedresource.com";
            profile.DBConnection._constr[1] = "elegantcrm7";//"GWCQA";
            profile.DBConnection._constr[2] = "Password321#";
            profile.DBConnection._constr[3] = "sa";



            //profile.Personal.UserID = userID;
            profile.Personal.UserID = userID;
            profile.Personal.UserName = txtFirstName.Text + " " + txtLastName.Text;
            profile.Personal.Gender = "";
            profile.Personal.UserType = ddlUserType.SelectedValue;
            if (UC_DateofBirth.Date != null)
            { profile.Personal.DateOfBirth = Convert.ToDateTime(UC_DateofBirth.Date); }
            //else { profile.Personal.DateOfBirth = null; }

            profile.Personal.EmailID = txtEmail.Text;
            profile.Personal.MobileNo = txtMobile.Text;

            profile.Personal.ProfileImageURL = "";
            profile.Personal.HeaderMenu = "";

            profile.Personal.ReportingTo = ddlReportingTo.SelectedValue;
            profile.Personal.DepartmentID = Convert.ToInt64(ddlDepartment.SelectedValue);
            profile.Personal.Department = ddlDepartment.SelectedItem.Text;
            //profile.Personal.DesignationID = Convert.ToInt64(ddlDesignation.SelectedValue);
            profile.Personal.DesignationID = Convert.ToInt64(hndDesignationIndex.Value);
            profile.Personal.Designation = hndDesignationValue.Value;

            profile.Personal.IPAddress = "";
            profile.Personal.MachineID = "";


            profile.Personal.Gender = ddlUserGender.SelectedValue;
            profile.Personal.ProfileImg = (byte[])Session["ProfileImg"];

            /*Company Details*/
            profile.Personal.CompanyID = Cprofile.Personal.CompanyID;
            profile.Personal.CName = "";
            profile.Personal.CLogoURL = Cprofile.Personal.CLogoURL;
            profile.Personal.CRMUrl = "";



            /*Preferences*/
            profile.Personal.Theme = "";
            profile.Personal.TimeZone = "";
            profile.Personal.DateTime = "";

            profile.Save();
        }

        protected void GridRoleConfiguration_ColumnsCreated(object sender, EventArgs e)
        {
            int width = 700;
            int count = GridRoleConfiguration.Columns.Count;
            int average = width / count;
            int i = 0;

            //     foreach (Column column in GridRoleConfiguration.Columns)
            //     {
            //         column.Width = 140 + "px";
            //         i++;
            //    }
        }

        protected void lnkUpdateProfileImg_OnClick(object sender, EventArgs e)
        {
            try
            {
                Session["ProfileImg"] = FileUploadProfileImg.FileBytes;
                Img1.Src = "../Image.aspx";
            }
            catch (Exception ex) { }
        }


        [WebMethod]
        public static void PMMoveAddressToArchive(string Ids, string IsArchive)
        {
            PowerOnRentwebapp.Address.UCAddress ucAddress = new Address.UCAddress();
            ucAddress.MoveAddressToArchive(Ids, IsArchive, "User");
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

        [WebMethod]
        public static List<ServiceTerritory.vGetUserProfileList> PMFillddlUserListByTerritory(long level, long parentID)
        {
            List<ServiceTerritory.vGetUserProfileList> UserList = new List<ServiceTerritory.vGetUserProfileList>();
            try
            {
                UC_Territory uc_territory = new UC_Territory();
                UserList = uc_territory.GetUserListByTerritory(level, parentID).ToList();
            }
            catch { }
            finally { }
            return UserList;
        }

        #endregion

        protected void GridRoleConfiguration_OnRebind(object sender, EventArgs e)
        {
            BindRoleDetailsGridView();
        }

    }
}
