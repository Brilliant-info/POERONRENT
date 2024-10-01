<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="UserCreation.aspx.cs" Inherits="PowerOnRentwebapp.UserManagement.UserCreation" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="obout" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../Territory/UC_Territory.ascx" TagName="UC_Territory" TagPrefix="uc1" %>
<%@ Register Src="../Address/UCAddress.ascx" TagName="UCAddress" TagPrefix="uc7" %>
<%@ Register Src="../CommonControls/UC_Date.ascx" TagName="UC_Date" TagPrefix="uc2" %>
<%@ Register Src="../CommonControls/UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc4" %>
<%@ Register Src="../CommonControls/UCToolbar.ascx" TagName="UCToolbar" TagPrefix="uc5" %>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc5:UCToolbar ID="UCToolbar1" runat="server" />
    <uc4:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <asp:ValidationSummary ID="validationsummary_UserCreation" runat="server" ShowMessageBox="true"
        ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="Save" />
    <center>
        <asp:TabContainer ID="TabContainerUserCreation1" runat="server" ActiveTabIndex="2">
            <asp:TabPanel ID="TabPanelUsersList" runat="server" HeaderText="Users List ">
                <ContentTemplate>
                    <center>
                        <table class="gridFrame" style="width: 100%">
                            <tr>
                                <td>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="text-align: left;">
                                                <a id="headerText">User Profile List</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <obout:Grid ID="gvUserCreationM" runat="server" AllowAddingRecords="False" AllowFiltering="True"
                                        Width="100%" AllowGrouping="True" AutoGenerateColumns="False" OnSelect="gvUserCreationM_Select">
                                        <Columns>
                                            <obout:Column ID="Edit" DataField="userID" HeaderText="Edit" Width="10%" TemplateId="GvTempEdit"
                                                Index="0">
                                                <TemplateSettings TemplateId="GvTempEdit" />
                                            </obout:Column>
                                            <obout:Column DataField="EmployeeID" HeaderText="Employee ID" Width="15%" Index="1">
                                            </obout:Column>
                                            <obout:Column DataField="userName" HeaderText="Name" Width="30%" Index="2">
                                            </obout:Column>
                                            <obout:Column DataField="deptname" HeaderText="Department" Width="20%" Index="3">
                                            </obout:Column>
                                            <obout:Column DataField="desiName" HeaderText="Designation" Width="20%" Index="4">
                                            </obout:Column>
                                            <obout:Column DataField="EmailID" HeaderText="Email ID" Width="30%" Index="5">
                                            </obout:Column>
                                            <obout:Column DataField="MobileNo" HeaderText="Mobile No." Width="15%" Index="6">
                                            </obout:Column>
                                            <obout:Column DataField="Active" HeaderText="Active" Width="10%" Index="7">
                                            </obout:Column>
                                        </Columns>
                                        <Templates>
                                            <obout:GridTemplate ID="GvTempEdit" runat="server">
                                                <Template>
                                                    <asp:ImageButton ID="imgBtnEdit" CausesValidation="false" runat="server" ImageUrl="../App_Themes/Blue/img/Edit16.png" />
                                                </Template>
                                            </obout:GridTemplate>
                                        </Templates>
                                    </obout:Grid>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelUserInformation" runat="server" HeaderText="User Information">
                <ContentTemplate>
                    <center>
                        <table class="tableForm">
                            <tr>
                                <td>
                                    <req>Employee No. :</req>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpNo" runat="server" MaxLength="50" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valRftxtEmpNo" runat="server" ControlToValidate="txtEmpNo"
                                        ErrorMessage="Enter Employee NO." ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req> First Name :</req>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="Save" MaxLength="50"
                                        Width="180px" ControlsToEnable="" FolderStyle="" WatermarkText=""></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valRftxtFirstName" runat="server" ControlToValidate="txtFirstName"
                                        ErrorMessage="Enter First Name on User Information Tab" ValidationGroup="Save"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    Middle Name :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiddleName" MaxLength="50" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <req>Last Name :</req>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" ValidationGroup="Save"
                                        Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valRftxtLastName" runat="server" ControlToValidate="txtLastName"
                                        ErrorMessage="Enter Last Name" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req> User Type :</req>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUserType" runat="server" ValidationGroup="Save" Width="187px">
                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                        <asp:ListItem Text="User" Value="User"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfval_ddlUserType" runat="server" ErrorMessage="Select User Type"
                                        ControlToValidate="ddlUserType" InitialValue="0" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <req> Gender :</req>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlUserGender" runat="server" Width="100px">
                                        <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select User Gender"
                                        ControlToValidate="ddlUserGender" InitialValue="0" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td rowspan="5">
                                </td>
                                <td rowspan="5" style="text-align: center;">
                                    <div id="profile">
                                        <img runat="server" id="Img1" width="110" height="132" src="~/App_Themes/Blue/img/Male.png" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req> Department :</req>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" ValidationGroup="Save" DataTextField="Name"
                                        DataValueField="ID" Width="187px" onchange="fillDesignation(this);" ClientIDMode="Static">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valRfddlDepartment" runat="server" ErrorMessage="Select Department"
                                        InitialValue="0" ControlToValidate="ddlDepartment" ForeColor="Red" ValidationGroup="Save"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <req>Designation :</req>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" ValidationGroup="Save" Width="187px"
                                        ClientIDMode="Static" onchange="fillRoleDDL(this);" DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valRfddlDesignation" runat="server" ErrorMessage="Select Designation"
                                        ControlToValidate="ddlDesignation" InitialValue="0" ForeColor="Red" ValidationGroup="Save"
                                        Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date Of Joining :
                                </td>
                                <td style="text-align: left;">
                                    <uc2:UC_Date ID="UC_Dateofjoining" runat="server" />
                                </td>
                                <td>
                                    Date of Birth :
                                </td>
                                <td style="text-align: left;">
                                    <uc2:UC_Date ID="UC_DateofBirth" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req>Email ID :</req>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Save" Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="valRegExptxtEmail" runat="server" ControlToValidate="txtEmail"
                                        ValidationGroup="Save" ErrorMessage="Please Enter Valid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="None"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfv_txtEmail" runat="server" ErrorMessage="Please Enter Email ID"
                                        ControlToValidate="txtEmail" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    Alternate ID :
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtotherID" runat="server" Width="180px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rfv_txtotherID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        runat="server" ControlToValidate="txtotherID" Display="None" ErrorMessage="Please Enter Valid Email Id"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone No. :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone" MaxLength="50" onkeydown="return AllowPhoneNo(this, event);"
                                        runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    Mobile No. :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobile" MaxLength="50" onkeydown="return AllowPhoneNo(this, event);"
                                        runat="server" Width="180px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Interested In :
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="txtinstrated" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    Highest Qualification :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHighestQuali" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:FileUpload ID="FileUploadProfileImg" runat="server" ClientIDMode="Static" onchange="fileUploaderValidationImgOnly(this,20480)" />
                                    <asp:LinkButton runat="server" ID="lnkUpdateProfileImg" Text="Upload" OnClick="lnkUpdateProfileImg_OnClick"
                                        CausesValidation="false"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req>Active :</req>
                                </td>
                                <td style="text-align: left;">
                                    <obout:OboutRadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="rbtnActive"
                                        Checked="True" FolderStyle="">
                                    </obout:OboutRadioButton>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <obout:OboutRadioButton ID="rbtnNo" runat="server" Text="No" GroupName="rbtnActive"
                                        FolderStyle="">
                                    </obout:OboutRadioButton>
                                </td>
                                <td>
                                    Reporting To :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReportingTo" runat="server" ValidationGroup="Save" Width="187px"
                                        DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;" colspan="2">
                                    <span class="watermark">.jpg|.jpeg|.gif|.png|.bmp files are allowed </span>
                                    <br />
                                    <span class="watermark">Max Limit 20 KB </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Assigned Location :
                                </td>
                                <td colspan="5" style="text-align: left;">
                                    <asp:Label ID="lblAsgLocation" runat="server" ClientIDMode="Static"></asp:Label>
                                    <asp:LinkButton ID="lnkbtnSiteLocation" runat="server" ClientIDMode="Static" Text="Change"
                                        OnClientClick="SetActiveTab();"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" style="text-align: left;">
                                    <hr />
                                    <span style="font-weight: bold;">ElegantCRM Login Details</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <req>User Name :</req>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoginId1" runat="server" MaxLength="50" Width="180px" ValidationGroup="Save"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req_txtLoginId" runat="server" ErrorMessage="Please Enter Login ID"
                                        ControlToValidate="txtLoginId1" ForeColor="Red" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPassword" runat="server" Text="Password :" ForeColor="Maroon"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" MaxLength="15"
                                        Width="180px" ClientIDMode="Static" ValidationGroup="Save" onkeyup="divPasswordwstrength();"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req_txtPassword" runat="server" ErrorMessage="Enter password"
                                        ControlToValidate="txtPassword1" ForeColor="Red" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password :" ForeColor="Maroon"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="20"
                                        Width="180px" ValidationGroup="Save" onkey="compareCPw()"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfValtxtConfirmPassword" runat="server" ErrorMessage="Please Enter Confirm Password"
                                        ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="Save"
                                        Display="None"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpValtxtPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtPassword1" ErrorMessage="Confirm Password does not match to Password!"
                                        Display="None" Type="String" ValidationGroup="Save"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                <td style="text-align: right;">
                                    <div id="divPasswordwstrength">
                                    </div>
                                    <span id="PasswordwstrengthMsg" style="font-size: 11px; margin-top: -11px; margin-right: 8px;
                                        float: right;"></span>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelAddressInfo" runat="server">
                <HeaderTemplate>
                    Address Info
                </HeaderTemplate>
                <ContentTemplate>
                    <uc7:UCAddress ID="UCAddress1" runat="server" />
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanelRoleConfiguration" runat="server">
                <HeaderTemplate>
                    Role Configuration
                </HeaderTemplate>
                <ContentTemplate>
                    <center>
                        <table class="tableForm">
                            <tr>
                                <td>
                                    <uc1:UC_Territory ID="UC_Territory1" runat="server" />
                                    <a id="btnAssignLocation" onclick="AssignLocation();" style="margin-top: -20px;">Assign
                                        Location</a>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <div id="divSelectedLocation" runat="server" clientidmode="Static" style="width: 415px;
                                        float: right;">
                                    </div>
                                    <asp:HiddenField ID="hdnSelectedLocation" runat="server" ClientIDMode="Static" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;">
                                    <req> Select Role :</req>
                                    <asp:DropDownList ID="ddlRoleList" runat="server" ValidationGroup="Save" Width="187px" DataTextField="RoleName" DataValueField="mrID"
                                        onchange="RefreshGVRoleConfig(this);" ClientIDMode="Static">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVddlRoleList" runat="server" ErrorMessage="Select Role"
                                        ControlToValidate="ddlRoleList" InitialValue="0" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <table class="gridFrame" id="tblGridRole">
                            <tr>
                                <td>
                                    <a class="headerText">Role Configuration</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <obout:Grid ID="GridRoleConfiguration" runat="server" AutoGenerateColumns="false"
                                        AllowAddingRecords="false" AllowColumnReordering="true" AllowColumnResizing="false"
                                        AllowGrouping="true" AllowSorting="true" AllowFiltering="false" AllowManualPaging="false"
                                        AllowMultiRecordAdding="false" AllowPageSizeSelection="false" AllowPaging="false"
                                        AllowRecordSelection="false" ShowCollapsedGroups="false" ShowGroupFooter="false"
                                        ShowFooter="false" ShowTotalNumberOfPages="false" ShowGroupsInfo="false" PageSize="-1"
                                        HideColumnsWhenGrouping="true" Serialize="true" GroupBy="DisplayModuleName,DisplayPhaseName"
                                        Width="800px" OnRebind="GridRoleConfiguration_OnRebind">
                                        <TemplateSettings GroupHeaderTemplateId="GroupTemplate" />
                                        <Columns>
                                            <obout:Column DataField="DisplayModuleName" HeaderText="Module" AllowSorting="false"
                                                AllowGroupBy="true" Width="10%">
                                            </obout:Column>
                                            <obout:Column DataField="DisplayPhaseName" HeaderText="Phase" AllowSorting="false"
                                                AllowGroupBy="true" Width="10%">
                                            </obout:Column>
                                            <obout:Column DataField="ObjectDisplayName" Width="40%" HeaderText="Objects" AllowSorting="false"
                                                AllowGroupBy="false">
                                            </obout:Column>
                                            <obout:Column DataField="Add" Width="10%" Align="center" HeaderAlign="center" AllowSorting="false"
                                                Index="4" AllowGroupBy="false" HeaderText="Add/Edit">
                                                <TemplateSettings TemplateId="checkboxAccessLevel" />
                                            </obout:Column>
                                            <obout:Column DataField="View" Width="10%" Align="center" HeaderAlign="center" AllowSorting="false"
                                                AllowGroupBy="false" Visible="false">
                                                <TemplateSettings TemplateId="checkboxAccessLevel" />
                                            </obout:Column>
                                            <obout:Column DataField="Approval" Width="10%" Align="center" HeaderAlign="center"
                                                AllowSorting="false" AllowGroupBy="false">
                                                <TemplateSettings TemplateId="TemplateApproval" />
                                            </obout:Column>
                                            <obout:Column DataField="AssignTask" Width="10%" Align="center" HeaderAlign="center"
                                                AllowSorting="false" AllowGroupBy="false">
                                                <TemplateSettings TemplateId="TemplateAssignTask" HeaderTemplateId="HeaderTempAssignTask" />
                                            </obout:Column>
                                            <obout:Column DataField="mSequence" Visible="false" Width="0%">
                                            </obout:Column>
                                            <obout:Column DataField="pSequence" Visible="false" Width="0%">
                                            </obout:Column>
                                            <obout:Column DataField="oSequence" Visible="false" Width="0%">
                                            </obout:Column>
                                            <obout:Column DataField="ApprovalVisible" Visible="false" Width="0%">
                                            </obout:Column>
                                            <obout:Column DataField="AssignTaskVisible" Visible="false" Width="0%">
                                            </obout:Column>
                                        </Columns>
                                        <Templates>
                                            <obout:GridTemplate ID="HeaderTempAssignTask" runat="server">
                                                <Template>
                                                    Assign
                                                    <br />
                                                    Task
                                                </Template>
                                            </obout:GridTemplate>
                                            <obout:GridTemplate ID="checkboxAccessLevel" runat="server">
                                                <Template>
                                                    <input type="checkbox" style="cursor: pointer;" onclick="saveCheckBoxChangesRoleMaster(this, '<%# GridRoleConfiguration.Columns[Container.ColumnIndex].DataField %>', <%# Container.PageRecordIndex %>)"
                                                        <%# Container.Value.ToString().ToLower()=="true" ? "checked='checked'" : "" %> />
                                                </Template>
                                            </obout:GridTemplate>
                                            <obout:GridTemplate ID="TemplateApproval" runat="server">
                                                <Template>
                                                    <input type="checkbox" onclick="saveCheckBoxChangesRoleMaster(this, 'Approval', <%# Container.PageRecordIndex %>)"
                                                        <%# Container.Value.ToString().ToLower()=="true" ? "checked='checked'" : "" %>
                                                        <%# Container.DataItem["ApprovalVisible"].ToString().ToLower()=="true" ? "style='visibility: visible; cursor:pointer;'" : "style='visibility: hidden; cursor:pointer;'" %> />
                                                    <a style="margin-left: -8px;" title="Not Applicable">
                                                        <%# Container.DataItem["ApprovalVisible"].ToString().ToLower()=="false" ? "N/A" : "" %></a>
                                                </Template>
                                            </obout:GridTemplate>
                                            <obout:GridTemplate ID="TemplateAssignTask" runat="server">
                                                <Template>
                                                    <input type="checkbox" onclick="saveCheckBoxChangesRoleMaster(this, 'AssignTask', <%# Container.PageRecordIndex %>)"
                                                        <%# Container.Value.ToString().ToLower()=="true" ? "checked='checked'" : "" %>
                                                        <%# Container.DataItem["AssignTaskVisible"].ToString().ToLower()=="true" ? "style='visibility: visible; cursor:pointer;'" : "style='visibility: hidden; cursor:pointer;'" %> />
                                                    <a style="margin-left: -8px;" title="Not Applicable">
                                                        <%# Container.DataItem["AssignTaskVisible"].ToString().ToLower() == "false" ? "N/A" : ""%>
                                                    </a>
                                                </Template>
                                            </obout:GridTemplate>
                                            <obout:GridTemplate runat="server" ID="GroupTemplate">
                                                <Template>
                                                    <h7><%# Container.Value %></h7>
                                                </Template>
                                            </obout:GridTemplate>
                                        </Templates>
                                    </obout:Grid>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
    </center>
    <asp:HiddenField runat="server" ID="hdnDivCount" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnDDLRoleSelectedValue" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hndDesignationIndex" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hndDesignationValue" ClientIDMode="Static" />      
    <style type="text/css">
        .newlocationdiv
        {
            top: 0;
            left: 0;
            width: 120px;
            margin: 0px 3px 2px 0px;
        }
        .removeAL
        {
            color: Red;
            padding: 0px 3px 0px 3px;
            border-right: solid 1px silver;
        }
        .removeAL:hover
        {
            cursor: pointer;
        }
    </style>
    <asp:HiddenField ID="hndstate" runat="server" />
    <asp:HiddenField ID="hnduserID" runat="server" />
    <asp:HiddenField ID="hndRoleSate" runat="server" />    

    <script type="text/javascript">
        var removeHTML;
        var count;
        function saveCheckBoxChangesRoleMaster(element, dataField, rowIndex) {
            if (GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value != element.checked.toString()) {
                if (element.checked == true) GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value = "true";
                if (element.checked == false) GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value = "false";
                var role = new Object(); role.mSequence = GridRoleConfiguration.Rows[rowIndex].Cells['mSequence'].Value;
                role.pSequence = GridRoleConfiguration.Rows[rowIndex].Cells['pSequence'].Value;
                role.oSequence = GridRoleConfiguration.Rows[rowIndex].Cells['oSequence'].Value;
                role.Add = GridRoleConfiguration.Rows[rowIndex].Cells['Add'].Value;
                role.Edit = //GridRoleConfiguration.Rows[rowIndex].Cells['Edit'].Value; 
                role.View = GridRoleConfiguration.Rows[rowIndex].Cells['View'].Value;
                //role.Delete = GridRoleConfiguration.Rows[rowIndex].Cells['Delete'].Value; 
                role.Approval = GridRoleConfiguration.Rows[rowIndex].Cells['Approval'].Value;
                role.AssignTask = GridRoleConfiguration.Rows[rowIndex].Cells['AssignTask'].Value; PageMethods.UpdateRole(role, rowIndex, null, null);
            }
        } function UserCreationEditRole(sender, e) { }

        function SetUnArchive(Ids, IsArchive) {
            PageMethods.PMMoveAddressToArchive(Ids, IsArchive, null, null);
        }

        function compareCPw() {
            var txt = document.getElementById("txtConfirmNewPassword");
            txt.style.border = "red";
            if (document.getElementById("txtPassword1").value == document.getElementById("txtConfirmNewPassword").value) {
                txt.style.border = "green";
            }
        }

        function AssignLocation() {
            var divSelectedLocation = document.getElementById("divSelectedLocation");
            var hdnDivCount = document.getElementById("hdnDivCount");
            var ddlLevel3 = document.getElementById(childID);
            if (ddlLevel3.selectedIndex == 0) { alert(ddlLevel3.options[ddlLevel3.selectedIndex].text); }
            else {
                if (divSelectedLocation.innerHTML.toString().indexOf(ddlLevel3.options[ddlLevel3.selectedIndex].text) == -1) {
                    var newLocaion = ddlLevel3.options[ddlLevel3.selectedIndex].text;
                    if (hdnDivCount.value == "") { hdnDivCount.value = "1"; };
                    var remove = "<a onclick=removeLocation('div" + hdnDivCount.value.toString() + "'," + ddlLevel3.value + ") class='removeAL'>X</a>";
                    divSelectedLocation.innerHTML = divSelectedLocation.innerHTML.replace(/^\s+|\s+$/g, '');

                    divSelectedLocation.innerHTML += "<span class='newlocationdiv' id=div" + hdnDivCount.value.toString() + ">-" + newLocaion + remove + "</span>";
                    hdnDivCount.value = parseInt(hdnDivCount.value) + 1;
                    if (document.getElementById("hdnSelectedLocation").value != "") { document.getElementById("hdnSelectedLocation").value += ',' + ddlLevel3.value; }
                    else { document.getElementById("hdnSelectedLocation").value = ddlLevel3.value; }
                }
                else { alert(ddlLevel3.options[0].text.replace('-', '').replace('Select', '') + ' already exist'); }
            }
        }
        function removeLocation(divname, locationID) {
            var maindiv = document.getElementById("divSelectedLocation");
            var divs = maindiv.getElementsByTagName("span");
            for (var i = 0; i < divs.length; i++) {
                if (divs[i].id == divname) {
                    divs[i].parentNode.removeChild(divs[i]);
                    document.getElementById("hdnSelectedLocation").value = document.getElementById("hdnSelectedLocation").value.replace(locationID + ',', "");
                    document.getElementById("hdnSelectedLocation").value = document.getElementById("hdnSelectedLocation").value.replace(',' + locationID, "");
                    document.getElementById("hdnSelectedLocation").value = document.getElementById("hdnSelectedLocation").value.replace(locationID, "");
                    break;
                }
            }

            var divSelectedLocation = document.getElementById("divSelectedLocation");
            divSelectedLocation.innerHTML = divSelectedLocation.innerHTML.replace(/^\s+|\s+$/g, '');
        }

        function clearSelectedLocations() {
            document.getElementById("divSelectedLocation").innerHTML = "";
            document.getElementById("hdnSelectedLocation").value = "";
        }

        function SetActiveTab() {
            var tabContainer = $get('<%=TabContainerUserCreation1.ClientID%>');
            tabContainer.control.set_activeTabIndex('3');
        }

        /*Check password strength*/
        function divPasswordwstrength() {
            var txtlength = document.getElementById("txtPassword1").value.length;
            var dpw = document.getElementById("divPasswordwstrength");
            var msg = document.getElementById("PasswordwstrengthMsg");
            dpw.style.height = "10px";
            switch (txtlength) {
                case 0:
                    dpw.style.backgroundColor = "red";
                    dpw.style.width = "10px";
                    msg.innerHTML = "Weak";
                    break;
                case 1:
                    dpw.style.backgroundColor = "red";
                    dpw.style.width = "10px";
                    msg.innerHTML = "Weak";
                    break;
                case 2:
                    dpw.style.backgroundColor = "red";
                    dpw.style.width = "20px";
                    msg.innerHTML = "Weak";
                    break;
                case 3:
                    dpw.style.backgroundColor = "red";
                    dpw.style.width = "30px";
                    msg.innerHTML = "Weak";
                    break;
                case 4:
                    dpw.style.backgroundColor = "red";
                    dpw.style.width = "40px";
                    msg.innerHTML = "Weak";
                    break;
                case 5:
                    dpw.style.backgroundColor = "orange";
                    dpw.style.width = "50px";
                    msg.innerHTML = "Average";
                    break;
                case 6:
                    dpw.style.backgroundColor = "orange";
                    dpw.style.width = "60px";
                    msg.innerHTML = "Average";
                    break;
                case 7:
                    dpw.style.backgroundColor = "orange";
                    dpw.style.width = "70px";
                    msg.innerHTML = "Average";
                    break;
                case 8:
                    dpw.style.backgroundColor = "orange";
                    dpw.style.width = "80px";
                    msg.innerHTML = "Average";
                    break;
                case 9:
                    dpw.style.backgroundColor = "orange";
                    dpw.style.width = "90px";
                    msg.innerHTML = "Average";
                    break;
                case 10:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "100px";
                    msg.innerHTML = "Strong";
                    break;
                case 11:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "110px";
                    msg.innerHTML = "Strong";
                    break;
                case 12:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "120px";
                    msg.innerHTML = "Strong";
                    break;
                case 13:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "130px";
                    msg.innerHTML = "Strong";
                    break;
                case 14:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "140px";
                    msg.innerHTML = "Strong";
                    break;
                case 15:
                    dpw.style.backgroundColor = "green";
                    dpw.style.width = "150px";
                    msg.innerHTML = "Strong";
                    break;
            }
        }
        /*End*/

        /*Fill Dropdown*/
        function fillDesignation(invoker) {
            ddlLoadingOn(document.getElementById("ddlDesignation"));
            document.getElementById("ddlRoleList").options.length = 0;
            PageMethods.PMfillDesignation(parseInt(invoker.value), fillDesignationOnSuccess, fillDesignationOnError)
        }
        function fillDesignationOnSuccess(result) {
            var ddl = document.getElementById("ddlDesignation");

            for (var i = 0; i < result.length; i++) {
                var option1 = document.createElement("option");
                option1.text = result[i].Name;
                option1.value = result[i].ID;
                try {
                    ddl.add(option1, null);
                }
                catch (Error) {
                    ddl.add(option1);
                }
            }

            ddlLoadingOff(ddl);
        }

        function fillDesignationOnError() {
            ddlFillError(document.getElementById("ddlDesignation"));
        }

        function fillRoleDDL(invoker) {
            var ddlDepartment = document.getElementById("ddlDepartment");
            var ddlDesignation = document.getElementById("ddlDesignation");

            document.getElementById("hndDesignationIndex").value = invoker.selectedIndex;

            var SelectedText = invoker.options[invoker.selectedIndex].value;
            document.getElementById("hndDesignationValue").value = SelectedText;

            //Add By Suresh
            var hndDesignationValue = document.getElementById('hndDesignationValue');
            hndDesignationValue.value = invoker.options[invoker.selectedIndex].value;

            ddlLoadingOn(document.getElementById("ddlRoleList"));

            if (ddlDepartment.selectedIndex > 0 && ddlDesignation.selectedIndex > 0) {
                PageMethods.PMfillRoleDDL(parseInt(ddlDepartment.value), parseInt(ddlDesignation.value), fillRoleDDLOnSuccess, fillRoleDDLOnError)
            }
        }

        function fillRoleDDLOnSuccess(result) {
            var ddl = document.getElementById("ddlRoleList");
            var option0 = document.createElement("option");
            if (result.length > 0) {
                option0.text = '-Select-';
                option0.value = "0";
                try {
                    ddl.add(option0, null);
                }
                catch (Error) {
                    ddl.add(option0);
                }
            }

//            var option2 = document.createElement("option");
//            var option3 = document.createElement("option");
//            option3.text = '-Select-';
//            option3.value = "0";
//            option2.text = 'Custom';
//            option2.value = "1";
//            option2.style.color = "red";
//            option2.style.fontWeight = "bold";
//            try {
//                ddl.add(option3, null);
//                ddl.add(option2, null);

//            }
//            catch (Error) {
//                ddl.add(option2);
//            }
            for (var i = 0; i < result.length; i++) {
                var option1 = document.createElement("option");
                option1.text = result[i].RoleName;
                option1.value = result[i].mrID;
                try {
                    ddl.add(option1, null);
                }
                catch (Error) {
                    ddl.add(option1);
                }
            }
            ddlLoadingOff(ddl);
        }

        function fillRoleDDLOnError() {
            ddlFillError(document.getElementById("ddlRoleList"));
        }

        function RefreshGVRoleConfig(invoker) {
            var hdnDDLRoleSelectedValue = document.getElementById('hdnDDLRoleSelectedValue');
            hdnDDLRoleSelectedValue.value = invoker.options[invoker.selectedIndex].value;
            GridRoleConfiguration.refresh();
        }

    </script>
</asp:Content>
