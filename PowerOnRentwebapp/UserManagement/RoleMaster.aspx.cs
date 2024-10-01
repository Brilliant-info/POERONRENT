using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using PowerOnRentwebapp.RoleMasterService;
using Obout.Grid;
using System.Collections;
using PowerOnRentwebapp.Login;


namespace PowerOnRentwebapp.UserManagement
{
    public partial class RoleMaster : System.Web.UI.Page
    {
        //connectiondetails AppConnectionDetails = new connectiondetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            UCFormHeader1.FormHeaderText = "Role Master";
            if (!IsPostBack) { FillDepartment(); Session["sessionRoleList"] = null; BindRoleMasterGridView(); clear(); setActiveTab(0); }
            //this.UCToolbar1.ToolbarAccess("RoleMaster","");
            UCToolbar1.evClickSave += pageSave;
            UCToolbar1.evClickSave += pageAdd;
            this.UCToolbar1.evClickAddNew += pageAddNew;

            CustomProfile profile = CustomProfile.GetProfile();
            if (!IsPostBack)
            {
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
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        { CustomProfile profile = CustomProfile.GetProfile(); if (profile.Personal.Theme == null || profile.Personal.Theme == string.Empty) { Page.Theme = "Blue"; } else { Page.Theme = profile.Personal.Theme; } }

        protected void FillDepartment()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                //DepartmentService.connectiondetails AppConnectionDetailsDept = new DepartmentService.connectiondetails();
                DepartmentService.iDepartmentMasterClient DeptService = new DepartmentService.iDepartmentMasterClient();
                ddlDeartment.DataSource = DeptService.GetDeparmentList(profile.DBConnection._constr);
                ddlDeartment.DataBind();
                ListItem lst = new ListItem { Text = "-Select-", Value = "0" };
                ddlDeartment.Items.Insert(0, lst);
                DeptService.Close();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "FillDepartment");

            }
            finally
            {
            }
        }

        protected void FillDesignation()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                //DesignationService.connectiondetails AppConnectionDetailsDeSig = new DesignationService.connectiondetails();
                ddlDesignation.DataSource = null;
                ddlDesignation.DataBind();
                if (ddlDeartment.SelectedIndex > 0)
                {
                    ListItem lst = new ListItem { Text = "-Select-", Value = "0" };
                    DesignationService.iDesignationMasterClient DesignationService = new DesignationService.iDesignationMasterClient();
                    ddlDesignation.DataSource = DesignationService.GetDesignationListByDepartmentID(Convert.ToInt32(ddlDeartment.SelectedItem.Value), profile.DBConnection._constr);
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, lst);
                    DesignationService.Close();

                }
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "FillDesignation");

            }
            finally
            {
            }
        }

        protected void BindRoleDetailsGridView(long RoleID)
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                List<SP_GetDataToBindRoleMaster_Result> sessionList = new List<SP_GetDataToBindRoleMaster_Result>();
                RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
                sessionList = roleMasterService.GetDataToBindRoleMasterDetailsByRoleID(RoleID, profile.Personal.CompanyID, profile.DBConnection._constr).ToList();
                GridRoleConfiguration.GroupBy = "DisplayModuleName,DisplayPhaseName";
                GridRoleConfiguration.ShowHeader = true;
                GridRoleConfiguration.DataSource = sessionList;
                GridRoleConfiguration.DataBind();
                Session.Add("sessionRoleList", sessionList);
                roleMasterService.Close();
                //TabContainerRoleMaster.ActiveTabIndex = 1;
                //TabPanelRoleDetails.Visible = true;
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "BindRoleDetailsGridView");

            }
            finally
            {
            }
        }

        protected void BindRoleMasterGridView()
        {
            try
            {
                CustomProfile profile = CustomProfile.GetProfile();
                RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
                GridRoleMaster.DataSource = roleMasterService.BindRoleMasterSummary(profile.DBConnection._constr);
                GridRoleMaster.DataBind();
                roleMasterService.Close();
               // TabContainerRoleMaster.ActiveTabIndex = 0;
                
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "BindRoleMasterGridView");

            }
            finally
            {
            }
        }

        [WebMethod]
        public static void UpdateRole(object role, object rowIndex)
        {
            CustomProfile profile = CustomProfile.GetProfile();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary = (Dictionary<string, object>)role;
            //connectiondetails AppConnectionDetails = new connectiondetails();
            SP_GetDataToBindRoleMaster_Result updateRole = new SP_GetDataToBindRoleMaster_Result();
            updateRole.mSequence = Convert.ToInt64(dictionary["mSequence"]);
            updateRole.pSequence = Convert.ToInt64(dictionary["pSequence"]);
            updateRole.oSequence = Convert.ToInt64(dictionary["oSequence"]);

            updateRole.Add = Convert.ToBoolean(dictionary["Add"]);

            //if (updateRole.Add == true) { updateRole.Edit = true; updateRole.View = true; }
            //else { updateRole.Edit = false; }

            //Add By Suresh
            if (updateRole.Add == true) { updateRole.Edit = true; }
            else { updateRole.Edit = false; }

            if (updateRole.View == true) { updateRole.View = true; }
            else { updateRole.View = false; }

            //updateRole.View = true;
            updateRole.Delete = false;           
            updateRole.Approval = Convert.ToBoolean(dictionary["Approval"]);
            if (updateRole.Approval == true) { updateRole.View = true; }
            updateRole.AssignTask = Convert.ToBoolean(dictionary["AssignTask"]);
            if (updateRole.AssignTask == true) { updateRole.View = true; }
            if (updateRole.Add == true && updateRole.Approval == false && updateRole.AssignTask == false && Convert.ToBoolean(dictionary["View"]) == true)
            { updateRole.View = true; }  
            RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
            HttpContext.Current.Session["sessionRoleList"] = roleMasterService.UpdateRoleIntoSessionList(getSessionList().ToArray(), updateRole, Convert.ToInt32(rowIndex), profile.DBConnection._constr).ToList();
            roleMasterService.Close();
        }

        protected void pageAdd(Object sender, ToolbarService.iUCToolbarClient e)
        {
          

        }

        protected void pageSave(Object sender, ToolbarService.iUCToolbarClient e)
        {
            try
            {  if (checkDuplicate() == "")
                {
                 
                CustomProfile profile = CustomProfile.GetProfile();
                RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
                mRole obj = new mRole();
                if (hdnRoleID.Value != "0" && hdnRoleID.Value != string.Empty)
                {
                    obj = roleMasterService.GetmRoleByID(Convert.ToInt32(hdnRoleID.Value), profile.DBConnection._constr);
                    obj.LastModifiedBy = profile.Personal.UserID.ToString();
                    obj.LastModifiedDate = DateTime.Now;
                }
                else
                {
                    obj.CreatedBy = profile.Personal.UserID.ToString();
                    obj.CreationDate = DateTime.Now;
                }
                obj.RoleName = txtRoleName.Text.Trim();
                obj.DepartmentID = Convert.ToInt64(ddlDeartment.SelectedItem.Value);
                obj.DesignationID = Convert.ToInt64(ddlDesignation.SelectedItem.Value);
                obj.Sequence = 0;
                //if (txtSequence.Text != string.Empty) obj.Sequence = Convert.ToInt32(txtSequence.Text);
                obj.Active = "Y";
                if (rbtnNo.Checked == true) obj.Active = "N";
                obj.CompanyID = profile.Personal.CompanyID;
                roleMasterService.FinalSave(getSessionList().ToArray(), obj, profile.DBConnection._constr);
                roleMasterService.Close();
                TabContainerRoleMaster.ActiveTabIndex = 0;
                TabPanelRoleDetails.Visible = false;
                BindRoleMasterGridView();
                clear();
                setActiveTab(0);
                WebMsgBox.MsgBox.Show("Record saved successfully");
            }
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "pageSave");

            }
            finally
            {
               
              
            }

        }

        protected void clear()
        {
            hdnRoleID.Value = "0";
            txtRoleName.Text = "";
           // txtSequence.Text = "";
            ddlDeartment.SelectedIndex = -1;
            ddlDesignation.SelectedIndex = -1;
            rbtnNo.Checked = false;
            rbtnYes.Checked = true;
            GridRoleConfiguration.DataSource = null;
            GridRoleConfiguration.DataBind();
            Session["sessionRoleList"] = null;
        }

        protected static List<SP_GetDataToBindRoleMaster_Result> getSessionList()
        {

            List<SP_GetDataToBindRoleMaster_Result> sessionList = new List<SP_GetDataToBindRoleMaster_Result>();
            if (HttpContext.Current.Session["sessionRoleList"] != null) sessionList = (List<SP_GetDataToBindRoleMaster_Result>)HttpContext.Current.Session["sessionRoleList"];
            return sessionList;
        }

        protected void ddlDeartment_SelectedIndexChanged(object sender, EventArgs e)
        { FillDesignation(); }

        //protected void GridRoleMaster_Select(object sender, Obout.Grid.GridRecordEventArgs e)
        //{

        //    try
        //    {
        //        clear();

        //        Hashtable selectedrec = (Hashtable)GridRoleMaster.SelectedRecords[0];

        //        hdnRoleID.Value = selectedrec["mrID"].ToString();
        //        txtRoleName.Text = selectedrec["RoleName"].ToString();
        //       // txtSequence.Text = selectedrec["mrSequence"].ToString();
        //        if (selectedrec["Active"].ToString() == "Yes") { rbtnYes.Checked = true; rbtnNo.Checked = false; }
        //        else { rbtnNo.Checked = true; rbtnYes.Checked = false; }

        //        if (ddlDeartment.Items.Count <= 1) FillDepartment();
        //        ddlDeartment.SelectedIndex = ddlDeartment.Items.IndexOf(ddlDeartment.Items.FindByValue(selectedrec["DepartmentID"].ToString()));
        //        FillDesignation();
        //        ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(selectedrec["DesignationID"].ToString()));
        //        BindRoleDetailsGridView(Convert.ToInt32(hdnRoleID.Value));
        //        //TabContainerRoleMaster.ActiveTabIndex = 1;
        //        setActiveTab(1);
        //        this.UCToolbar1.ToolbarAccess("RoleMaster", "btnEdit");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Login.Profile.ErrorHandling(ex, this, "Role Master", "GridRoleMaster_Select");

        //    }
        //    finally
        //    {
        //    }
        //}

        protected void GridRoleMaster_Select(object sender, Obout.Grid.GridRecordEventArgs e)
        {
            try
            {
                clear();
                getrolebyID();
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "GridRoleMaster_Select");
            }
            finally { }
        }

        private void getrolebyID()
        {
            try
            {
                Hashtable selectedrec = (Hashtable)GridRoleMaster.SelectedRecords[0];
                hdnRoleID.Value = selectedrec["mrID"].ToString();
                txtRoleName.Text = selectedrec["RoleName"].ToString();
                if (selectedrec["Active"].ToString() == "Yes") { rbtnYes.Checked = true; rbtnNo.Checked = false; }
                else { rbtnNo.Checked = true; rbtnYes.Checked = false; }

                if (ddlDeartment.Items.Count <= 1) FillDepartment();
                ddlDeartment.SelectedIndex = ddlDeartment.Items.IndexOf(ddlDeartment.Items.FindByValue(selectedrec["DepartmentID"].ToString()));
                FillDesignation();
                ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(selectedrec["DesignationID"].ToString()));
                BindRoleDetailsGridView(Convert.ToInt32(hdnRoleID.Value));

                hndstate.Value = "Edit";
                setActiveTab(1);
            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "GridRoleMaster_Select");
            }
            finally { }
        }


        protected void pageAddNew(Object sender, ToolbarService.iUCToolbarClient e)
        {
            try
            {
                clear();
                BindRoleDetailsGridView(0);
                setActiveTab(1);
                //TabPanelRoleDetails.Enabled = true;
                //TabContainerRoleMaster.ActiveTabIndex = 1;              
                GridRoleConfiguration.GroupBy = "DisplayModuleName,DisplayPhaseName";
                //GridRoleConfiguration.Width =100;
                GridRoleConfiguration.ShowHeader = true;
               // GridRoleConfiguration_ColumnsCreated(sender, e);
                    
           }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "pageAddNew");

            }
            finally
            {
            }
        }

        public string checkDuplicate()
        {
            RoleMasterService.iRoleMasterClient roleMasterService = new RoleMasterService.iRoleMasterClient();
            //PopupMessages.PopupMessage pop = new PopupMessages.PopupMessage();
            try
            {                 
                string result = "";
                CustomProfile profile = CustomProfile.GetProfile();
                if (hdnRoleID.Value == string.Empty)
                {
                    result = roleMasterService.checkDuplicateRecord(txtRoleName.Text, profile.DBConnection._constr);
                    if (result != string.Empty)
                    {
                        WebMsgBox.MsgBox.Show(result);
                        txtRoleName.Text = "";
                    }
                    txtRoleName.Focus();
                }
                else
                {
                    int id = Convert.ToInt32(hdnRoleID.Value);
                    result = roleMasterService.checkDuplicateRecordEdit(id, txtRoleName.Text, profile.DBConnection._constr);
                    if (result != string.Empty)
                    {
                        WebMsgBox.MsgBox.Show(result);
                        txtRoleName.Text = "";
                    }
                }
                return result;

            }
            catch (System.Exception ex)
            {
                Login.Profile.ErrorHandling(ex, this, "Role Master", "checkDuplicate");
                string result = "";
                return result;
            }
            finally
            {
            }


        }

        protected void setActiveTab(int ActiveTab)
        {
            Button btnSave = (Button)UCToolbar1.FindControl("btnSave");
             
            if (ActiveTab == 0)
            {
                TabPanelRoleDetails.Visible = false;
                TabContainerRoleMaster.ActiveTabIndex = 0; btnSave.Enabled = false;
            }
            else
            {              
                 TabPanelRoleDetails.Visible = true;
                 TabContainerRoleMaster.ActiveTabIndex = 1; btnSave.Enabled = true;
                
            }
        }

        protected void GridRoleConfiguration_ColumnsCreated(object sender, EventArgs e)
        {
            int width = 700;
            int count = GridRoleConfiguration.Columns.Count;
            int average = width / count;
            int i = 0;

            foreach (Column column in GridRoleConfiguration.Columns)
            {
                //if (i < count - 1)
                //{
                //    column.Width = average.ToString() + "%";
                //}
                //else
                //{
                //    column.Width = width.ToString() + "%";
                //}
                
                //width -= average;
                column.Width = 140 + "px";
                i++;
            }
        }

    }
}
