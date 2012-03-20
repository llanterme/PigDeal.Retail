<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="InvoiceHistory.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.InvoiceHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updateGridHistiry" runat="server" UpdateMode="Conditional">
        <contenttemplate>
    <asp:ListView ID="lvDealHistory" runat="server">
        <layouttemplate>
                        <div class="datagrid">
                            <div class="header">
                                <div class="title">
                                </div>
                            </div>
                            <table  runat="server" cellspacing="0" cellpadding="4" rules="rows" id="MainContent_dgActiveDeals" style="background-color:White;border-color:#C62E62;border-width:3px;border-style:Double;font-family:verdana;font-size:9px;height:80px;border-collapse:collapse;Z-INDEX: 101; width: 100%;">
                                <tr  style="color:White;background-color:#C62E62;font-weight:bold;font-style:normal;text-decoration:none;height:2px;">
                                    <th>
                                        
                                        <asp:Label ID="lblDealTitle" runat="server" Text="Deal Title" />
                                    </th>
                                     <th>
                                        <asp:Label ID="lblDatePaid" runat="server" Text="Date Paid" />
                                    </th>
                                    
                                     <th>
                                        <asp:Label ID="lblAmount" runat="server" Text="Paid Amount" />
                                    </th>
                                     <th>
                                        <asp:Label ID="lblInvoiceNumber" runat="server" Text="Invoice Number" />
                                    </th>
                                   
                                    
                             
                                </tr>
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </div>
                    </layouttemplate>
        <itemtemplate>
                        <tr align="center" style="color:#333333;background-color:White; border-right:2px solid black;">

                            <td>
                                <%# Eval("Title")%>
                            </td>
                             <td>
                                <%# Eval("DatePaid")%>
                            </td>
                              <td>
                                R<%# Eval("Amount")%>
                            </td>
                             <td>
                                <%# Eval("InvoiceNumber")%>
                            </td>
                          
                        </tr>
                    </itemtemplate>
    </asp:ListView>
    <asp:Label ID="lblNoInvoice" runat="server" Visible="false" />
    
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
