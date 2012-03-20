<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/pigdeal.retail.core.css" rel="stylesheet" type="text/css" />
    <title>.: PigDeal :.</title>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="Scripts/blockUI.js" />
            <asp:ScriptReference Path="Scripts/Default.js" />
        </Scripts>
    </ajaxToolkit:ToolkitScriptManager>
    <div class="page">
        <div class="header">
            <div class="title">
            </div>
            <div class="loginDisplay">
                <img id="Image1" src="http://pigdeal.fusiondev.co.za/images/Pig%20Deal%20Logo.png" />
            </div>
            <div class="clear hideSkiplink">
            </div>
        </div>
        <div class="main">
            <asp:UpdatePanel runat="server" ID="up1" EnablePartialRendering="true">
                <ContentTemplate>
                    <div class="login" style="margin: 5em auto; width: 600px;padding:4px;">
                        <h1>
                            Log in to your <strong>Pigdeal</strong> account!</h1>
                        <p class="register">
                            Not a member? <a href="MyAccount.aspx">Register here!</a></p>
                        <div>
                            <label for="login_username">
                                Username</label>
                            <asp:TextBox runat="server" ID="txbUsername" class="field required" title="Please provide your username"></asp:TextBox>
                        </div>
                        <div>
                            <label for="login_password">
                                Password</label>
                            <asp:TextBox runat="server" ID="txbPassword" TextMode="Password" class="field required"
                                title="Please provide your username"></asp:TextBox>
                        </div>
                        <p class="forgot">
                            <%--<a href="#" OnClick="ViewDealDetails">Forgot your password?</a>--%>
                            <asp:LinkButton ID="ForgotPassword" runat="server" OnClick="ShowPasswordPop" Text="Forgot your password?"></asp:LinkButton>
                        </p>
                        <div class="submit">
                            
                             <asp:Button ID="btnLogin" OnClick="LogonClick" runat="server" Text="Login" class="LoginButton"/>
                            
                                <asp:Label runat="server" ID="lblAuthResponse"></asp:Label>
                            
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="footer">
    </div>
    <asp:Panel ID="pnlForgotPassword" runat="server" CssClass="detail" Width="400px"
        Style="display: none;">
        <asp:UpdatePanel ID="updateViewDetails" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:Button ID="btnShowInsert" runat="server" Style="display: none" />
                <ajaxToolkit:ModalPopupExtender ID="mdlPopupview" runat="server" TargetControlID="btnShowPopup"
                    PopupControlID="pnlForgotPassword" CancelControlID="btnInsertClose" BackgroundCssClass="Edit_ModalBackground" />
                <div align="center">
                    <table class="detailgrid">
                        <tr>
                            <td>
                                Email Address:
                            </td>
                            <td>
                                <asp:TextBox ID="txbForgotEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="footer">
                    <asp:LinkButton ID="btnSave" runat="server" Text="Send" OnClick="SendPassword" CausesValidation="true" />
                    &nbsp;
                    <asp:LinkButton ID="btnInsertClose" runat="server" Text="Close" CausesValidation="false" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    </form>
</body>
</html>
