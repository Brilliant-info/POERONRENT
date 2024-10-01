﻿<%@ Page Title="Product Search" Language="C#" MasterPageFile="~/MasterPage/CRM2.Master"
    AutoEventWireup="true" Theme="Blue" CodeBehind="ProductSearch.aspx.cs" Inherits="PowerOnRentwebapp.Product.ProductSearch" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="gridFrame" width="800px" style="margin: 3px 3px 3px 3px;">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: left;">
                            <a class="headerText">Product List</a>
                        </td>
                        <td style="text-align: right;">
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" id="txtProductSearch" onkeyup="SearchProduct();" style="font-size: 15px;
                                            padding: 2px; width: 450px;" />
                                        <asp:HiddenField runat="server" ID="hdnFilterText" />
                                    </td>
                                    <td>
                                        <img src="../App_Themes/Blue/img/Search24.png" onclick="SearchProduct()" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="text-align: right;">
                            <input type="button" value="Submit" id="btnSubmitProductSearch1" onclick="selectedRec();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <obout:Grid ID="GridProductSearch" runat="server" AutoGenerateColumns="false" AllowFiltering="false"
                    AllowGrouping="true" AllowColumnResizing="true" AllowAddingRecords="false" AllowColumnReordering="true"
                    AllowMultiRecordSelection="true" CallbackMode="true" Width="100%" Serialize="false"
                    PageSize="25" AllowPageSizeSelection="false" AllowManualPaging="true" ShowTotalNumberOfPages="false"
                    KeepSelectedRecords="false">
                    <ClientSideEvents ExposeSender="true" />
                    <Columns>
                        <%-- <obout:CheckBoxSelectColumn ShowHeaderCheckBox="true" ControlType="Standard" Align="center"
                            HeaderAlign="center" Width="6%" ID="gvSelect" runat="server" AllowFilter="false"
                            ParseHTML="true">
                        </obout:CheckBoxSelectColumn>--%>
                        <obout:Column DataField="ID" Visible="false">
                        </obout:Column>
                        <obout:Column DataField="ProductType" Visible="false" HeaderText="Type" Width="0%"
                            AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="ProductCode" HeaderText="Product Code" Align="left" HeaderAlign="left"
                            Width="13%" AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="Name" HeaderText="Product Name" Align="left" HeaderAlign="left"
                            Width="20%" AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="Description" HeaderText="Description" Align="left" HeaderAlign="left"
                            Width="20%" AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="UOM" HeaderText="UOM" Align="left" HeaderAlign="left" Width="8%"
                            AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="PrincipalPrice" HeaderText="Price" Align="right" HeaderAlign="right"
                            Width="15%" AllowFilter="false" ParseHTML="true">
                            <TemplateSettings TemplateId="TemplateFieldAmount" />
                        </obout:Column>
                        <obout:Column DataField="ProductCategory" Visible="true" HeaderText="Category" Width="13%"
                            AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                        <obout:Column DataField="ProductSubCategory" Visible="true" HeaderText="Sub Category"
                            Width="15%" AllowFilter="false" ParseHTML="true">
                        </obout:Column>
                    </Columns>
                    <Templates>
                        <obout:GridTemplate runat="server" ID="TemplateFieldAmount">
                            <Template>
                                <span style="margin-right: 7px;">
                                    <%# Container.Value %></span>
                            </Template>
                        </obout:GridTemplate>
                    </Templates>
                </obout:Grid>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: left;">
                        </td>
                        <td style="text-align: right;">
                            <input type="button" value="Submit" id="btnSubmitProductSearch2" onclick="selectedRec();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hndgrupByGrid" runat="server" />
    <script type="text/javascript">
        window.onload = function () {
            oboutGrid.prototype.restorePreviousSelectedRecord = function () {
                return;
            }

            oboutGrid.prototype.markRecordAsSelectedOld = oboutGrid.prototype.markRecordAsSelected;
            oboutGrid.prototype.markRecordAsSelected = function (row, param2, param3, param4, param5) {
                if (row.className != this.CSSRecordSelected) {
                    this.markRecordAsSelectedOld(row, param2, param3, param4, param5);
                } else {
                    var index = this.getRecordSelectionIndex(row);
                    if (index != -1) {
                        this.markRecordAsUnSelected(row, index);
                    }
                }
            }
        }
        function selectedRec() {
            var hdnProductSearchSelectedRec = window.opener.document.getElementById("hdnProductSearchSelectedRec");
            hdnProductSearchSelectedRec.value = "";
            if (GridProductSearch.SelectedRecords.length > 0) {
                for (var i = 0; i < GridProductSearch.SelectedRecords.length; i++) {
                    var record = GridProductSearch.SelectedRecords[i];
                    if (hdnProductSearchSelectedRec.value != "") hdnProductSearchSelectedRec.value += ',' + record.ID;
                    if (hdnProductSearchSelectedRec.value == "") hdnProductSearchSelectedRec.value = record.ID;
                }
                window.opener.AfterProductSelected();
                self.close();
            }
            if (GridProductSearch.SelectedRecords.length == 0) {
                alert("Select atleast one product");
            }
        }

        var searchTimeout = null;
        function SearchProduct() {
            var hdnFilterText = document.getElementById("<%= hdnFilterText.ClientID %>");
            hdnFilterText.value = document.getElementById("txtProductSearch").value;
            if (searchTimeout != null) {
                window.clearTimeout(searchTimeout);
            }
            searchTimeout = window.setTimeout(performSearch, 700);
        }

        function performSearch() {
            GridProductSearch.refresh();
            searchTimeout = null;
            return false;
        }
       
    </script>
</asp:Content>
