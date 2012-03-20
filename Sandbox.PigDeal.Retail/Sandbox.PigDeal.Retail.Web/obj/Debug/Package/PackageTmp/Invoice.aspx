<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="Invoice.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/Invoice.css" rel="stylesheet" type="text/css" />
    <div id="page-wrap">
        <textarea id="header">INVOICE</textarea>
      
                <div id="logohelp">
                    <input id="imageloc" type="text" size="50" value="" /><br />
                    (max width: 540px, max height: 100px)
                </div>
              
            </div>
  
        <div style="clear: both">
        </div>
        <div id="customer">
          
            <table id="meta">
                <tr>
                    <td class="meta-head">
                        Invoice #
                    </td>
                    <td>
                       <asp:Label ID="lblInvoiceNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="meta-head">
                        Date
                    </td>
                    <td>
                         <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td>
                </tr>
               
            </table>
        </div>
        <table id="items">
            <tr>
                <th>
                    Item
                </th>
                <th>
                    Description
                </th>
                <th>
                    Unit Cost
                </th>
                <th>
                    Quantity
                </th>
                <th>
                    Price
                </th>
            </tr>
       
            <tr class="item-row">
                <td class="item-name">
                    <div class="delete-wpr">
                        <asp:Label ID="lblItem" runat="server">Deal Payment</asp:Label>
                        </div>
                </td>
                <td class="description">
                    
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
                <td class="description">
                    <asp:Label ID="lblUnitCost" runat="server"></asp:Label>
                </td>
                <td class="description">
                    <asp:Label ID="lblQuantity" runat="server">1</asp:Label>
                </td>
                <td class="description">
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </td>
            </tr>
          
            <tr>
                <td colspan="2" class="blank">
                </td>
                <td colspan="2" class="total-line">
                    Cost
                </td>
                <td class="total-value">
                    <div id="subtotal">
                        <asp:Label ID="lblCost" runat="server"></asp:Label>
                        </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="blank">
                </td>
                <td colspan="2" class="total-line">
                    Tax
                </td>
                <td class="total-value">
                    <div id="total">
                         <asp:Label ID="lblTax" runat="server"></asp:Label>
                        </div>
                </td>
            </tr>
          
            <tr>
                <td colspan="2" class="blank">
                </td>
                <td colspan="2" class="total-line balance">
                    Total Due
                </td>
                <td class="total-value balance">
                    <div class="due">
                        
                         <asp:Label ID="lblTotalDue" runat="server"></asp:Label>
                        </div>
                </td>
            </tr>

        </table>
        <div id="terms">
            <h5>
                Attention</h5>
            <textarea>You will be redirected to a secure payment gate way in order to complete the transaction.</textarea>
            
            <asp:Button ID="btnOntoPayment" OnClick="ProcessPayment" runat="server" Text="Confirm And Pay >>" class="ConfirmPayButton"/>
        </div>
        
</asp:Content>
