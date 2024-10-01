<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    CodeBehind="HomeSetupPOR.aspx.cs" Inherits="PowerOnRentwebapp.CommonControls.HomeSetupPOR" %>

<%@ Register Src="UCToolbar.ascx" TagName="UCToolbar" TagPrefix="uc1" %>
<%@ Register Src="UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc2:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <center>
        <asp:UpdateProgress ID="UpdateProgress_HomeSetup" runat="server" AssociatedUpdatePanelID="updPnl_HomeSetup">
            <progresstemplate>
                <center>
                    <div class="modal">
                        <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%;" />
                    </div>
                </center>
            </progresstemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="updPnl_HomeSetup" runat="server">
            <contenttemplate>
                <br />
                <br />
                <br />
                <table class="tableForm">
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/companymgm.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnCompanyMang" runat="server" CssClass="ParentGroup">Company Management</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/user_Management.png" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnUserMang0" runat="server" CssClass="ParentGroup">User Management</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/productmanagement.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnProductMang" runat="server" CssClass="ParentGroup">Part Management</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 350px;">
                            <a href="../POR/SiteMaster.aspx">Site Master</a> | <a href="../POR/EngineMaster.aspx">
                                Engine Master</a> | <a href="../POR/AssetMaster.aspx">Asset Master</a>
                                <br />
                                <a href="../POR/ToolTransfer.aspx">Tool Transfer</a>
                        </td>
                        <td style="text-align: left;">
                            <a href="../UserManagement/DepartmentMaster.aspx">Department Master</a> | <a href="../UserManagement/DesignationMaster.aspx">
                                Designation Master</a> | <a href="../UserManagement/RoleMaster.aspx">Role Master</a>
                            <br />
                            <a href="../UserManagement/UserCreation.aspx">User Master</a> | <a href="../Approval/ApprovalLevelMaster.aspx">
                                Approval Master</a>
                        </td>
                        <td style="text-align: left">
                            <a href="../Product/ProductCategoryMaster.aspx">Category Master</a> | <a href="../Product/ProductSubCategoryMaster.aspx">
                                Sub Category Master</a>
                            <br />
                            <a href="../Product/ProductMaster.aspx">Part Master</a> </span>
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>

                    <tr>
                        <%--<td rowspan="2">
                            <img alt="" src="HomeSetupImg/productmanagement.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnProductMang" runat="server" CssClass="ParentGroup">Part Management</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>--%>
                    </tr>
                    <tr>
                        <%--<td style="text-align: left">
                            <a href="../Product/ProductCategoryMaster.aspx">Category Master</a> | <a href="../Product/ProductSubCategoryMaster.aspx">
                                Sub Category Master</a>
                            <br />
                            <a href="../Product/ProductMaster.aspx">Part Master</a> </span>
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>--%>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/inventory.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="ParentGroup">Inventory</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/purchase.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="ParentGroup">Purchase</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/Dashboard.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnLeadMang" runat="server" CssClass="ParentGroup">DashBoard</asp:LinkButton>
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <a href="../PowerOnRent/Default.aspx?invoker=Request">Material Request</a> | <a href="../PowerOnRent/Default.aspx?invoker=Issue">
                                Material Issue</a>
                            <br />
                            <a href="../PowerOnRent/Default.aspx?invoker=Receipt">Material Receipt</a> | <a href="../PowerOnRent/Default.aspx?invoker=Consumption">
                                Consumption</a>
                        </td>
                        <td style="text-align: left;">
                            <font color="gray">Purchase Request</font> |<font color="gray"> Purchase Order</font>
                            <br />
                            <font color="gray">Invoice Booking</font>
                        </td>
                        <td style="text-align: left">
                            <a href="../POR/DashboardPOR.aspx?invoker=engine">Engine Wise</a> | <a href="../POR/DashboardPOR.aspx?invoker=site">
                                Site Wise</a> | <a href="../POR/DashboardPOR.aspx?invoker=product">Product Wise</a>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <%--<td rowspan="2">
                            <img alt="" src="HomeSetupImg/Dashboard.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnLeadMang" runat="server" CssClass="ParentGroup">DashBoard</asp:LinkButton>
                        </td>--%>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="lnkBtnActivityMang" runat="server" CssClass="ParentGroup">Report</asp:LinkButton>
                        </td>
                    </tr>

                    <tr>
                        <%--<td style="text-align: left">
                            <a href="../POR/DashboardPOR.aspx?invoker=engine">Engine Wise</a> | <a href="../POR/DashboardPOR.aspx?invoker=site">
                                Site Wise</a> | <a href="../POR/DashboardPOR.aspx?invoker=product">Product Wise</a>
                        </td>--%>
                        <td style="text-align: left">
                            <a href="../PowerOnRent/CommonReport.aspx?invoker=partrequest">Part Requisition Report</a>
                            | <a href="../PowerOnRent/CommonReport.aspx?invoker=partissue">Part Issue Report</a>
                            <%--  | <a href="../POR/PRS_Report_Para.aspx?invoker=PartStock">Part Stock Report</a>--%>
                            <br />
                            <a href="../PowerOnRent/CommonReport.aspx?invoker=partreceipt">Part Receipt Report</a>
                            | <a href="../PowerOnRent/CommonReport.aspx?invoker=partconsumption">Part Consumption
                                Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <%--    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/Dashboad1.png" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="ParentGroup">Enginewise Dashboard</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="ParentGroup">Part Requisition Report</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <a href="../POR/DashboardPOR.aspx?invoker=engine">Enginewise</a>
                        </td>
                        <td style="text-align: left">
                            <a href="../POR/PRS_Report_Para.aspx?invoker=PartRequisition">Part Requisition Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/dashboard.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="ParentGroup">Sitewise Dashboard</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="ParentGroup">Part Stock Report</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <a href="../POR/DashboardPOR.aspx?invoker=site">Sitewise</a>
                        </td>
                        <td style="text-align: left">
                            <a href="../POR/PRS_Report_Para.aspx?invoker=PartConsumption">Part Stock Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/dasbaord2.png" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="ParentGroup">Productwise Consumption Dashboard</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="ParentGroup">Part Issue Report</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <a href="../POR/DashboardPOR.aspx?invoker=product">Productwise</a>
                        </td>
                        <td style="text-align: left">
                            <a href="../POR/PRS_Report_Para.aspx?invoker=PartIssue">Part Issue Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="ParentGroup">Part Receipt Report</asp:LinkButton>
                        </td>
                        <td rowspan="2">
                            <img alt="" src="HomeSetupImg/reports.jpg" />
                        </td>
                        <td style="text-align: left">
                            <asp:LinkButton ID="LinkButton10" runat="server" CssClass="ParentGroup">Part Consumption Report</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <a href="../POR/PRS_Report_Para.aspx?invoker=PartReceipt">Part Receipt Report</a>
                        </td>
                        <td style="text-align: left">
                            <a href="../POR/PRS_Report_Para.aspx?invoker=PartIssue">Part Consumption Report</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    --%></table>
            </contenttemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
