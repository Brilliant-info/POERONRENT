<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ApprovalLevelMaster.aspx.cs" Inherits="PowerOnRentwebapp.Approval.ApprovalLevelMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="obout" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<%@ Register Src="../CommonControls/UCToolbar.ascx" TagName="UCToolbar" TagPrefix="uc1" %>
<%@ Register Src="../CommonControls/UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc2" %>
<%@ Register Src="../Territory/UC_Territory.ascx" TagName="UC_Territory" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc1:UCToolbar ID="UCToolbar1" runat="server" />
    <uc2:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <asp:UpdateProgress ID="UpdateProgress_approvalM" runat="server" AssociatedUpdatePanelID="approvalM">
        <ProgressTemplate>
            <center>
                <div class="modal">
                    <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%;" />
                </div>
            </center>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ValidationSummary ID="validationsummary_ApprovalMaster" runat="server" ShowMessageBox="true"
        ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="Save" />
    <asp:UpdatePanel ID="approvalM" runat="server">
        <ContentTemplate>
            <center>
                <asp:TabContainer ID="tabApprovalLevelMaster" runat="server" ActiveTabIndex="0" Width="100%">
                    <asp:TabPanel ID="tabApproval" runat="server" TabIndex="0">
                        <HeaderTemplate>
                            Approval Levels</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <asp:HiddenField ID="hdnDiscountID" runat="server" />
                                <table class="gridFrame" style="width: 60%">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <a id="headerText">Approval Level List</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <obout:Grid ID="gvApprovalLevelM" runat="server" AllowAddingRecords="False" AllowFiltering="True"
                                                AllowGrouping="True" AutoGenerateColumns="False" Width="100%" OnSelect="gvApprovalLevelM_Select">
                                                <Columns>
                                                    <obout:Column ID="Column1" DataField="Edit" Width="2%" AllowFilter="False" Align="center"
                                                        HeaderAlign="Center" HeaderText="Edit" Index="0" TemplateId="imgBtnEdit1">
                                                        <TemplateSettings TemplateId="imgBtnEdit1" />
                                                    </obout:Column>
                                                    <obout:Column DataField="ID" HeaderText="ID" Visible="False" Index="1">
                                                    </obout:Column>
                                                    <obout:Column DataField="ObjectName" HeaderText="Object Name" Width="3%" Index="2">
                                                    </obout:Column>
                                                    <obout:Column DataField="ApprovalLevel" HeaderText="Approval Level" Width="3%" Index="3">
                                                    </obout:Column>
                                                    <obout:Column DataField="NoOfApprovers" HeaderText="No. Of Approvers" Width="3%"
                                                        Index="4">
                                                    </obout:Column>
                                                    <obout:Column DataField="Active" HeaderText="Active" Width="2%" Index="8">
                                                    </obout:Column>
                                                </Columns>
                                                <Templates>
                                                    <obout:GridTemplate runat="server" ID="imgBtnEdit1">
                                                        <Template>
                                                            <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="../App_Themes/Blue/img/Edit16.png"
                                                                ToolTip="Edit" CausesValidation="false" />
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
                    <asp:TabPanel ID="panApprovalDetail" runat="server" TabIndex="1">
                        <HeaderTemplate>
                            Approval Level
                        </HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table class="tableForm">
                                    <tr>
                                        <td colspan="4">
                                            <uc3:UC_Territory ID="UC_Territory1" runat="server" ClientIDMode="Static" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <req> Object Name :</req>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="ddlObjectName" runat="server" Width="206px" DataTextField="ObjectDisplayName"
                                                DataValueField="ObjectName" ValidationGroup="Save" onchange="getNewApprovalLevel(this);">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="valRefddlObjectName" runat="server" ErrorMessage="Please Select Object name"
                                                ControlToValidate="ddlObjectName" InitialValue="0" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <req>No. of Approvers :</req>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApprovalNo" runat="server" Width="100px" onkeypress="return AllowInt(this, event);"
                                                MaxLength="2" onkeydown="return NotAllowSpecialChar(this, event);" ValidationGroup="Save"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valRftxtApprovalNo" runat="server" ControlToValidate="txtApprovalNo"
                                                ErrorMessage="Please Enter No.of Approval" ValidationGroup="Save" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <req>Approval Level :</req>
                                        </td>
                                        <td style="text-align: left">
                                            <%--<asp:Label ID="lblApprovalLevel" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label>--%>
                                            <asp:TextBox ID="lblApprovalLevel" runat="server" Font-Bold="true" ClientIDMode="Static"
                                                Style="border: none;" onkeypress="return false" AutoCompleteType="None"></asp:TextBox>
                                        </td>
                                        <td>
                                            <req>Active :</req>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:RadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="rbtnActive" Checked="true" />
                                            <asp:RadioButton ID="rbtnNo" runat="server" Text="Yes" GroupName="rbtnActive" Checked="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="3" style="text-align: left;">
                                            <span class="watermark">Note : 1 [ Higher Level ] ... 4 [ Lower Level ] </span>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <asp:HiddenField ID="hdnStatus" runat="server" />
                            <asp:HiddenField ID="hdnApprovalID" runat="server" />
                            <asp:HiddenField ID="hdnApprovalUserID" runat="server" />
                            <table class="gridFrame" style="width: 100%">
                                <tr>
                                    <td>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="text-align: left;">
                                                    <a class="headerText">Select Approvers</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <obout:Grid ID="gvUserCreation" runat="server" AllowAddingRecords="False" AllowFiltering="True"
                                            Width="100%" AllowGrouping="True" AutoGenerateColumns="False">
                                            <Columns>
                                                <obout:Column DataField="checked" HeaderText="Select" Width="5%">
                                                    <TemplateSettings TemplateId="GvTempEdit" />
                                                </obout:Column>
                                                <obout:Column DataField="ID" HeaderText="ID" Visible="false">
                                                </obout:Column>
                                                <obout:Column DataField="EmployeeID" HeaderText="Employee ID" Width="9%">
                                                </obout:Column>
                                                <obout:Column DataField="Name" HeaderText="Employee Name" Width="20%">
                                                </obout:Column>
                                                <obout:Column DataField="RoleName" HeaderText="Role Name" Width="10%">
                                                </obout:Column>
                                                <obout:Column DataField="DeptName" HeaderText="Department" Width="10%">
                                                </obout:Column>
                                                <obout:Column DataField="DesiName" HeaderText="Designation" Width="10%">
                                                </obout:Column>
                                                <obout:Column DataField="EmailID" HeaderText="Email ID" Width="20%">
                                                </obout:Column>
                                                <obout:Column DataField="MobileNo" HeaderText="Mobile No." Width="12%">
                                                </obout:Column>
                                                <obout:Column DataField="PhoneNo" HeaderText="Phone No." Width="12%">
                                                </obout:Column>
                                                <obout:Column DataField="Active" HeaderText="Active" Width="6%">
                                                </obout:Column>
                                            </Columns>
                                            <Templates>
                                                <obout:GridTemplate ID="GvTempEdit">
                                                    <Template>
                                                        <asp:CheckBox runat="server" ID="chk" onclick="getSelectedUsersApprovalLevel(this);"
                                                            Checked='<%# (Container.Value == "true" ? true : false) %>' />
                                                    </Template>
                                                </obout:GridTemplate>
                                            </Templates>
                                        </obout:Grid>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function getSelectedUsersApprovalLevel(invoker) {
            var hdnApprovalUserID = document.getElementById("<%= hdnApprovalUserID.ClientID %>");
            var userno = document.getElementById("<%= txtApprovalNo.ClientID %>").value;
            var m = gvUserCreation.GridBodyContainer;
            hdnApprovalUserID.value = "";
            var checkedcount = 0;
            var allInput = m.getElementsByTagName('input');
            for (var c = 0; c < allInput.length; c++) {
                var chk = allInput[c];
                if (chk.type == "checkbox") {
                    if (chk.checked == true) {
                        checkedcount = checkedcount + 1;
                        if (parseInt(checkedcount) > parseInt(userno)) {
                            invoker.checked = false;
                            alert("You can't select more than " + userno + " users");
                            break;
                        }

                        if (hdnApprovalUserID.value != "") hdnApprovalUserID.value += ',' + gvUserCreation.Rows[c].Cells['ID'].Value;
                        if (hdnApprovalUserID.value == "") hdnApprovalUserID.value = gvUserCreation.Rows[c].Cells['ID'].Value;
                    }
                }
            }
        }

        function getNewApprovalLevel(invoker) {
            var TerritoryID = document.getElementById("hdnTerritoryID").value;
            PageMethods.PMGetApprovalLevelByObjectName(invoker.value, parseInt(TerritoryID), onsuccess_getNewApprovalLevel, null);
        }

        function onsuccess_getNewApprovalLevel(result) {
            document.getElementById("lblApprovalLevel").value = result;
        }

        function clearChild() {
            document.getElementById("lblApprovalLevel").value = "";
            document.getElementById("<%= ddlObjectName.ClientID %>").selectedIndex = 0;
        }
    </script>
</asp:Content>
