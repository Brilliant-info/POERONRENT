﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductSearch.ascx.cs"
    Inherits="PowerOnRentwebapp.Product.UCProductSearch" %>
<input type="button" value="Add Items To List" id="btnProductSearch" onclick="openwindowProductSearch();" />
<asp:HiddenField ID="hdnProductSearchSelectedRec" runat="server" ViewStateMode="Enabled"
    ClientIDMode="Static" />
<script type="text/javascript">
    function openwindowProductSearch() {
        window.open('../Product/ProductSearch.aspx', null, 'height=700px, width=825px,status= 0, resizable= 1, scrollbars=1, toolbar=0,location=center,menubar=0, screenX=300; screenY=50');
    }

    function AfterProductSelected() {
        window.parent.Grid1.refresh();
        document.getElementById("hdnProductSearchSelectedRec").value = "";
    }
</script>
