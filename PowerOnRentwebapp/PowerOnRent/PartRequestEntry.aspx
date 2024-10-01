<%@ Page Title="Power On Rent | Material Request" Language="C#" MasterPageFile="~/MasterPage/CRM.Master"
    AutoEventWireup="true" CodeBehind="PartRequestEntry.aspx.cs" Inherits="PowerOnRentwebapp.PowerOnRent.PartRequestEntry"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="obout" %>
<%@ Register Src="../CommonControls/UC_Date.ascx" TagName="UC_Date" TagPrefix="uc1" %>
<%@ Register Src="../Product/UCProductSearch.ascx" TagName="UCProductSearch" TagPrefix="uc1" %>
<%@ Register Src="../CommonControls/Toolbar.ascx" TagName="Toolbar" TagPrefix="uc2" %>
<%@ Register Src="../CommonControls/UCFormHeader.ascx" TagName="UCFormHeader" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
    <uc2:Toolbar ID="Toolbar1" runat="server" />
    <uc2:UCFormHeader ID="UCFormHeader1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
     <style>        .custom_label_check{            background: url("../App_Themes/Blue/img/check-off.png") no-repeat;            padding-left: 25px;            padding-bottom: 10px;        }        .custom_label_check.c_on {            background: url("../App_Themes/Blue/img/check-on.png") no-repeat;        }        .custom_label_check input{             position: absolute;            left: -9999px;        }    </style>
    <center>
        <%--<span id="imgProcessing" style="display: none;">Please wait... </span>--%>
        <div id="divLoading" style="height: 110%; width: 100%; display: none; top: 0; left: 0;"
            class="modal" runat="server" clientidmode="Static">
            <center>
            </center>
        </div>
        <div class="divHead" id="divRequestHead">
            <h4>
                Material Request Detail
            </h4>
            <a onclick="javascript:divcollapsOpen('divRequestDetail',this)" id="linkRequest">Collapse</a>
        </div>
        <div class="divDetailExpand" id="divRequestDetail">
            <table class="tableForm">
                <tr>
                    <td>
                        Title* :
                    </td>
                    <td colspan="5" style="text-align: left;">
                        <asp:TextBox runat="server" ID="txtTitle" Width="99%" MaxLength="100" AccessKey="1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Site / Warehouse* :
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList runat="server" ID="ddlSites" Width="182px" DataTextField="Territory"
                            DataValueField="ID" AccessKey="1">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Request No.* :
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                        <%--<asp:TextBox runat="server" ID="lblRequestNo" Width="176px" AccessKey="1"></asp:TextBox>--%>
                        <asp:Label runat="server" ID="lblRequestNo" Width="176px" AccessKey="1"></asp:Label>
                    </td>
                    <td>
                        Status* :
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlStatus" Width="182px" AccessKey="1" DataTextField="Status"
                            DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Request Date* :
                    </td>
                    <td style="text-align: left;">
                        <uc1:UC_Date ID="UC_DateRequestDate" runat="server" AccessKey="1" />
                    </td>
                    <td>
                        Request Type* :
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList runat="server" ID="ddlRequestType" Width="182px" onchange="ddlRequestType_onchange(this);"
                            AccessKey="1">
                            <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Restock" Value="ReStock"></asp:ListItem>
                            <asp:ListItem Text="Urgent" Value="Urgent"></asp:ListItem>
                            <asp:ListItem Text="Engine Failure" Value="EngineFailure"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Requested By* :
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlRequestByUserID" Width="182px" AccessKey="1"
                            DataTextField="userName" DataValueField="userID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Remark :
                    </td>
                    <td colspan="5" style="text-align: left;">
                        <asp:TextBox runat="server" ID="txtRemark" Width="99%" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="height: 3px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="font-style: italic; text-align: left; font-weight: bold;">
                        <hr style="width: 80%; margin-top: 8px; float: right;" />
                        <span>Equipment Details</span>
                    </td>
                </tr>
                <tr id="TrReq1">
                    <td>
                        Container :
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList runat="server" ID="ddlContainer" Width="182px" onchange="jsGetEngineDetails(this)"
                            DataTextField="Container" DataValueField="ID" AccessKey="0">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Engine Model :
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                        <asp:Label runat="server" ID="lblEngineModel" Width="176px" AccessKey="1"></asp:Label>
                    </td>
                    <td>
                        Engine Serial No. :
                    </td>
                    <td style="text-align: left; font-weight: bold;">
                        <asp:Label runat="server" ID="lblEngineSerial" Width="176px" AccessKey="1"></asp:Label>
                    </td>
                </tr>
                <tr id="TrReq2">
                    <td>
                        Failure Hours :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFailureHours" MaxLength="6" Width="176px" AccessKey="0"
                            onkeypress="AllowInt(this,event);" onkeydown="AllowInt(this,event);"></asp:TextBox>
                    </td>
                    <td>
                        Cause of Failure :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFailureCause" onkeyup="TextBox_KeyUp(this,'CharactersCounter1','100');"
                            ClientIDMode="Static" Width="176px" TextMode="MultiLine" AccessKey="0"></asp:TextBox>
                        <br />
                        <span class="watermark"><span id="CharactersCounter1" accesskey="2">100</span> / 100
                        </span>
                    </td>
                    <td>
                        Nature of Failure :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFailureNature" onkeyup="TextBox_KeyUp(this,'CharactersCounter2','100');"
                            ClientIDMode="Static" Width="176px" TextMode="MultiLine" AccessKey="0"></asp:TextBox>
                        <br />
                        <span class="watermark"><span id="CharactersCounter2" accesskey="2">100</span> / 100
                        </span>
                    </td>
                </tr>
            </table>
            <table class="gridFrame" width="80%" id="tblCart">
                <tr>
                    <td>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <a class="headerText">Request Part List </a>
                                </td>
                                <td style="text-align: right;">
                                    <uc1:UCProductSearch ID="UCProductSearch1" runat="server" />
                                    <%--Add by Suresh--%>
                                   
                                            <asp:Button ID="btnNewPrduct" runat="server" Text="Add New Product" />
                                            <asp:Panel ID="PanelProduct" runat="server" align="center">
                                                <table class="gridFrame" id="tblNew" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="text-align: left;">
                                                                        <a class="headerText">New Product</a>
                                                                    </td>
                                                                    <td style="text-align: right;">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="cursor: pointer;"
                                                                            OnClick="btnSubmit_Onclick" />
                                                                        <asp:Button ID="btnClose" runat="server" Text="Cancel" Style="cursor: pointer;" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="background-color: White;">
                                                                <tr>
                                                                    <td style="color: Black; text-align: right;">
                                                                        Product Name :
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="*" ControlToValidate="txtProductName"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="color: Black; text-align: right;">
                                                                        Description :
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ErrorMessage="*" ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:HiddenField ID="hdnprodID" runat="server" />
                                            <cc1:ModalPopupExtender ID="ModelPopup1" runat="server" PopupControlID="PanelProduct"
                                                TargetControlID="btnNewPrduct" CancelControlID="btnClose" Drag="true">
                                            </cc1:ModalPopupExtender>
                                       
                                    <%--Add by Suresh--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <obout:Grid ID="Grid1" runat="server" CallbackMode="true" Serialize="true" AllowColumnReordering="true"
                            AllowColumnResizing="true" AutoGenerateColumns="false" AllowPaging="false" ShowLoadingMessage="true"
                            AllowSorting="false" AllowManualPaging="false" AllowRecordSelection="false" ShowFooter="false"
                            Width="100%" PageSize="-1" OnRebind="Grid1_OnRebind">
                            <ClientSideEvents ExposeSender="true" />
                            <Columns>
                                <obout:Column DataField="Sequence" HeaderText="Sr.No." AllowEdit="false" Width="7%"
                                    Align="left" HeaderAlign="center">
                                    <TemplateSettings TemplateId="ItemTempRemove" />
                                </obout:Column>
                                <obout:Column DataField="Prod_Code" HeaderText="Code" AllowEdit="false" Width="15%"
                                    HeaderAlign="left">
                                </obout:Column>
                                <obout:Column DataField="Prod_Name" HeaderText="Product Name" AllowEdit="false" Width="20%"
                                    HeaderAlign="left">
                                </obout:Column>
                                <obout:Column DataField="Prod_Description" HeaderText="Description" AllowEdit="false"
                                    Width="20%" HeaderAlign="left">
                                </obout:Column>
                                <obout:Column DataField="UOM" HeaderText="UOM" AllowEdit="false" Width="7%" HeaderAlign="left">
                                </obout:Column>
                                <obout:Column DataField="UOMID" AllowEdit="false" Width="0%" Visible="false">
                                </obout:Column>
                                <obout:Column DataField="RequestQty" Width="10%" HeaderAlign="center" HeaderText="Request Quantity"
                                    Align="center" AllowEdit="false">
                                    <TemplateSettings TemplateId="PlainEditTemplate" />
                                </obout:Column>
                                <obout:Column DataField="CurrentStock" HeaderText="Current Stock" AllowEdit="false"
                                    Width="10%" HeaderAlign="center" Align="right">
                                    <TemplateSettings TemplateId="GridTemplateRightAlign" />
                                </obout:Column>
                            </Columns>
                            <Templates>
                                <obout:GridTemplate ID="HeaderTempRequiredQuantity">
                                    <Template>
                                    </Template>
                                </obout:GridTemplate>
                                <obout:GridTemplate ID="ItemTempRemove">
                                    <Template>
                                        <table>
                                            <tr>
                                                <td style="width: 20px; text-align: center;">
                                                    <img id="imgbtnRemove" src="../App_Themes/Grid/img/Remove16x16.png" title="Remove"
                                                        onclick="removePartFromList('<%# (Container.DataItem["Sequence"].ToString()) %>');"
                                                        style="cursor: pointer;" />
                                                </td>
                                                <td style="width: 35px; text-align: right;">
                                                    <%# Convert.ToInt32(Container.PageRecordIndex) + 1 %>
                                                </td>
                                            </tr>
                                        </table>
                                    </Template>
                                </obout:GridTemplate>
                                <obout:GridTemplate runat="server" ID="PlainEditTemplate">
                                    <Template>
                                        <input type="text" class="excel-textbox" value="<%# Container.Value %>" onfocus="markAsFocused(this)"
                                            onkeydown="AllowDecimal(this,event);" onkeypress="AllowDecimal(this,event);"
                                            onblur="markAsBlured(this, '<%# Grid1.Columns[Container.ColumnIndex].DataField %>', <%# Container.PageRecordIndex %>)" />
                                    </Template>
                                </obout:GridTemplate>
                                <obout:GridTemplate ID="GridTemplateRightAlign">
                                    <Template>
                                        <span style="text-align: right; width: 130px; margin-right: 10px;">
                                            <%# Container.Value  %></span>
                                    </Template>
                                </obout:GridTemplate>
                            </Templates>
                        </obout:Grid>
                    </td>
                </tr>
            </table>
        </div>
        <div class="divHead" id="divApprovalHead" runat="server" clientidmode="Static">
            <h4>
                Approval Details
            </h4>
            <a onclick="javascript:divcollapsOpen('divApprovalDetail',this)" id="linkApprovalDetail">
                Collapse</a>
        </div>
        <div class="divDetailExpand" id="divApprovalDetail" runat="server" clientidmode="Static">
            <table class="tableForm">
                <tr>
                    <td style="font-size: 13px; font-weight: bold;">
                        Cummins Operation Approval * :
                    </td>
                    <%--<td style="vertical-align: top; font-size: 13px; font-weight: bold; text-align: left;">
                        <label class="label_check" id="lblApproved" for="CheckBoxApproved">
                            <asp:CheckBox ID="CheckBoxApproved" runat="server" ClientIDMode="Static" onclick="OnlyOneCheckedA('CheckBoxApproved','CheckBoxRejected');" />
                            Approved
                        </label>
                        <label class="label_check" id="lblRejected" for="CheckBoxRejected">
                            <asp:CheckBox ID="CheckBoxRejected" runat="server" ClientIDMode="Static" onclick="OnlyOneCheckedR('CheckBoxApproved','CheckBoxRejected');" />
                            Rejected
                        </label>
                    </td>--%>

                     <td style="vertical-align: top; font-size: 13px; font-weight: bold; text-align: left;">                        <label class="custom_label_check c_on" id="lblApproved" for="CheckBoxApproved">                            <asp:CheckBox ID="CheckBoxApproved" runat="server" ClientIDMode="Static" Checked="true" onclick="OnlyOneChecked('Approved', 'CheckBoxApproved','CheckBoxRejected');" />                            Approved                        </label>                        <label class="custom_label_check c_off" id="lblRejected" for="CheckBoxRejected">                            <asp:CheckBox ID="CheckBoxRejected" runat="server" ClientIDMode="Static" Checked="false" onclick="OnlyOneChecked('Rejected', 'CheckBoxApproved','CheckBoxRejected');" />                            Rejected                        </label>                    </td>
                </tr>
                <tr>
                    <td>
                        Date :
                    </td>
                    <td style="text-align: left;">
                        <asp:Label runat="server" ID="lblApprovalDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="tdApprovalRemark">
                        Remark :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtApprovalRemark" onkeyup="TextBox_KeyUp(this,'CharactersCountertxtApprovalRemark','200');"
                            ClientIDMode="Static" Width="400px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="text-align: left;">
                        <span class="watermark"><span id="CharactersCountertxtApprovalRemark">200</span> / 200
                        </span>
                        <input type="button" id="btnSaveApproval" value="Submit" style="float: right;" onclick="jsSaveApproval()"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="divHead" id="divIssueHead" runat="server" clientidmode="Static">
            <h4>
                Material Issue Detail
            </h4>
            <a onclick="javascript:divcollapsOpen('divIssueDetail',this)" id="linkIssueDetail">Collapse</a>
        </div>
        <div class="divDetailExpand" id="divIssueDetail" runat="server" clientidmode="Static">
            <iframe id="iframeIssue" src="../PowerOnRent/GridIssueSummary.aspx?FillBy=RequestID"
                style="border: none; width: 100%"></iframe>
        </div>
        <div class="divHead" id="divReceiptHead" runat="server" clientidmode="Static">
            <h4>
                Material Receipt Detail
            </h4>
            <a onclick="javascript:divcollapsOpen('divReceiptDetail',this)" id="linkReceiptDetail">
                Collapse</a>
        </div>
        <div class="divDetailExpand" id="divReceiptDetail" runat="server" clientidmode="Static">
            <iframe id="iframeReceipt" src="../PowerOnRent/GridReceiptSummary.aspx?FillBy=RequestID"
                style="border: none; width: 100%"></iframe>
        </div>
    </center>
    <script type="text/javascript">

        /*Navigation code*/
        function OpenEntryForm(invoker, state, referenceID, requestID) {
            if (state != "gray") {
                if (state == "red") { state = "Edit"; }
                else if (state != "red") { state = "View"; }
                pupUpLoading.style.display = "";
                PageMethods.WMSetSession(referenceID, requestID, state, OpenEntryFormOnSuccess, null);

            }
            else {
                showAlert("Not Applicable", "Error", "#");
            }
        }

    </script>
    <script type="text/javascript">
        /*Approval JS*/
        /*Approval checkbox Only one checked Approved or Rejected*/
        
        //function OnlyOneCheckedA(chkA, chkR) {
        //    debugger;
           
        //    var findtd = document.getElementById('tdApprovalRemark');
        //    if (CheckedA == "0") {
        //        if (document.getElementById(chkA).checked == true) {
        //            CheckedA = "1";
        //        findtd.innerHTML = "Remark / Reason : ";
        //        document.getElementById('txtApprovalRemark').accessKey = "";
        //        document.getElementById(chkR).checked = false;
        //        lblRejected.className = "label_check c_off";
        //    }
        //    }
            
        //}

        //function OnlyOneCheckedR(chkA, chkR) {
        //    var findtd = document.getElementById('tdApprovalRemark');

        //    if (document.getElementById(chkR).checked == true) {
        //        findtd.innerHTML = "Remark / Reason * :";
        //        document.getElementById('txtApprovalRemark').accessKey = "1";
        //        document.getElementById(chkA).checked = false;
        //        lblApproved.className = "label_check c_off";
        //    }
        //}


        /* ====================== OLD SCRIPT FOR APPROVAL CHECKBOX ============================ *//*        function OnlyOneCheckedA(chkA, chkR) {            debugger;            var findtd = document.getElementById('tdApprovalRemark');            if (document.getElementById(chkA).checked == true) {                findtd.innerHTML = "Remark / Reason : ";                document.getElementById('txtApprovalRemark').accessKey = "";                document.getElementById(chkR).checked = false;                lblRejected.className = "label_check c_off";            }        }        function OnlyOneCheckedR(chkA, chkR) {               debugger;            var findtd = document.getElementById('tdApprovalRemark');            if (document.getElementById(chkR).checked == true) {                findtd.innerHTML = "Remark / Reason * :";                document.getElementById('txtApprovalRemark').accessKey = "1";                document.getElementById(chkA).checked = false;                lblApproved.className = "label_check c_off";            }        }*/         /* ====================== OLD SCRIPT FOR APPROVAL CHECKBOX ============================ */         /* ====================== NEW SCRIPT FOR APPROVAL CHECKBOX ============================ */        function OnlyOneChecked(defaulVal, chkA, chkR) {            debugger;            // alert(defaulVal + ' : ' + chkA + ' : ' + chkR);            var findtd = document.getElementById('tdApprovalRemark');            if (defaulVal == 'Approved') {                findtd.innerHTML = "Remark / Reason : ";                document.getElementById('txtApprovalRemark').accessKey = "";                document.getElementById(chkA).checked = true;                document.getElementById(chkR).checked = false;                document.getElementById('lblApproved').className = 'custom_label_check c_on';                document.getElementById('lblRejected').className = 'custom_label_check c_off';            } else {                findtd.innerHTML = "Remark / Reason * :";                document.getElementById('txtApprovalRemark').accessKey = "1";                document.getElementById(chkA).checked = false;                document.getElementById(chkR).checked = true;                document.getElementById('lblApproved').className = 'custom_label_check c_off';                document.getElementById('lblRejected').className = 'custom_label_check c_on';            }        }        /* ====================== NEW SCRIPT FOR APPROVAL CHECKBOX ============================ */

        function jsSaveApproval() {
            debugger;
            var valuechk = document.getElementById('CheckBoxApproved').checked;
            if (document.getElementById('CheckBoxApproved').checked == false && document.getElementById('CheckBoxRejected').checked == false) {
                showAlert("Approval status should not be left blank [ Approved or Rejected ]", "Error", "#");
            }
            else if (document.getElementById('CheckBoxRejected').checked == true && document.getElementById('txtApprovalRemark').value == "") {
                showAlert("Fill rejection reason", "Error", "#");
                document.getElementById('txtApprovalRemark').focus();
            }
            else {
                LoadingOn(true);
                debugger;
                PageMethods.WMSaveApproval(document.getElementById('CheckBoxApproved').checked, document.getElementById('txtApprovalRemark').value, jsSaveApprovalOnSuccess, jsSaveApprovalOnFail);
            }
        }

        function jsSaveApprovalOnSuccess(result)
        {
                   debugger;
            if (result.toString().toLowerCase() == 'true') {
               // document.getElementById('imgProcessing').style.display = "none"; 
                showAlert("Approval status has been saved successfully", "info", "../PowerOnRent/Default.aspx?invoker=Request");
            }
            else {
                showAlert("Some error occurred", "error", "#");
            }
             LoadingOff();
        }
        function jsSaveApprovalOnFail() {
            debugger;
            LoadingOff();
        }

    </script>
    <script type="text/javascript">
        var txtTitle = document.getElementById("<%= txtTitle.ClientID %>");
        var ddlSites = document.getElementById("<%= ddlSites.ClientID %>");
        var lblRequestNo = document.getElementById("<%= lblRequestNo.ClientID %>");
        var ddlStatus = document.getElementById("<%= ddlStatus.ClientID %>");

        var ddlRequestType = document.getElementById("<%= ddlRequestType.ClientID %>");
        var ddlRequestByUserID = document.getElementById("<%= ddlRequestByUserID.ClientID %>");
        var txtRemark = document.getElementById("<%= txtRemark.ClientID %>");
        /*---------------*/
        var ddlContainer = document.getElementById("<%= ddlContainer.ClientID %>");
        var lblEngineModel = document.getElementById("<%= lblEngineModel .ClientID %>");
        var lblEngineSerial = document.getElementById("<%= lblEngineSerial.ClientID %>");
        var txtFailureHours = document.getElementById("<%= txtFailureHours.ClientID %>");
        var txtFailureCause = document.getElementById("<%= txtFailureCause.ClientID %>");
        var txtFailureNature = document.getElementById("<%= txtFailureNature.ClientID %>");

        /*Toolbar Code*/
        function jsAddNew() {
            PageMethods.WMpageAddNew(jsAddNewOnSuccess, null);
        }
        function jsAddNewOnSuccess() {
            //Grid1.refresh();
            //ClearMode('divRequestDetail');
            //jsFillStatusList('Add');
            window.open('../PowerOnRent/PartRequestEntry.aspx', '_self', '');
        }

        /*Add By Suresh */

        function OpenProductScreen() {
            window.open('../Product/ProductMaster.aspx', '_self', '');
        }
               
        /*Add By Suresh */

        function jsSaveData() {
            var validate = validateForm('divRequestDetail');
            if (validate == false) {
                showAlert("Fill all mandatory fields", "Error", "#");
            }
            else {
                if (ddlStatus.options[ddlStatus.selectedIndex].value == 2 && Grid1.Rows.length == 0) {
                    showAlert("Add atleast one part into the Request Part List", "error", "#");
                }
                else {
                    LoadingOn(true);
                    var RequestDate = getDateFromUC("<%= UC_DateRequestDate.ClientID %>");
                    var obj1 = new Object();
                    obj1.SiteID = parseInt(ddlSites.options[ddlSites.selectedIndex].value);
                    obj1.RequestNo = lblRequestNo.innerHTML.toString();
                    obj1.RequestType = ddlRequestType.options[ddlRequestType.selectedIndex].value.toString();
                    obj1.StatusID = parseInt(ddlStatus.options[ddlStatus.selectedIndex].value);
                    obj1.Title = txtTitle.value.toString();
                    obj1.RequestDate = RequestDate;
                    obj1.RequestBy = parseInt(ddlRequestByUserID.options[ddlRequestByUserID.selectedIndex].value);
                    obj1.Remark = txtRemark.value.toString();

                    obj1.FailureCause = txtFailureCause.value.toString();
                    obj1.FailureHours = txtFailureHours.value.toString();
                    obj1.FailureNature = txtFailureNature.value.toString();
                    obj1.EngineSerial = lblEngineSerial.innerHTML.toString();
                    obj1.EngineModel = lblEngineModel.innerHTML.toString();
                    obj1.GeneratorModel = "";
                    obj1.GeneratorSerial = "";
                    obj1.TransformerSerial = "";
                    obj1.Container = ddlContainer.options[ddlContainer.selectedIndex].text;
                    obj1.ProbableShippingDate = null;
                    if (ddlStatus.selectedIndex == 1) { obj1.IsSubmit = "false"; }
                    else { obj1.IsSubmit = "true"; }

                    PageMethods.WMSaveRequestHead(obj1, WMSaveRequestHead_onSuccessed, WMSaveRequestHead_onFailed);
                }
            }
        }

        function WMSaveRequestHead_onSuccessed(result) {
            if (result == "Some error occurred" || result == "") { showAlert("Error occurred", "Error", '#'); }
            else { showAlert(result, "info", "../PowerOnRent/Default.aspx?invoker=Request"); }
        }

        function WMSaveRequestHead_onFailed() { showAlert("Error occurred", "Error", "#"); }


        /*If Request Type is Machine Fuilure then Mandatory Expected Consuption Detials*/
        function ddlRequestType_onchange(ddl) {
            var TrReq1 = document.getElementById('TrReq1');
            var TrReq2 = document.getElementById('TrReq2');

            var allinput1 = TrReq1.getElementsByTagName('input');
            var allinput2 = TrReq2.getElementsByTagName('input');
            var alltd1 = TrReq1.getElementsByTagName('td');
            var alltd2 = TrReq2.getElementsByTagName('td');
            var allselect1 = TrReq1.getElementsByTagName('select');
            var allselect2 = TrReq1.getElementsByTagName('select');
            var alltextarea2 = TrReq2.getElementsByTagName('textarea');

            var i = 0;
            for (i = 0; i < alltextarea2.length; i++) {
                alltextarea2[i].accessKey = "";
            }

            for (i = 0; i < alltd1.length; i++) {
                //alltd1[i].className = "";
                alltd1[i].innerHTML = alltd1[i].innerHTML.toString().replace('*', '');
                i = i + 1;
            }
            for (i = 0; i < allinput1.length; i++) {
                allinput1[i].accessKey = "";
            }
            for (i = 0; i < allselect1.length; i++) {
                allselect1[i].accessKey = "";
            }


            for (i = 0; i < alltd2.length; i++) {
                //alltd2[i].className = "";
                alltd2[i].innerHTML = alltd2[i].innerHTML.toString().replace('*', '');
                i = i + 1;
            }
            for (i = 0; i < allinput2.length; i++) {
                allinput2[i].accessKey = "";
            }
            for (i = 0; i < allselect2.length; i++) {
                allselect2[i].accessKey = "";
            }

            if (ddl.selectedIndex > 1) {
                for (i = 0; i < alltextarea2.length; i++) {
                    alltextarea2[i].accessKey = "1";
                }

                for (i = 0; i < alltd1.length; i++) {
                    //alltd1[i].className = "req";
                    alltd1[i].innerHTML = alltd1[i].innerHTML.toString().replace(':', '* :');
                    i = i + 1;
                }
                for (i = 0; i < allinput1.length; i++) {
                    allinput1[i].accessKey = "1";
                }
                for (i = 0; i < allselect1.length; i++) {
                    allselect1[i].accessKey = "1";
                }


                for (i = 0; i < alltd2.length; i++) {
                    //alltd2[i].className = "req";
                    alltd2[i].innerHTML = alltd2[i].innerHTML.toString().replace(':', '* :');
                    i = i + 1;
                }
                for (i = 0; i < allinput2.length; i++) {
                    allinput2[i].accessKey = "1";
                }
                for (i = 0; i < allselect2.length; i++) {
                    allselect2[i].accessKey = "1";
                }
            }

        }
        /*End*/

        /*Request Part List*/
        function markAsFocused(textbox) {
            textbox.className = 'excel-textbox-focused';
            textbox.select();
        }

        function markAsBlured(textbox, dataField, rowIndex) {
            textbox.className = 'excel-textbox';

            var txtvalue = textbox.value;
            if (txtvalue == "") txtvalue = 0;
            textbox.value = parseFloat(txtvalue).toFixed(2);
            if (Grid1.Rows[rowIndex].Cells[dataField].Value != textbox.value) {
                Grid1.Rows[rowIndex].Cells[dataField].Value = textbox.value;
                PageMethods.WMUpdateRequestQty(getOrderObject(rowIndex), null, null);
            }
        }

        function getOrderObject(rowIndex) {
            /*Save Request qty into TempData when changed*/
            var order = new Object();
            order.Sequence = Grid1.Rows[rowIndex].Cells['Sequence'].Value;
            order.RequestQty = Grid1.Rows[rowIndex].Cells['RequestQty'].Value;
            return order;
        }

        function removePartFromList(sequence) {
            /*Remove Part from list*/
            var hdnProductSearchSelectedRec = document.getElementById('hdnProductSearchSelectedRec');
            hdnProductSearchSelectedRec.value = "";
            PageMethods.WMRemovePartFromRequest(sequence, removePartFromListOnSussess, null);
        }

        function removePartFromListOnSussess() { Grid1.refresh(); }
        /*End Request Part List*/

        /*Exp*/

        /*Get Engine Details when Select Engine*/
        function jsGetEngineDetails(ddl) {
            if (ddl.selectedIndex > 0) {
                PageMethods.WMGetEngineDetails(ddl.options[ddl.selectedIndex].value, jsGetEngineDetailsOnSussess, null);
            }
            else {
                lblEngineModel.innerHTML = "";
                lblEngineSerial.innerHTML = "";
            }
        }

        function jsGetEngineDetailsOnSussess(result) {
            lblEngineModel.innerHTML = result.EngineModel;
            lblEngineSerial.innerHTML = result.EngineSerial;

        }
        /*End*/


        /*Fill DropDown*/

        function jsFillStatusList(state) {
            ddlStatus.options.length = 0;
            ddlLoadingOn(ddlStatus);
            PageMethods.WMFillStatus(jsFillStatusListOnSuccessed, jsFillStatusListOnFailed);
        }
        function jsFillStatusListOnSuccessed(result) {
            var ddlS = ddlStatus;
            for (var i = 0; i < result.length; i++) {
                var option1 = document.createElement("option");

                option1.text = result[i].Status;
                option1.value = result[i].ID;
                try {
                    ddlS.add(option1, null); //Standard 
                } catch (error) {
                    ddlS.add(option1); // IE only
                }
            }
            ddlLoadingOff(ddlS);
            divVisibility();

        }

        function jsFillStatusListOnFailed() {
            ddlLoadingOff(ddlStatus);
        }
        function jsFillUsersList() {

            ddlRequestByUserID.options.length = 0;
            if (ddlSites.selectedIndex > 0) {
                ddlLoadingOn(ddlRequestByUserID);
                PageMethods.WMFillUserList(ddlSites.options[ddlSites.selectedIndex].value, jsFillUsersListOnSuccess, jsFillUsersListOnFail);
            }
        }

        function jsFillUsersListOnSuccess(result) {
            var ddlR = ddlRequestByUserID;

            for (var i = 0; i < result.length; i++) {
                var option1 = document.createElement("option");
                option1.text = result[i].userName;
                option1.value = result[i].userID;
                try {
                    ddlR.add(option1, null); //Standard 
                } catch (error) {
                    ddlR.add(option1); // IE only
                }
            }
            ddlLoadingOff(ddlR);
        }

        function jsFillUsersListOnFail() {
            ddlLoadingOff(ddlRequestByUserID);
        }


        function jsFillEnginList() {
            ddlContainer.options.length = 0;
            if (ddlSites.selectedIndex > 0) {
                ddlLoadingOn(ddlContainer);
                PageMethods.WMFillEnginList(ddlSites.options[ddlSites.selectedIndex].value, jsFillEnginListOnSuccess, jsFillEnginListOnFail);
            }
        }
        function jsFillEnginListOnSuccess(result) {
            var ddlEng = ddlContainer;

            for (var i = 0; i < result.length; i++) {
                var optionE1 = document.createElement("option");
                optionE1.text = result[i].Container;
                optionE1.value = result[i].ID;
                try {
                    ddlEng.add(optionE1, null); //Standard 
                } catch (error) {
                    ddlEng.add(optionE1); // IE only
                }
            }
            ddlLoadingOff(ddlEng);
        }

        function jsFillEnginListOnFail() {
            ddlLoadingOff(ddlContainer);
        }

        /*End*/

    </script>
    <script type="text/javascript">
        /*sections[Collapsable] code*/

        function divVisibility() {
            divApproval(false);
            divIssue(false);
            divReceipt(false);
            divConsumption(false);
            for (var i = 0; i < ddlStatus.options.length; i++) {
                if (ddlStatus.options[i].text == 'Approved') { divApproval(true); }
                else if (ddlStatus.options[i].text == 'Issued') { divIssue(true); }
                else if (ddlStatus.options[i].text == 'Received') { divReceipt(true); }
                else if (ddlStatus.options[i].text == 'Consumed') { divConsumption(true); }
            }
        }

        function divApproval(val) {
            if (val == true) {
                document.getElementById('divApprovalHead').style.display = "";
                document.getElementById('divApprovalDetail').style.display = "";
            }
            else if (val == false) {
                document.getElementById('divApprovalHead').style.display = "none";
                document.getElementById('divApprovalDetail').style.display = "none";
            }
        }

        function divIssue(val) {
            if (val == true) {
                document.getElementById('divIssueHead').style.display = "";
                document.getElementById('divIssueDetail').style.display = "";
            }
            else if (val == false) {
                document.getElementById('divIssueHead').style.display = "none";
                document.getElementById('divIssueDetail').style.display = "none";
            }
        }
        function divReceipt(val) {
            if (val == true) {
                document.getElementById('divReceiptHead').style.display = "";
                document.getElementById('divReceiptDetail').style.display = "";
            }
            else if (val == false) {
                document.getElementById('divReceiptHead').style.display = "none";
                document.getElementById('divReceiptDetail').style.display = "none";
            }
        }
        function divConsumption(val) {
            if (val == true) {
                document.getElementById('divConsumptionHead').style.display = "";
                document.getElementById('divConsumptionDetail').style.display = "";
            }
            else if (val == false) {
                document.getElementById('divConsumptionHead').style.display = "none";
                document.getElementById('divConsumptionDetail').style.display = "none";
            }
        }
        
    </script>
    <style type="text/css">
        /*Grid css*/
        .excel-textbox
        {
            background-color: transparent;
            border: 0px;
            padding: 0px;
            outline: 0;
            font: inherit;
            width: 91%;
            padding-top: 4px;
            padding-right: 2px;
            padding-bottom: 4px;
            text-align: right;
        }
        .excel-textbox-focused
        {
            background-color: #FFFFFF;
            border: 0px;
            padding: 0px;
            outline: 0;
            font: inherit;
            width: 91%;
            padding-top: 4px;
            padding-right: 2px;
            padding-bottom: 4px;
            text-align: right;
        }
        
        .excel-textbox-error
        {
            color: #FF0000;
        }
        
        .ob_gCc2
        {
            padding-left: 3px !important;
        }
        
        .ob_gBCont
        {
            border-bottom: 1px solid #C3C9CE;
        }
        
        .excel-checkbox
        {
            height: 20px;
            line-height: 20px;
        }
    </style>
    <style type="text/css">
        /*POR Collapsable Div*/
        
        .PanelCaption
        {
            color: Black;
            font-size: 13px;
            font-weight: bold;
            margin-top: -22px;
            margin-left: -5px;
            position: absolute;
            background-color: White;
            padding: 0px 2px 0px 2px;
        }
        .divHead
        {
            border: solid 2px #F5DEB3;
            width: 99%;
            text-align: left;
        }
        .divHead h4
        {
            /*color: #33CCFF;*/
            color: #483D8B;
            margin: 3px 3px 3px 3px;
        }
        .divHead a
        {
            float: right;
            margin-top: -15px;
            margin-right: 5px;
        }
        .divHead a:hover
        {
            cursor: pointer;
            color: Red;
        }
        .divDetailExpand
        {
            border: solid 2px #F5DEB3;
            border-top: none;
            width: 99%;
            padding: 5px 0 5px 0;
        }
        .divDetailCollapse
        {
            display: none;
        }
        /*End POR Collapsable Div*/
    </style>
    <script type="text/javascript">
        /*Checkbox js for css*/
         var CheckedA = "0";
        var d = document;
        var safari = (navigator.userAgent.toLowerCase().indexOf('safari') != -1) ? true : false;
        var gebtn = function (parEl, child) { return parEl.getElementsByTagName(child); };
        onload = function () {

            var body = gebtn(d, 'body')[0];
            body.className = body.className && body.className != '' ? body.className + ' has-js' : 'has-js';

            if (!d.getElementById || !d.createTextNode) return;
            var ls = gebtn(d, 'label');
            for (var i = 0; i < ls.length; i++) {
                var l = ls[i];
                if (l.className.indexOf('label_') == -1) continue;
                var inp = gebtn(l, 'input')[0];
                if (l.className == 'label_check') {
                    l.className = (safari && inp.checked == true || inp.checked) ? 'label_check c_on' : 'label_check c_off';
                    l.onclick = check_it;
                };
                if (l.className == 'label_radio') {
                    l.className = (safari && inp.checked == true || inp.checked) ? 'label_radio r_on' : 'label_radio r_off';
                    l.onclick = turn_radio;
                };
            };
        };
        var check_it = function () {
            var inp = gebtn(this, 'input')[0];
            if (this.className == 'label_check c_off' || (!safari && inp.checked)) {
                this.className = 'label_check c_on';
                if (safari) inp.click();
            } else {
                this.className = 'label_check c_off';
                if (safari) inp.click();
            };
        };
        var turn_radio = function () {
            var inp = gebtn(this, 'input')[0];
            if (this.className == 'label_radio r_off' || inp.checked) {
                var ls = gebtn(this.parentNode, 'label');
                for (var i = 0; i < ls.length; i++) {
                    var l = ls[i];
                    if (l.className.indexOf('label_radio') == -1) continue;
                    l.className = 'label_radio r_off';
                };
                this.className = 'label_radio r_on';
                if (safari) inp.click();
            } else {
                this.className = 'label_radio r_off';
                if (safari) inp.click();
            };
        };
        /*End*/

    </script>
    <style type="text/css">
        .has-js .label_check, .has-js .label_radio
        {
            padding-left: 25px;
            padding-bottom: 10px;
        }
        .has-js .label_radio
        {
            background: url(../App_Themes/Blue/img/radio-off.png) no-repeat;
        }
        .has-js .label_check
        {
            background: url("../App_Themes/Blue/img/check-off.png") no-repeat;
        }
        .has-js label.c_on
        {
            background: url("../App_Themes/Blue/img/check-on.png") no-repeat;
        }
        .has-js label.r_on
        {
            background: url(../App_Themes/Blue/img/radio-on.png) no-repeat;
        }
        .has-js .label_check input, .has-js .label_radio input
        {
            position: absolute;
            left: -9999px;
        }
    </style>
</asp:Content>
