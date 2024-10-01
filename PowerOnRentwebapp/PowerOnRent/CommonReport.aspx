<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/CRM.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="CommonReport.aspx.cs" Inherits="PowerOnRentwebapp.PowerOnRent.CommonReport"
    Theme="Blue" %>

<%@ Register Src="UCCommonFilter.ascx" TagName="UCCommonFilter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHolder_FormHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPHolder_Form" runat="server">
    <center>
        <div id="divLoading" style="height: 71%; width: 50%; display: none; top: 40; left: 260px;"
            class="modal">
            <center>
             <img src="../App_Themes/Blue/img/ajax-loader.gif" style="top: 50%; margin-top:22%"; />
             <br /><br />
             <b>Please Wait...</b>
            </center>
        </div>
       <%-- <div class="divDetailExpandPopUpOff" id="divPopUp">
            <center>
                <div class="popupClose" onclick="CloseShowReport()">
                </div>
                <div class="divDetailExpand" id="div1">
                    <iframe runat="server" id="iframePORRpt" clientidmode="Static" src="#" width="80%"
                        style="border: none; height: 550px;"></iframe>
                </div>
            </center>
        </div>--%>
        <table id="tblRptMenu">
            <tr>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=partrequest">
                        <img alt="" src="../CommonControls/HomeSetupImg/ActivityManagement.jpg" /></a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=partrequest" style="font-weight: bold;" id="partrequisition"
                        runat="server">Part Requisition Report</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=partissue">
                        <img alt="" src="Img/report1.png" /></a>
                </td>
                <td>
                    <a href="CommonReport.aspx?invoker=partissue" style="font-weight: bold;" id="partissue"
                        runat="server">Part Issue Report</a>
                </td>
                <%-- <td rowspan="2">
                    <img alt="" src="Img/report2.png" />
                </td>--%>
                <%-- <td>
                    <a href="CommonReport.aspx?invoker=partstock">Part Stock Report</a>
                </td>--%>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=partreceipt">
                        <img alt="" src="Img/report3.png" /></a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=partreceipt" style="font-weight: bold;" id="partreceipt"
                        runat="server">Part Receipt Report</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=partconsumption">
                        <img alt="" src="Img/Report4.png" />
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=partconsumption" style="font-weight: bold;" id="partconsumption"
                        runat="server">Part Consumption Report</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=monthly">
                        <img alt="" src="../CommonControls/HomeSetupImg/my_reports.png" />
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=monthly" style="font-weight: bold;" id="monthly"
                        runat="server">PR-Report Monthly</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=weeklylst">
                        <img alt="" src="../CommonControls/HomeSetupImg/reports.jpg" />
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=weeklylst" style="font-weight: bold;" id="weeklylst"
                        runat="server">Weekly Analysis</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=consumabletracker">
                        <img alt="" src="../CommonControls/HomeSetupImg/report.png" />
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=consumabletracker" style="font-weight: bold;"
                        id="consumabletracker" runat="server">Consumable Tracker</a>
                </td>
                 <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=productdtl">
                        <img alt="" src="../POR/Img/PrdRpt.jpg" />
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=productdtl" style="font-weight: bold;"
                        id="productdtl" runat="server">Product Report</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=transfer">
                        <img alt="" src="Img/Report2.png"/>
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=transfer" style="font-weight: bold;"
                        id="Transfer" runat="server">Trnasfer Report</a>
                </td>
                <td rowspan="2">
                    <a href="CommonReport.aspx?invoker=asset">
                        <img alt="" src="Img/tool5.png"/>
                    </a>
                </td>
                <td style="text-align: left">
                    <a href="CommonReport.aspx?invoker=asset" style="font-weight: bold;"
                        id="asset" runat="server">Sitewise Asset & Equipment Report</a>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </center>
    <center>
        <table>
            <tr style="font-size: large">
                <td>
                    Report Type :
                    <asp:Label ID="lblRptName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:UCCommonFilter ID="UCCommonFilter1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <%-- <asp:Button ID="btnViewReport" Text="View Report" runat="server" OnClick="btnViewReport_Click"
                        CausesValidation="false" />--%>
                    <input type="button" value="View Report" id="btnViewReport" onclick="selectedProductRec();jsGetReportData();" />
                </td>
            </tr>
        </table>
    </center>
    <script type="text/javascript">
        //        jsCheckIssueHistory();
        function onselectA(invoker) {
            var allA = tblRptMenu.getElementsByTagName('a');
            for (var i = 0; i < allA.length; i++) {
                allA[i].className = '';
            }
            invoker.className = "aselected";
        }
        function CloseShowReport() {
            LoadingOff();
            divPopUp.className = "divDetailExpandPopUpOff";
        }
    </script>
    <style type="text/css">
        .popupClose
        {
            background: url(../App_Themes/Blue/img/icon_close.png) no-repeat;
            height: 32px;
            width: 32px;
            float: right;
            margin-top: -30px;
            margin-right: -25px;
        }
        .popupClose:hover
        {
            cursor: pointer;
        }
        .divDetailExpandPopUpOff
        {
            display: none;
        }
        .divDetailExpandPopUpOn
        {
            border: solid 3px gray;
            width: 65%;
            height: 98%;
            padding: 10px;
            background-color: #FFFFFF;
            margin-top: 50px;            
            top: 1%;
            left: 3%;
            position: absolute;
            z-index: 99999;
        }
    </style>
</asp:Content>
