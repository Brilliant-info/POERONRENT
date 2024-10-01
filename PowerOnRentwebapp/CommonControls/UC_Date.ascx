﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Date.ascx.cs" Inherits="PowerOnRentwebapp.CommonControls.UC_Date" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:TextBox ID="txtDate" runat="server" Width="82px" placeholder="DD-MMM-YYYY" MaxLength="11"
    onchange="validateDateFormat(this);" onkeyup="giveSeprator(this);" onfocus="onfocusSelect(this)"></asp:TextBox>
<asp:ValidationSummary ID="validationsummary_date" runat="server" ShowMessageBox="true"
    ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="Save" />
<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True"
    TargetControlID="txtDate" PopupButtonID="ImgDate" Format="dd-MMM-yyyy">
</cc1:CalendarExtender>
<asp:Image runat="server" ID="ImgDate" ImageUrl="~/App_Themes/Blue/img/Calendar24.png"
    Style="width: 20px; height: 20px; margin-bottom: -5px; cursor: pointer;" />
<asp:RequiredFieldValidator ID="RFVDate" runat="server" ControlToValidate="txtDate"
    ErrorMessage="Select Date" Display="None"></asp:RequiredFieldValidator>