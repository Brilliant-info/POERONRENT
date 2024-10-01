<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="PowerOnRentwebapp.Login.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script src="../PopupMessages/Scripts/message.js" type="text/javascript"></script>
<link href="../App_Themes/Login.css" rel="stylesheet" type="text/css" />
<script src="../App_Themes/PIE.js" type="text/javascript"></script>
<script src="../App_Themes/PIE_uncompressed.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="ForgotPwHead1" runat="server">
    <title>Elegant CRM</title>
</head>
<body>
    <form runat="server">
    <div style="position: relative; left: -20px; top: -7px;">
        <img src="../App_Themes/Blue/img/Background.jpg" />
    </div>
    <div>
        <center>
            <table style="margin: 0px 0 0 0;">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="font">
                        Forgot Password
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="ClientLogo1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; vertical-align: bottom;">
                                        <asp:Image ID="ElegantLogo1" runat="server" ImageUrl="~/MasterPage/Logo/ElegantCRM.png" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </td>
                    <td>
                        <img src="../MasterPage/Logo/Partitionimg.png" />
                    </td>
                    <td>
                        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
                            <UserNameTemplate>
                                <asp:ValidationSummary ID="validationsummary1" runat="server" ShowMessageBox="true"
                                    ShowSummary="false" DisplayMode="bulletlist" ValidationGroup="PasswordRecovery1" />
                                <table class="tableForm">
                                    <tr>
                                        <td style="color: red; font-size: 12px; text-align: left;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <req> User Name :</req>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Width="200px" CssClass="inputElement"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="User Name is required." ToolTip="User Name is required." Display="None"
                                                ValidationGroup="PasswordRecovery1"></asp:RequiredFieldValidator>
                                            <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" ValidationGroup="PasswordRecovery1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 12px; text-align: left;">
                                            Enter your User Name to receive your password
                                        </td>
                                    </tr>
                                </table>
                            </UserNameTemplate>
                            <SuccessTemplate>
                                <table class="tableForm">
                                    <tr>
                                        <td>
                                            Your password has been sent to your email address
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl="~/Login/Login.aspx">Go To ElegantCRM Login</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </SuccessTemplate>
                        </asp:PasswordRecovery>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 10px 0 0 0; border-bottom: 1px solid gray">
                    </td>
                </tr>
                <tr style="color: Gray; font-size: 14px;">
                    <td colspan="2" style="text-align: left;">
                        <a target="_blank" href="http://brilliantinfosys.com/">©2012 Brilliant Info System Pvt
                            Ltd</a>
                    </td>
                    <td style="text-align: right;">
                        <a>Contact </a>|<a> Support</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 10px 0 0 0;">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <a>Best viewed in Firefox and Google chrome</a>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
