<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="Validate.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.Validate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel runat="server" ID="up1" EnablePartialRendering="true">
        
        <contenttemplate>
         <div class="login">
          <br />
    <table>
        <tr>
            <td>
                Deal Reference:
            </td>
            <td>
                <asp:TextBox ID="txbValidateDeal" runat="server"  Width="297px" ></asp:TextBox>
            </td>
            <td>
                <asp:Button runat="server" class="ValidateButton" ID="btnValidate" text="Validate" OnClick="ValidateCoupon" />
            </td>
            <td>
             <asp:Image runat="server" ID="imgResult" />
            
            </td>
        </tr>
    </table>
  
                
                <asp:Label ID="lblvalidationResponse" runat="server"></asp:Label>
     <br />
    </div>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
