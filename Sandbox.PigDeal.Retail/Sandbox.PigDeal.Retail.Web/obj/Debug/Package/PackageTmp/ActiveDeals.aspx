<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="ActiveDeals.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.ActiveDeals" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updateGridHistiry" runat="server" UpdateMode="Conditional">
        <contenttemplate>
    <asp:ListView ID="lvActiveDeals" runat="server">
        <layouttemplate>
                        <div class="datagrid">
                            <div class="header">
                                <div class="title">
                                </div>
                            </div>
                            <table  runat="server" cellspacing="0" cellpadding="4" rules="rows" id="MainContent_dgActiveDeals" style="background-color:White;border-color:#C62E62;border-width:3px;border-style:Double;font-family:verdana;font-size:9px;height:80px;border-collapse:collapse;Z-INDEX: 101; width: 100%;">
                                <tr  style="color:White;background-color:#C62E62;font-weight:bold;font-style:normal;text-decoration:none;height:2px;">
                                    <th>
                                        
                                        <asp:Label ID="lblDealId" runat="server" Text="Deal ID" />
                                    </th>
                                    <th>
                                        <asp:Label ID="lblDealTitle" runat="server" Text="Deal Title" />
                                    </th>
                                    <th>
                                        <asp:Label ID="lblCreatedOn" runat="server" Text="Create On" />
                                    </th>
                                     <th>
                                        <asp:Label ID="lblDealStart" runat="server" Text="Deal Start" />
                                    </th>
                                      <th>
                                        <asp:Label ID="lblExpires" runat="server" Text="Expires" />
                                    </th>
                                    
                                    <th>
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" />
                                    </th>

                                  
                                    <th>
                                        <asp:Label ID="lblClaimed" runat="server" Text="Claimed" />
                                    </th>
                                      <th>
                                        
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server" />
                            </table>
                        </div>
                    </layouttemplate>
        <itemtemplate>
                        <tr align="center" style="color:#333333;background-color:White; border-right:2px solid black;">
                            <td>
                                <%# Eval("DealId")%>
                            </td>
                            <td>
                                <%# Eval("Title")%>
                            </td>
                              <td>
                                <%# Eval("Created")%>
                            </td>
                             <td>
                                <%# Eval("StartDate")%>
                            </td>
                            <td>
                                <%# Eval("Expires")%>
                            </td>
                            <td>
                                <%# Eval("Status")%>
                            </td>
                            <td>
                                <%# Eval("claimed")%>
                            </td>

                             <td class="Row_Command_Button">
                                            <asp:ImageButton src="/images/view.gif" ID="btnView" runat="server"
                                                OnClick="ViewDealDetails" CommandArgument='<%# Bind("DealId") %>' />
                          
                        </tr>
                    </itemtemplate>
    </asp:ListView>
    <asp:Label ID="lblNoDeal" runat="server" Visible="false" />
    
        </contenttemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="pnlInsert" runat="server" CssClass="detail" Width="550px" Style="display: none;">
        <asp:UpdatePanel ID="updateViewDetails" runat="server" UpdateMode="Conditional">
            <contenttemplate>
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <asp:Button ID="btnShowInsert" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="mdlPopupview" runat="server" TargetControlID="btnShowPopup"
                PopupControlID="pnlInsert" CancelControlID="btnInsertClose" BackgroundCssClass="Edit_ModalBackground" />
                <div align="center">
            <table class="detailgrid">
             <tr>
                    <td>
                        Title:
                    </td>
                    <td><asp:Label ID="lblTitle" runat="server" Width="297px"></asp:Label></td>
                 
                </tr>
            <tr>
                    <td>
                        Discount:
                    </td>
                    <td><asp:Label ID="lblDiscount" runat="server" Width="297px"></asp:Label></td>
                 
                </tr>

            <tr>
                    <td>
                           Scoop:
                    </td>
                    <td>
                    <asp:TextBox ID="txbDealDetails" TextMode="MultiLine" Rows="2" Columns="20" Height="162px" Width="409px" runat="server"></asp:TextBox>
                    </td>
                 
                </tr>

                <tr>
                    <td>
                           Claimed:
                    </td>
                    <td><asp:DropDownList ID="ddlCoupons" runat="server" Width="409px"></asp:DropDownList></td>
                 
                </tr>

                
            </table>
            </div>
            <div class="footer">
                <asp:LinkButton ID="btnInsertClose" runat="server" Text="Close" CausesValidation="false" />
            </div>
        </contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
