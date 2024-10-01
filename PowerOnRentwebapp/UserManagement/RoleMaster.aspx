﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    CodeBehind="RoleMaster.aspx.cs" Inherits="PowerOnRentwebapp.UserManagement.RoleMaster"
    EnableEventValidation="false" %>

<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="obout" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../CommonControls/UCToolbar.ascx" TagName="UCToolbar" TagPrefix="uc1" %>
<%@ Register Src="../CommonControls/UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc1:UCToolbar ID="UCToolbar1" runat="server" />
    <uc2:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <asp:UpdatePanel ID="UpdatePanelTabPanelRoleList" runat="server">
        <ContentTemplate>
            <center>
                <asp:TabContainer ID="TabContainerRoleMaster" runat="server" ActiveTabIndex="0">
                    <asp:TabPanel runat="server" ID="TabPanelRoleMaster" HeaderText="Role List" TabIndex="0">
                        <ContentTemplate>
                            <asp:UpdateProgress ID="UpdateProgress_RoleMaster" runat="server" AssociatedUpdatePanelID="updPnl_RoleMaster">
                                <ProgressTemplate>
                                    <center>
                                        <div class="modal">
                                            <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%;" /><obout:OboutRadioButton
                                                ID="OboutRadioButton1" runat="server">
                                            </obout:OboutRadioButton>
                                        </div>
                                    </center>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:ValidationSummary ID="validationsummary_RoleM" runat="server" ShowMessageBox="true"
                                ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="Save" />
                            <asp:UpdatePanel runat="server" ID="updPnl_RoleMaster">
                                <ContentTemplate>
                                    <center>
                                        <table class="gridFrame" width="70%">
                                            <tr>
                                                <td>
                                                    <a class="headerText">Role List</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <obout:Grid ID="GridRoleMaster" runat="server" AutoGenerateColumns="false" AllowAddingRecords="false"
                                                        HideColumnsWhenGrouping="true" Width="100%" OnSelect="GridRoleMaster_Select"
                                                        AllowGrouping="true">
                                                        <TemplateSettings GroupHeaderTemplateId="GroupTemplate" />
                                                        <Columns>
                                                            <obout:Column DataField="mrID" HeaderText="Edit" Width="5%" HeaderAlign="center"
                                                                Align="center" AllowSorting="false" AllowFilter="false">
                                                                <TemplateSettings TemplateId="TemplateEditBtn" />
                                                            </obout:Column>
                                                            <obout:Column DataField="DepartmentName" HeaderText="Department" Width="20%" HeaderAlign="Left"
                                                                Align="Left">
                                                            </obout:Column>
                                                            <obout:Column DataField="DesignationName" HeaderText="Designation" Width="20%" HeaderAlign="Left"
                                                                Align="Left">
                                                            </obout:Column>
                                                            <obout:Column DataField="RoleName" HeaderText="Role Name" Width="20%" HeaderAlign="Left"
                                                                Align="Left">
                                                            </obout:Column>
                                                            <obout:Column DataField="Active" HeaderText="Active" Width="10%" HeaderAlign="center"
                                                                Align="center">
                                                            </obout:Column>
                                                            <obout:Column DataField="mrSequence" Visible="false">
                                                            </obout:Column>
                                                            <obout:Column DataField="DepartmentID" Visible="false">
                                                            </obout:Column>
                                                            <obout:Column DataField="DesignationID" Visible="false">
                                                            </obout:Column>
                                                        </Columns>
                                                        <Templates>
                                                            <obout:GridTemplate runat="server" ID="TemplateEditBtn">
                                                                <Template>
                                                                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="../App_Themes/Blue/img/Edit16.png"
                                                                        ToolTip='<%# Container.Value %>' />
                                                                </Template>
                                                            </obout:GridTemplate>
                                                        </Templates>
                                                    </obout:Grid>
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" ID="TabPanelRoleDetails" HeaderText="Role Configuration"
                        TabIndex="1">
                        <ContentTemplate>
                            <asp:UpdateProgress ID="UpdateProgress_Role" runat="server" AssociatedUpdatePanelID="up_pnl_Role">
                                <ProgressTemplate>
                                    <center>
                                        <div class="modal">
                                            <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%;" />
                                        </div>
                                    </center>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="up_pnl_Role">
                                <ContentTemplate>
                                    <center>
                                        <table class="tableForm">
                                            <tr>
                                                <td>
                                                    <req>Department :</req>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlDeartment" runat="server" DataValueField="ID" DataTextField="Name"
                                                        ValidationGroup="Save" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlDeartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlDeartment" runat="server" ErrorMessage="Select Department"
                                                        ControlToValidate="ddlDeartment" InitialValue="0" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <req>Designation :</req>
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="ddlDesignation" runat="server" DataValueField="ID" DataTextField="Name"
                                                        ValidationGroup="Save" Width="250px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlDesignation" runat="server" ErrorMessage="Select Designation"
                                                        ControlToValidate="ddlDesignation" InitialValue="0" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <req> Active :</req>
                                                </td>
                                                <td style="text-align: left;">
                                                    <obout:OboutRadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="rbtnActive"
                                                        Checked="true">
                                                    </obout:OboutRadioButton>
                                                    <obout:OboutRadioButton ID="rbtnNo" runat="server" Text="No" GroupName="rbtnActive">
                                                    </obout:OboutRadioButton>
                                                </td>
                                                <td>
                                                    <req>Role Name :</req>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtRoleName" MaxLength="100" Width="244px" onKeyPress="return alpha(this,event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVtxtRoleName" runat="server" ErrorMessage="Enter Role Name"
                                                        ControlToValidate="txtRoleName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                                                        Width="800px">
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
                                                                <TemplateSettings TemplateId="checkboxAccessLevell" />
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
                                                            <obout:GridTemplate ID="checkboxAccessLevell" runat="server">
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
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
                <asp:HiddenField ID="hdnRoleID" runat="server" />
                 <asp:HiddenField ID="hndstate" runat="server" />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">


        function saveCheckBoxChangesRoleMaster(element, dataField, rowIndex) {
            if (GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value != element.checked.toString()) {
                if (element.checked == true) GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value = "true";
                if (element.checked == false) GridRoleConfiguration.Rows[rowIndex].Cells[dataField].Value = "false";

                var role = new Object();
                role.mSequence = GridRoleConfiguration.Rows[rowIndex].Cells['mSequence'].Value;
                role.pSequence = GridRoleConfiguration.Rows[rowIndex].Cells['pSequence'].Value;
                role.oSequence = GridRoleConfiguration.Rows[rowIndex].Cells['oSequence'].Value;
                role.Add = GridRoleConfiguration.Rows[rowIndex].Cells['Add'].Value;
                //role.Edit = GridRoleConfiguration.Rows[rowIndex].Cells['Edit'].Value;
                role.View = GridRoleConfiguration.Rows[rowIndex].Cells['View'].Value;
                //role.Delete = GridRoleConfiguration.Rows[rowIndex].Cells['Delete'].Value;
                role.Approval = GridRoleConfiguration.Rows[rowIndex].Cells['Approval'].Value;
                role.AssignTask = GridRoleConfiguration.Rows[rowIndex].Cells['AssignTask'].Value;
                PageMethods.UpdateRole(role, rowIndex, null, null);
            }
        }
    </script>
    <script language="javascript">
        function gridExpandCollapseLevel(level, isExpand) {
            if (level != null) {
                level = level - 1;
            }
            var tdArr = document.getElementsByTagName("DIV");
            var groupClassNamePrefix = "ob_gRGHB";

            for (i = 0; i < tdArr.length; i++) {
                var td = tdArr[i];
                if (td.className == groupClassNamePrefix) {
                    var img = tdArr[i].firstChild;

                    var tempLevel = tdArr[i].parentNode.childNodes.length - 3;
                    if (level == null || tempLevel == level) {
                        gridExpandCollapseGroup(img, isExpand);
                    }
                }
            }
        }
        function gridExpandCollapseGroup(img, isExpand) {
            if ((isExpand && img.src.indexOf("group_btn_open.gif") >= 0)
        || (!isExpand && img.src.indexOf("group_btn_close.gif") >= 0)) {
                GridRoleConfiguration.manageGroupExpandCollapse(img, false);
            }
        }
    </script>
</asp:Content>
