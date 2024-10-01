﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ProductCategoryMaster.aspx.cs" Inherits="PowerOnRentwebapp.Product.ProductCategoryMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="obout_Interface" Namespace="Obout.Interface" TagPrefix="obout" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<%@ Register Src="../CommonControls/UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc1" %>
<%@ Register Src="../CommonControls/UCToolbar.ascx" TagName="UCToolbar" TagPrefix="uc2" %>
<%--<%@ Register src="UCProductSearch.ascx" tagname="UCProductSearch" tagprefix="uc3" %>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc2:UCToolbar ID="UCToolbar1" runat="server" />
    <uc1:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <center>
        <asp:UpdateProgress ID="UpdateProgress_ProductCategoryM" runat="server" AssociatedUpdatePanelID="updPnl_ProductCategoryM">
            <ProgressTemplate>
                <center>
                    <div class="modal">
                        <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%;" />
                    </div>
                </center>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ValidationSummary ID="validationsummary_ProductCatMaster" runat="server" ShowMessageBox="true"
            ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="Save" />
        <asp:UpdatePanel ID="updPnl_ProductCategoryM" runat="server">
            <ContentTemplate>
                <table class="tableForm">
                    <tr>
                        <td>
                            <req>Product Category :</req>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtPrdCategory" runat="server" Width="200px" onKeyPress="return alpha(event);"
                                ValidationGroup="Save" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRftxtPrdCategory" runat="server" ControlToValidate="txtPrdCategory"
                                ErrorMessage="Please Enter Product Category" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Sequence No.:
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtSequence" runat="server" Width="70px" MaxLength="3" onkeypress="return AllowInt(this, event);"></asp:TextBox>
                            <asp:RangeValidator ID="valRangtxtSequence" runat="server" ControlToValidate="txtSequence"
                                ErrorMessage="Please enter a valid number(0...1000)." MinimumValue="0" MaximumValue="1000"
                                Type="Integer" SetFocusOnError="True" Display="None">
                            </asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <req>Active :</req>
                        </td>
                        <td style="text-align: left">
                            <obout:OboutRadioButton ID="rbtnYes" runat="server" Text="Yes" GroupName="rbtnActive"
                                Checked="true">
                            </obout:OboutRadioButton>
                            <obout:OboutRadioButton ID="rbtnNo" runat="server" Text="No" GroupName="rbtnActive">
                            </obout:OboutRadioButton>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnPrdCategoryID" runat="server" />
                <table class="gridFrame" width="70%">
                    <tr>
                        <td>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: left;">
                                        <a id="headerText">Product Category List</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <obout:Grid ID="gvPrdCat" runat="server" AllowAddingRecords="false" AllowFiltering="true"
                                AllowGrouping="true" AutoGenerateColumns="false" OnSelect="gvPrdCat_Select" Width="100%">
                                <Columns>
                                    <obout:Column ID="Column1" DataField="Edit" HeaderText="Edit" runat="Server" Width="1%"
                                        AllowFilter="false">
                                        <TemplateSettings TemplateId="imgBtnEdit1" />
                                    </obout:Column>
                                    <obout:Column DataField="ID" HeaderText="ID" Visible="false">
                                    </obout:Column>
                                    <obout:Column DataField="Sequence" HeaderText="Sequence No." Width="2%">
                                    </obout:Column>
                                    <obout:Column DataField="Name" HeaderText="Product Category" Width="6%">
                                    </obout:Column>
                                    <obout:Column DataField="Active" HeaderText="Active" Width="1%">
                                    </obout:Column>
                                </Columns>
                                <Templates>
                                    <obout:GridTemplate runat="server" ID="imgBtnEdit1">
                                        <Template>
                                            <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="../App_Themes/Blue/img/Edit16.png"
                                                ToolTip="Edit" />
                                        </Template>
                                    </obout:GridTemplate>
                                </Templates>
                            </obout:Grid>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
