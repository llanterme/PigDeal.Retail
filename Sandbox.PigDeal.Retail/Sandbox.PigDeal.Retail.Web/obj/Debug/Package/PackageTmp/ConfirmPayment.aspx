<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="ConfirmPayment.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.ConfirmPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="error">
        Your order was successfull. Click <a href="ActiveDeals.aspx">here </a>to view. &nbsp;
        <img src="images/tick.png" />
    </div>
</asp:Content>
