<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCommonFilter.ascx.cs"
    Inherits="PowerOnRentwebapp.PowerOnRent.UCCommonFilter" %>
<%@ Register Src="../CommonControls/UC_Date.ascx" TagName="UC_Date" TagPrefix="ucd55" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<div>
    <center>
        <table>
            <tr>
                <td>
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <div id="FDate" runat="server">
                                        From Date
                                        <ucd55:UC_Date ID="FrmDate" runat="server" />
                                    </div>
                                </td>
                                <td>
                                    <div id="TDate" runat="server">
                                        To Date
                                        <ucd55:UC_Date ID="To_Date" runat="server" />
                                    </div>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <div id="PrdCategory" runat="server">
                                        Product Category
                                        <asp:DropDownList ID="ddlCategory" runat="server" DataValueField="ID" DataTextField="ProductCategory"
                                            Width="200px" ClientIDMode="Static" onchange="div2(this);">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div id="SiteList" runat="server">
                                        Site List
                                        <asp:DropDownList ID="ddlSite" runat="server" DataValueField="ID" DataTextField="Territory"
                                            Width="200px" ClientIDMode="Static" onchange="div1(this);">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div id="ExcludeZero" runat="server">
                                        <input type="checkbox" id="chkExcludeZero" onclick="ExcludeZero(this);" />
                                        <a>Exclude Zero Available Balance</a>
                                    </div>
                                </td>
                                <td>
                                    <div id="frmSite" runat="server">
                                        From Site
                                        <asp:DropDownList ID="ddlFrmSite" runat="server" DataValueField="ID" DataTextField="Territory"
                                            Width="200px" ClientIDMode="Static" onchange="divTrAnsfer(this);">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <div id="toSite" runat="server">
                                        To Site
                                        <asp:DropDownList ID="ddlToSite" runat="server" Width="200px" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="vertical-align: top;">
                                <table id="tblEngine" runat="server" class="gridFrame" width="650px" style="margin: 3px 3px 3px 3px;
                                    vertical-align: top;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <a class="headerText">Engine List</a>
                                                    </td>
                                                   
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="text-align: right;">
                                                                    <input type="checkbox" id="chkSelectAllEngine" onclick="SelectAllEngine(this);" />
                                                                    <a class="headerText">Select All Engine</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <obout:Grid ID="GVEngineInfo" runat="server" AllowAddingRecords="false" AutoGenerateColumns="false"
                                                AllowColumnResizing="true" AllowFiltering="true" AllowManualPaging="true" AllowColumnReordering="true"
                                                AllowRecordSelection="true" AllowMultiRecordSelection="true" AllowGrouping="true"
                                                Width="100%" Serialize="true" CallbackMode="true" OnRebind="GVEngineInfo_OnRebind"
                                                PageSize="10" AllowPaging="true" AllowPageSizeSelection="true">
                                                <ClientSideEvents ExposeSender="true" />
                                                <Columns>
                                                    <%-- <obout:CheckBoxSelectColumn AllowSorting="true" ControlType="Standard" Align="left"
                                                        ShowHeaderCheckBox="true" HeaderAlign="left" Width="5%">
                                                    </obout:CheckBoxSelectColumn>--%>
                                                    <obout:Column DataField="ID" HeaderText="ID" Visible="false">
                                                    </obout:Column>
                                                    <obout:Column DataField="EngineSerial" HeaderText="Engine Serial No." Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="Container" HeaderText="Container" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="EngineModel" HeaderText="Engine Model" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="EngineSerial" HeaderText="Engine Serial" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="GeneratorModel" HeaderText="Generator Model" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="Territory" HeaderText="Site" Width="10%">
                                                    </obout:Column>
                                                </Columns>
                                            </obout:Grid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblRequest" runat="server" class="gridFrame" width="650px" style="margin: 3px 3px 3px 3px;
                                    vertical-align: top;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <a class="headerText">Request List</a>
                                                    </td>
                                                    <%-- <td style="text-align: right;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtRequestSearch" runat="server" ClientIDMode="Static" Style="font-size: 15px;
                                                                        padding: 2px; width: 250px;" onkeyup="SearchRequest();"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <img src="../App_Themes/Blue/img/Search24.png" onclick="SearchRequest()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>--%>
                                                    <%--<td style="text-align: right;">
                                                        <input type="button" value=">>" id="btnRequest" onclick="SelectedRequestRec();" />
                                                    </td>--%>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="text-align: right;">
                                                                    <input type="checkbox" id="chkSelectAll" onclick="SelectAllRequest(this);" />
                                                                    <a class="headerText">Select All Request</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <obout:Grid ID="GVRequestInfo" runat="server" AutoGenerateColumns="false" AllowFiltering="false"
                                                AllowGrouping="true" AllowColumnResizing="true" AllowAddingRecords="false" AllowColumnReordering="true"
                                                AllowMultiRecordSelection="true" AllowRecordSelection="true" CallbackMode="true"
                                                Width="100%" Serialize="true" PageSize="10" AllowPageSizeSelection="false" AllowManualPaging="true"
                                                ShowTotalNumberOfPages="false" OnRebind="GVRequestInfo_OnRebind">
                                                <ClientSideEvents ExposeSender="true" />
                                                <Columns>
                                                    <%-- <obout:CheckBoxSelectColumn AllowSorting="true" ShowHeaderCheckBox="true" ControlType="Standard"
                                                        Width="3%" Align="left" HeaderAlign="left" ParseHTML="true">
                                                    </obout:CheckBoxSelectColumn>--%>
                                                    <obout:Column DataField="PRH_ID" HeaderText="Request No." Width="10%" AllowFilter="false"
                                                        ParseHTML="true">
                                                    </obout:Column>
                                                    <obout:Column DataField="RequestDate" HeaderText="Requisition Date" Width="10%" DataFormatString="{0:dd-MMM-yyyy}"
                                                        AllowFilter="false" ParseHTML="true">
                                                    </obout:Column>
                                                    <obout:Column DataField="RequestByUserName" HeaderText="Requisition By" Width="10%"
                                                        AllowFilter="false" ParseHTML="true">
                                                    </obout:Column>
                                                </Columns>
                                            </obout:Grid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblIssue" runat="server" class="gridFrame" width="650px" style="margin: 3px 3px 3px 3px;
                                    vertical-align: top;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <a class="headerText">Issue List</a>
                                                    </td>
                                                    <%-- <td style="text-align: right;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtIssueSearch" runat="server" ClientIDMode="Static" Style="font-size: 15px;
                                                                        padding: 2px; width: 250px;" onkeyup="SearchIssue();"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <img src="../App_Themes/Blue/img/Search24.png" onclick="SearchIssue()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>--%>
                                                    <%--<td style="text-align: right;">
                                                        <input type="button" value=">>" id="btnIssue" onclick="SelectedIssueRec();" />
                                                    </td>--%>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="text-align: right;">
                                                                    <input type="checkbox" id="chkSelectAllIssue" onclick="SelectAllIssue(this);" />
                                                                    <a class="headerText">Select All Issue</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <obout:Grid ID="GVIssueInfo" runat="server" AutoGenerateColumns="false" AllowFiltering="false"
                                                AllowGrouping="true" AllowColumnResizing="true" AllowAddingRecords="false" AllowColumnReordering="true"
                                                AllowMultiRecordSelection="true" AllowRecordSelection="true" CallbackMode="true"
                                                Width="100%" Serialize="true" PageSize="10" AllowPageSizeSelection="false" AllowManualPaging="true"
                                                ShowTotalNumberOfPages="false" OnRebind="GVIssueInfo_OnRebind" KeepSelectedRecords="true">
                                                <ClientSideEvents ExposeSender="true" />
                                                <Columns>
                                                    <%-- <obout:CheckBoxSelectColumn AllowSorting="true" ControlType="Standard" Width="3%"
                                                        Align="left" ShowHeaderCheckBox="true" HeaderAlign="left">
                                                    </obout:CheckBoxSelectColumn>--%>
                                                    <%-- <obout:Column Dat  aField="MINH_ID" HeaderText="ID" Visible="false">
                                                    </obout:Column>--%>
                                                    <obout:Column DataField="MINH_ID" HeaderText="Issue No" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="IssueDate" HeaderText="Issue Date" Width="10%" DataFormatString="{0:dd-MMM-yyyy}">
                                                    </obout:Column>
                                                    <obout:Column DataField="IssuedByUserName" HeaderText="Issued By" Width="10%">
                                                    </obout:Column>
                                                </Columns>
                                            </obout:Grid>
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblReceipt" runat="server" class="gridFrame" width="650px" style="margin: 3px 3px 3px 3px;
                                    vertical-align: top;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left">
                                                        <a class="headerText">Receipt List</a>
                                                    </td>
                                                    <%--<td style="text-align: right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtReceiptSearch" runat="server" ClientIDMode="Static" Style="font-size: 15px;
                                                                        padding: 2px; width: 250px;" onkeyup="SearchReceipt();"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <img src="../App_Themes/Blue/img/Search24.png" onclick="SearchReceipt()" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>--%>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="text-align: right;">
                                                                    <input type="checkbox" id="chkSelectAllReceipt" onclick="SelectAllReceipt(this);" />
                                                                    <a class="headerText">Select All Receipt</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <obout:Grid ID="GVReceiptInfo" runat="server" AllowAddingRecords="false" AutoGenerateColumns="false"
                                                AllowColumnResizing="true" AllowFiltering="true" AllowManualPaging="true" AllowColumnReordering="true"
                                                AllowMultiRecordSelection="true" AllowRecordSelection="true" AllowGrouping="true"
                                                Width="100%" Serialize="true" CallbackMode="true" PageSize="10" OnRebind="GVReceiptInfo_OnRebind"
                                                AllowPaging="true" AllowPageSizeSelection="true">
                                                <ClientSideEvents ExposeSender="true" />
                                                <Columns>
                                                    <%-- <obout:CheckBoxSelectColumn AllowSorting="true" ControlType="Standard" Width="3%"
                                                        Align="left" ShowHeaderCheckBox="true" HeaderAlign="left">
                                                    </obout:CheckBoxSelectColumn>--%>
                                                    <%-- <obout:Column DataField="GRNH_ID" HeaderText="ID" Visible="false">
                                                    </obout:Column>--%>
                                                    <obout:Column DataField="GRNH_ID" HeaderText="Receipt No." Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="GRN_Date" HeaderText="Receipt Date" Width="10%" DataFormatString="{0:dd-MMM-yyyy}">
                                                    </obout:Column>
                                                    <obout:Column DataField="ReceiptByUserName" HeaderText="Receipt By" Width="10%">
                                                    </obout:Column>
                                                </Columns>
                                            </obout:Grid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align: top;">
                                <table id="tblProduct" runat="server" class="gridFrame" width="600px" style="margin: 3px 3px 3px 3px;
                                    vertical-align: top;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left;">
                                                        <a class="headerText">Part List</a>
                                                    </td>
                                                    <td style="text-align: right;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <%-- <asp:TextBox runat="server" ID="txtProductSearch" ClientIDMode="Static" Style="font-size: 15px;
                                                                        padding: 2px; width: 250px;" onkeyup="SearchProduct();"></asp:TextBox>--%>
                                                                    <input type="text" id="txtProductSearch" onkeyup="SearchProduct();" style="font-size: 15px;
                                                                        padding: 2px; width: 325px;" />
                                                                    <asp:HiddenField runat="server" ID="hdnFilterText" />
                                                                </td>
                                                                <td>
                                                                    <img src="../App_Themes/Blue/img/Search24.png" onclick="SearchProduct()" />
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <input type="checkbox" id="chkSelectProduct" onclick="SelectAllProduct(this);" />
                                                                                <a class="headerText">Select All Product</a>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <%-- <td style="text-align: right;">
                                                    <input type="button" value=">>" id="btnProduct" onclick="selectedProductRec();" />
                                                    </td> --%>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <obout:Grid ID="GVProductInfo" runat="server" AllowAddingRecords="false" AutoGenerateColumns="false"
                                                AllowColumnResizing="true" AllowFiltering="true" AllowManualPaging="true" AllowColumnReordering="true"
                                                AllowMultiRecordSelection="true" AllowRecordSelection="true" AllowGrouping="true"
                                                Width="100%" Serialize="true" CallbackMode="true" OnRebind="GVProductInfo_OnRebind"
                                                PageSize="10" AllowPaging="true" AllowPageSizeSelection="true">
                                                <ClientSideEvents ExposeSender="true" />
                                                <Columns>
                                                    <%--  <obout:CheckBoxSelectColumn AllowSorting="true" ControlType="Standard" Width="5%"
                                                        Align="left" ShowHeaderCheckBox="true" HeaderAlign="left">
                                                    </obout:CheckBoxSelectColumn>--%>
                                                    <obout:Column DataField="ID" HeaderText="ID" Visible="false">
                                                    </obout:Column>
                                                    <obout:Column DataField="ProductCode" HeaderText="Part Code" Width="10%">
                                                    </obout:Column>
                                                    <obout:Column DataField="Name" HeaderText="Part Name" Width="10%">
                                                    </obout:Column>
                                                    <%--<obout:Column DataField="Description" HeaderText="Part Description" Width="10%">
                                                    </obout:Column>--%>
                                                    <obout:Column DataField="ProductCategory" HeaderText="Part Category" Width="10%">
                                                    </obout:Column>
                                                </Columns>
                                            </obout:Grid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfCount" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hfEng" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hndGroupByGrid" runat="server" />
        <asp:HiddenField ID="hndGroupByPrd" runat="server" />
        <asp:HiddenField ID="hdnEngineSelectedRec" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProductSelectedRec" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnRequestSelectedRec" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnIssueSelectedRec" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnReceiptSelectedRec" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnProductCategory" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnAllReq" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnAllPrd" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnAllIsue" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnAllRecpt" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnAllEng" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnExcludeZero" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnSelectedFromSite" runat="server" ClientIDMode="Static" />        

    </center>
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
                if (getParameterByName("invoker").toString() == "partissue") {
                    SelectedIssueRec();
                }
                if (getParameterByName("invoker").toString() == "partrequest") {
                    SelectedRequestRec();
                }
                if (getParameterByName("invoker").toString() == "partconsumption") {
                    selectedEngineRec();
                }
                if (getParameterByName("invoker").toString() == "partreceipt") {
                    SelectedReceiptRec();
                }

            }
        }
        function div1(obj) {
            var hfCount = document.getElementById("hfCount");
            hfCount.value = null;
            if (obj.options[obj.selectedIndex].text == 'Select All') {
                var hfCount = document.getElementById("hfCount");
                var opt = document.getElementById("ddlSite");
                for (i = 0; i < opt.options.length; i++) {
                    if (opt.options[i].selected) { }
                    else {
                        if (hfCount.value == "") {
                            hfCount.value = obj.options[i].value;
                        }
                        else {
                            hfCount.value = hfCount.value + "," + obj.options[i].value;
                        }
                    }
                }
            }
            else {
                hfCount.value = obj.options[obj.selectedIndex].value;
            }
            if (getParameterByName('invoker') == "partrequest") {
                GVRequestInfo.refresh();
            }
            else if (getParameterByName('invoker') == "partconsumption") {
                GVEngineInfo.refresh();
            }
            else if (getParameterByName('invoker') == "partissue") {
                GVIssueInfo.refresh();
            }
            else if (getParameterByName('invoker') == "partreceipt") {
                GVReceiptInfo.refresh();
            }
            else if (getParameterByName('invoker') == "productdtl") {
                GVProductInfo.refresh();
            }
        }
        function selectedEngineRec() {
            var hdnEngineSelectedRec = document.getElementById("hdnEngineSelectedRec");
            var oldEngineSelected = hdnEngineSelectedRec.value;
            hdnEngineSelectedRec.value = "0";
            if (GVEngineInfo.PageSelectedRecords.length > 0) {
                for (var i = 0; i < GVEngineInfo.PageSelectedRecords.length; i++) {
                    var record = GVEngineInfo.PageSelectedRecords[i];
                    if (hdnEngineSelectedRec.value != "0") hdnEngineSelectedRec.value += ',' + record.EngineSerial;
                    if (hdnEngineSelectedRec.value == "0") hdnEngineSelectedRec.value = record.EngineSerial;
                }
                if (oldEngineSelected != hdnEngineSelectedRec.value) {
                    GVProductInfo.refresh();
                }
            }

        }
        function GVEngineInfo_Deselect(index) {
            selectedEngineRec();
        }
        function selectedProductRec() {
            var hdnProductSelectedRec = document.getElementById("hdnProductSelectedRec");
            var oldProducttSelected = hdnProductSelectedRec.value;
            hdnProductSelectedRec.value = "0";
            if (GVProductInfo.PageSelectedRecords.length > 0) {
                for (var i = 0; i < GVProductInfo.PageSelectedRecords.length; i++) {
                    var record = GVProductInfo.PageSelectedRecords[i];
                    if (hdnProductSelectedRec.value != "0") hdnProductSelectedRec.value += ',' + record.ID;
                    if (hdnProductSelectedRec.value == "0") hdnProductSelectedRec.value = record.ID;
                }
                if (oldProducttSelected != hdnProductSelectedRec.value) {
                    GVProductInfo.refresh();

                }
            }
        }
        function GVProductInfo_Deselect(index) {
            selectedProductRec();
        }

        function SelectedRequestRec() {
            var hdnRequestSelectedRec = document.getElementById("hdnRequestSelectedRec");
            var oldReqSelected = hdnRequestSelectedRec.value;
            hdnRequestSelectedRec.value = "";
            for (var i = 0; i < GVRequestInfo.PageSelectedRecords.length; i++) {
                var record = GVRequestInfo.PageSelectedRecords[i];
                if (hdnRequestSelectedRec.value != "") hdnRequestSelectedRec.value += ',' + record.PRH_ID;
                if (hdnRequestSelectedRec.value == "") hdnRequestSelectedRec.value = record.PRH_ID;
            }
            if (oldReqSelected != hdnRequestSelectedRec.value) {
                GVProductInfo.refresh();
            }
        }

        function GVRequestInfo_Deselect(index) {
            SelectedRequestRec();
        }

        function SelectedIssueRec() {
            var hdnIssueSelectedRec = document.getElementById("hdnIssueSelectedRec");
            var oldIssueSelected = hdnIssueSelectedRec.value;
            hdnIssueSelectedRec.value = "0";
            if (GVIssueInfo.PageSelectedRecords.length > 0) {
                for (var i = 0; i < GVIssueInfo.PageSelectedRecords.length; i++) {
                    var record = GVIssueInfo.PageSelectedRecords[i];
                    if (hdnIssueSelectedRec.value != "0") hdnIssueSelectedRec.value += ',' + record.MINH_ID;
                    if (hdnIssueSelectedRec.value == "0") hdnIssueSelectedRec.value = record.MINH_ID;
                }
                if (oldIssueSelected != hdnIssueSelectedRec.value) {
                    GVProductInfo.refresh();
                }
            }
        }
        function GVIssueInfo_Deselect(index) {
            SelectedIssueRec();
        }
        function SelectedReceiptRec() {
            var hdnReceiptSelectedRec = document.getElementById("hdnReceiptSelectedRec");
            var oldReceiptSelected = hdnReceiptSelectedRec.value;
            hdnReceiptSelectedRec.value = "0";
            if (GVReceiptInfo.PageSelectedRecords.length > 0) {
                for (var i = 0; i < GVReceiptInfo.PageSelectedRecords.length; i++) {
                    var record = GVReceiptInfo.PageSelectedRecords[i];
                    if (hdnReceiptSelectedRec.value != "0") hdnReceiptSelectedRec.value += ',' + record.GRNH_ID;
                    if (hdnReceiptSelectedRec.value == "0") hdnReceiptSelectedRec.value = record.GRNH_ID;
                }
                if (oldReceiptSelected != hdnReceiptSelectedRec.value) {
                    GVProductInfo.refresh();
                }
            }
        }
        function GVReceiptInfo_Deselect(index) {
            SelectedReceiptRec();
        }
        var searchlength;
        function SearchEngine() {
            if (searchlength != document.getElementById("txtEngineSearch").value.length) {
                searchlength = document.getElementById("txtEngineSearch").value.length;
                if (document.getElementById("txtEngineSearch").value.length % 2 == 0) {
                    GVEngineInfo.refresh();
                }
            }
        }
        //        var searchlength1;
        //        function SearchProduct() {
        //            if (searchlength1 != document.getElementById("txtProductSearch").value.length) {
        //                searchlength1 = document.getElementById("txtProductSearch").value.length;
        //                if (document.getElementById("txtProductSearch").value.length % 2 == 0) {
        //                    GVProductInfo.refresh();
        //                }
        //            }
        //        }

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
            GVProductInfo.refresh();
            searchTimeout = null;
            return false;
        }
        var searchlength1;
        function SearchRequest() {
            if (searchlength1 != document.getElementById("txtRequestSearch").value.length) {
                searchlength1 = document.getElementById("txtRequestSearch").value.length;
                if (document.getElementById("txtRequestSearch").value.length % 2 == 0) {
                    GVRequestInfo.refresh();
                }
            }
        }
        var searchlength1;
        function SearchIssue() {
            if (searchlength1 != document.getElementById("txtIssueSearch").value.length) {
                searchlength1 = document.getElementById("txtIssueSearch").value.length;
                if (document.getElementById("txtIssueSearch").value.length % 2 == 0) {
                    GVIssueInfo.refresh();
                }
            }
        }
        var searchlength1;
        function SearchReceipt() {
            if (searchlength1 != document.getElementById("txtReceiptSearch").value.length) {
                searchlength1 = document.getElementById("txtReceiptSearch").value.length;
                if (document.getElementById("txtReceiptSearch").value.length % 2 == 0) {
                    GVReceiptInfo.refresh();
                }
            }
        }


        /*Report viewer code*/       
        function jsGetReportData() {
            var SelectedPart = document.getElementById("hdnProductSelectedRec").value;
            var SelectedReq = document.getElementById("hdnRequestSelectedRec").value;
            var SelectedIssue = document.getElementById("hdnIssueSelectedRec").value;
            var SelectedReceipt = document.getElementById("hdnReceiptSelectedRec").value;
            var SelectedConsumption = document.getElementById("hdnEngineSelectedRec").value;
            var SiteIDs = document.getElementById("hfCount").value;
            var txtFromDt = getDateTextBoxFromUC("<%= FrmDate.ClientID %>");
            var txtToDt = getDateTextBoxFromUC("<%= To_Date.ClientID %>");
            var SelectedCategory = document.getElementById("hdnProductCategory").value;
            var hdnAllReq = document.getElementById("hdnAllReq");
            var hdnAllPrd = document.getElementById("hdnAllPrd");
            var hdnAllIsue = document.getElementById("hdnAllIsue");
            var hdnAllRecpt = document.getElementById("hdnAllRecpt");
            var hdnAllEng = document.getElementById("hdnAllEng");
            var hdnExcludeZero = document.getElementById("hdnExcludeZero");

            var ddlFrmSite = document.getElementById("<%=ddlFrmSite.ClientID %>");
            var ddlToSite = document.getElementById("<%=ddlToSite.ClientID %>");



            if (getParameterByName("invoker").toString() == "partrequest") {
                if (SiteIDs == "") { showAlert("Select Site ", "Error", "#"); }
                else if (SelectedReq == "") { showAlert("Select atleast one Request", "Error", "#"); }
                else if (SelectedPart == "") { showAlert("Select atleast one part", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), SelectedPart, SelectedReq, txtFromDt.value, txtToDt.value, SiteIDs, hdnAllReq.value, hdnAllPrd.value, jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "partissue") {
                if (SelectedIssue == "") { showAlert("Select atleast one Issue", "Error", "#"); }
                else if (SelectedPart == "") { showAlert("Select atleast one part", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), SelectedPart, SelectedIssue, txtFromDt.value, txtToDt.value, SiteIDs, hdnAllIsue.value, hdnAllPrd.value, jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "partreceipt") {
                if (SelectedReceipt == "") { showAlert("Select atleast one Receipt", "Error", "#"); }
                else if (SelectedPart == "") { showAlert("Select atleast one part", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), SelectedPart, SelectedReceipt, txtFromDt.value, txtToDt.value, SiteIDs, hdnAllRecpt.value, hdnAllPrd.value, jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "partconsumption") {
                if (SelectedConsumption == "") { showAlert("Select atleast one Engine", "Error", "#"); }
                else if (SelectedPart == "") { showAlert("Select atleast one part", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), SelectedPart, SelectedConsumption, txtFromDt.value, txtToDt.value, SiteIDs, hdnAllEng.value, hdnAllPrd.value, jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "monthly") {
                if (SiteIDs == "") { showAlert("Select Site ", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), "", "", txtFromDt.value, txtToDt.value, SiteIDs, "", "", jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "weeklylst") {
                if (SiteIDs == "") { showAlert("Select Site ", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), "", "", txtFromDt.value, txtToDt.value, SiteIDs, "", "", jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "consumabletracker") {
                if (SelectedCategory == "") { showAlert("Select Atleast one Product Category", "Error", "#"); }
                else if (SiteIDs == "") { showAlert("Select Site ", "Error", "#"); }
                else {                 
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), "", SelectedCategory, txtFromDt.value, txtToDt.value, SiteIDs, "", "", jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "productdtl") {
                if (SelectedPart == "") { showAlert("Select Atleast one Part ", "Error", "#"); }
                else if (SiteIDs == "") { showAlert("Select Site ", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), SelectedPart, "", txtFromDt.value, txtToDt.value, SiteIDs, hdnExcludeZero.value, hdnAllPrd.value, jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "transfer") {
                if (ddlFrmSite == "") { showAlert("Select From Site ", "Error", "#"); }
                else if (ddlToSite == "") { showAlert("Select To Site ", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), ddlToSite.value, ddlFrmSite.value, txtFromDt.value, txtToDt.value, "", "", "", jsGetReportDataOnSuccess, null)
                }
            }
            if (getParameterByName("invoker").toString() == "asset") {
                if (ddlFrmSite == "") { showAlert("Select From Site ", "Error", "#"); }
                else if (ddlToSite == "") { showAlert("Select To Site ", "Error", "#"); }
                else {
                    LoadingOn();
                    PageMethods.WMGetReportData(getParameterByName("invoker").toString(), ddlToSite.value, ddlFrmSite.value, txtFromDt.value, txtToDt.value, "", "", "", jsGetReportDataOnSuccess, null)
                }
            }
        }

        function jsGetReportDataOnSuccess(result) {
            if (parseInt(result) > 0) {
                ShowReportOn();
            }
            else {
                showAlert("Data Not Available... ", "Error", "#");
                LoadingOff();
                ShowReportOff();
            }
        }
        function ShowReportOn() {
            document.getElementById("iframePORRpt").src = "../POR/Reports/ReportViewer.aspx";
            divPopUp.className = "divDetailExpandPopUpOn";
        }

        function ShowReportOff() {
            divPopUp.className = "divDetailExpandPopUpOff";
            LoadingOff();
        }

        function div2(obj) {
            var hdnProductCategory = document.getElementById('hdnProductCategory');
            hdnProductCategory.value = obj.options[obj.selectedIndex].value;
        }

        function SelectAllRequest(chk) {
            var hdnAllReq = document.getElementById("hdnAllReq");
            hdnAllReq.value = "0";
            if (chk.checked == true) {
                hdnAllReq.value = "1";
                document.getElementById("hdnRequestSelectedRec").value = "0";
                GVRequestInfo.refresh();
            }
            else {
                deselectAll(GVRequestInfo);
                document.getElementById("hdnRequestSelectedRec").value = "";
            }
        }

        function deselectAll(gv) {
            for (i = 0; i < gv.Rows.length; i++) {
                gv.deselectRecord(i);
            }
            gv.SelectedRecordsContainer.value = "";
            gv.SelectedRecords = new Array();
        }
        function SelectAllProduct(chk) {
            var hdnAllPrd = document.getElementById("hdnAllPrd");
            hdnAllPrd.value = "0";
            if (chk.checked == true) {
                hdnAllPrd.value = "1";
                document.getElementById("hdnProductSelectedRec").value = "0";
                GVProductInfo.refresh();
            }
            else {
                deselectAll(GVProductInfo);
                document.getElementById("hdnProductSelectedRec").value = "";
            }
        }
        function SelectAllEngine(chk) {
            var hdnAllEng = document.getElementById("hdnAllEng");
            hdnAllEng.value = "0";
            if (chk.checked == true) {
                hdnAllEng.value = "1";
                document.getElementById("hdnEngineSelectedRec").value = "0";
                GVEngineInfo.refresh();
            }
            else {
                deselectAll(GVEngineInfo);
                document.getElementById("hdnEngineSelectedRec").value = "";
            }
        }
        function SelectAllIssue(chk) {
            var hdnAllIsue = document.getElementById("hdnAllIsue");
            hdnAllIsue.value = "0";
            if (chk.checked == true) {
                hdnAllIsue.value = "1";
                document.getElementById("hdnIssueSelectedRec").value = "0";
                GVIssueInfo.refresh();
            }
            else {
                deselectAll(GVIssueInfo);
                document.getElementById("hdnIssueSelectedRec").value = "";
            }
        }
        function SelectAllReceipt(chk) {
            var hdnAllRecpt = document.getElementById("hdnAllRecpt");
            hdnAllRecpt.value = "0";
            if (chk.checked == true) {
                hdnAllRecpt.value = "1";
                document.getElementById("hdnReceiptSelectedRec").value = "0";
                GVReceiptInfo.refresh();
            }
            else {
                deselectAll(GVReceiptInfo);
                document.getElementById("hdnReceiptSelectedRec").value = "";
            }
        }
        function ExcludeZero(chk) {
            var hdnExcludeZero = document.getElementById("hdnExcludeZero");
            hdnExcludeZero.value = "0";
            if (chk.checked == true) {
                hdnExcludeZero.value = "1";
            }
        }
        function divTrAnsfer() {
            var ddlFrmSite = document.getElementById("<%=ddlFrmSite.ClientID %>");

            var hdnSelectedFromSite = document.getElementById('hdnSelectedFromSite');
            hdnSelectedFromSite.value = ddlFrmSite.value;

            var frmSite = ddlFrmSite.value;
            PageMethods.WMGetFromSite(frmSite, OnSuccessFromSite, null);
        }

        function OnSuccessFromSite(result) {
            ddlToSite = document.getElementById("<%=ddlToSite.ClientID %>");
            ddlToSite.options.length = 0;
            var option0 = document.createElement("option");

            if (result.length > 0) {
                option0.text = '--Select--';
                option0.value = '0';
            }
            else {
                option0.text = 'N/A';
                option0.value = '0';
            }

            try {
                ddlToSite.add(option0, null);
            }
            catch (Error) {
                ddlToSite.add(option0);
            }

            for (var i = 0; i < result.length; i++) {
                var option1 = document.createElement("option");
                option1.text = result[i].Territory;
                option1.value = result[i].ID;
                try {
                    ddlToSite.add(option1, null);
                }
                catch (Error) {
                    ddlToSite.add(option1);
                }
            }
        }
    </script>
</div>
