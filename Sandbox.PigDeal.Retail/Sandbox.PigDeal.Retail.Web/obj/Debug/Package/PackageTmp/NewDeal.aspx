<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="NewDeal.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.NewDeal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
             <asp:UpdatePanel runat="server" ID="up1" EnablePartialRendering="true">
                <ContentTemplate>
    <div id="ContentWrapper">
    
        
            <asp:Panel ID="pnlNewDeal" runat="server">
            <div class="forms">
                <table>
                    <tr>
                        <td>
                            <label>
                                Outlet:
                            </label>
                        </td>
                        <td>
                            <asp:Label ID="lbloutletName" runat="server"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Branch:
                            </label>
                        </td>
                        <td>
                            <asp:DropDownList Width="297px" ID="ddlBranches" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Deal Title:
                            </label>
                        </td>
                        <td>
                            <em>
                                <asp:TextBox ID="txbDealTitle" runat="server" Width="295px"></asp:TextBox>
                            </em>
                        
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvDealTitle" runat="server" ControlToValidate="txbDealTitle"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createNewDeal" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revDealTitle" runat="server"  
                             ControlToValidate="txbDealTitle"  
                             ErrorMessage="No special characters"  ForeColor="Red" ValidationGroup="createNewDeal" Display="Dynamic"
                             ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                             </sup>
                            </td>

                    </tr>
                    <tr>
                        <td>
                            <label>
                                Deal Discount:
                            </label>
                        </td>
                        <td>
                            <em>
                                <asp:TextBox ID="txbDealDiscount" runat="server" Width="295px"></asp:TextBox>
                            </em>

                               <sup>
                                   <asp:RequiredFieldValidator ID="rfvDealDiscount" runat="server" ControlToValidate="txbDealDiscount"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createNewDeal" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revDealDiscount" runat="server"  
                             ControlToValidate="txbDealDiscount"  
                             ErrorMessage="Numbers only"  ForeColor="Red" ValidationGroup="createNewDeal" Display="Dynamic"
                              ValidationExpression="^[0-9]+$" />

                             </sup>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Deal Start Date & Time:
                            </label>
                        </td>
                        <td>
                            
                                <asp:TextBox runat="server" ID="DealDate" Width="100px"  />
                                <ajaxtoolkit:calendarextender id="calendarButtonExtender" runat="server" targetcontrolid="DealDate"
                                    popupbuttonid="DealDate"  />

                                     <sup>
                                   <asp:RequiredFieldValidator ID="rfvDealDiscountCalender" runat="server" ControlToValidate="DealDate"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createNewDeal" Display="Dynamic" />
                            </sup>
                            
                            
                                H
                            <asp:DropDownList runat="server" ID="ddlDealHours" Width="75px">
                                <asp:ListItem Value="1"></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                                <asp:ListItem Value="3"></asp:ListItem>
                                <asp:ListItem Value="4"></asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                                <asp:ListItem Value="6"></asp:ListItem>
                                <asp:ListItem Value="7"></asp:ListItem>
                                <asp:ListItem Value="8"></asp:ListItem>
                                <asp:ListItem Value="9"></asp:ListItem>
                                <asp:ListItem Value="10"></asp:ListItem>
                                <asp:ListItem Value="11"></asp:ListItem>
                                <asp:ListItem Value="12"></asp:ListItem>
                                <asp:ListItem Value="13"></asp:ListItem>
                                <asp:ListItem Value="14"></asp:ListItem>
                                <asp:ListItem Value="15"></asp:ListItem>
                                <asp:ListItem Value="16"></asp:ListItem>
                                <asp:ListItem Value="17"></asp:ListItem>
                                <asp:ListItem Value="18"></asp:ListItem>
                                <asp:ListItem Value="19"></asp:ListItem>
                                <asp:ListItem Value="20"></asp:ListItem>
                                <asp:ListItem Value="21"></asp:ListItem>
                                <asp:ListItem Value="22"></asp:ListItem>
                                <asp:ListItem Value="23"></asp:ListItem>
                                <asp:ListItem Value="24"></asp:ListItem>
                            </asp:DropDownList>
                            
                                M
                            <asp:DropDownList ID="ddlDealMin" runat="server" Width="86px">
                                <asp:ListItem Value="01"></asp:ListItem>
                                <asp:ListItem Value="02"></asp:ListItem>
                                <asp:ListItem Value="03"></asp:ListItem>
                                <asp:ListItem Value="05"></asp:ListItem>
                                <asp:ListItem Value="06"></asp:ListItem>
                                <asp:ListItem Value="07"></asp:ListItem>
                                <asp:ListItem Value="08"></asp:ListItem>
                                <asp:ListItem Value="09"></asp:ListItem>
                                <asp:ListItem Value="10"></asp:ListItem>
                                <asp:ListItem Value="11"></asp:ListItem>
                                <asp:ListItem Value="12"></asp:ListItem>
                                <asp:ListItem Value="13"></asp:ListItem>
                                <asp:ListItem Value="14"></asp:ListItem>
                                <asp:ListItem Value="15"></asp:ListItem>
                                <asp:ListItem Value="16"></asp:ListItem>
                                <asp:ListItem Value="17"></asp:ListItem>
                                <asp:ListItem Value="19"></asp:ListItem>
                                <asp:ListItem Value="20"></asp:ListItem>
                                <asp:ListItem Value="21"></asp:ListItem>
                                <asp:ListItem Value="22"></asp:ListItem>
                                <asp:ListItem Value="23"></asp:ListItem>
                                <asp:ListItem Value="24"></asp:ListItem>
                                <asp:ListItem Value="25"></asp:ListItem>
                                <asp:ListItem Value="26"></asp:ListItem>
                                <asp:ListItem Value="27"></asp:ListItem>
                                <asp:ListItem Value="28"></asp:ListItem>
                                <asp:ListItem Value="29"></asp:ListItem>
                                <asp:ListItem Value="30"></asp:ListItem>
                                <asp:ListItem Value="31"></asp:ListItem>
                                <asp:ListItem Value="32"></asp:ListItem>
                                <asp:ListItem Value="33"></asp:ListItem>
                                <asp:ListItem Value="34"></asp:ListItem>
                                <asp:ListItem Value="35"></asp:ListItem>
                                <asp:ListItem Value="36"></asp:ListItem>
                                <asp:ListItem Value="37"></asp:ListItem>
                                <asp:ListItem Value="38"></asp:ListItem>
                                <asp:ListItem Value="39"></asp:ListItem>
                                <asp:ListItem Value="40"></asp:ListItem>
                                <asp:ListItem Value="41"></asp:ListItem>
                                <asp:ListItem Value="42"></asp:ListItem>
                                <asp:ListItem Value="43"></asp:ListItem>
                                <asp:ListItem Value="44"></asp:ListItem>
                                <asp:ListItem Value="45"></asp:ListItem>
                                <asp:ListItem Value="46"></asp:ListItem>
                                <asp:ListItem Value="47"></asp:ListItem>
                                <asp:ListItem Value="48"></asp:ListItem>
                                <asp:ListItem Value="49"></asp:ListItem>
                                <asp:ListItem Value="50"></asp:ListItem>
                                <asp:ListItem Value="51"></asp:ListItem>
                                <asp:ListItem Value="52"></asp:ListItem>
                                <asp:ListItem Value="53"></asp:ListItem>
                                <asp:ListItem Value="54"></asp:ListItem>
                                <asp:ListItem Value="55"></asp:ListItem>
                                <asp:ListItem Value="56"></asp:ListItem>
                                <asp:ListItem Value="57"></asp:ListItem>
                                <asp:ListItem Value="58"></asp:ListItem>
                                <asp:ListItem Value="59"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Deal Duration (H):
                            </label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDealDuration" runat="server" Width="297px">
                                <asp:ListItem Value="1"></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                                <asp:ListItem Value="3"></asp:ListItem>
                                <asp:ListItem Value="5"></asp:ListItem>
                                <asp:ListItem Value="6"></asp:ListItem>
                                <asp:ListItem Value="7"></asp:ListItem>
                                <asp:ListItem Value="8"></asp:ListItem>
                                <asp:ListItem Value="9"></asp:ListItem>
                                <asp:ListItem Value="10"></asp:ListItem>
                                <asp:ListItem Value="11"></asp:ListItem>
                                <asp:ListItem Value="12"></asp:ListItem>
                                <asp:ListItem Value="13"></asp:ListItem>
                                <asp:ListItem Value="14"></asp:ListItem>
                                <asp:ListItem Value="15"></asp:ListItem>
                                <asp:ListItem Value="16"></asp:ListItem>
                                <asp:ListItem Value="17"></asp:ListItem>
                                <asp:ListItem Value="18"></asp:ListItem>
                                <asp:ListItem Value="19"></asp:ListItem>
                                <asp:ListItem Value="20"></asp:ListItem>
                                <asp:ListItem Value="21"></asp:ListItem>
                                <asp:ListItem Value="22"></asp:ListItem>
                                <asp:ListItem Value="23"></asp:ListItem>
                                <asp:ListItem Value="24"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <label>
                                Deal Details:
                            </label>
                        </td>
                        <td>
                            <em>
                                <asp:TextBox ID="txbDealDetails" TextMode="MultiLine" Rows="2" Columns="20" Height="162px" Width="409px" runat="server"></asp:TextBox>
                            </em>

                              <sup>
                                   <asp:RequiredFieldValidator ID="rfvDealDeatails" runat="server" ControlToValidate="txbDealDetails"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createNewDeal" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revDealDeatails" runat="server"  
                             ControlToValidate="txbDealDetails"  
                            ErrorMessage="No special characters"  ForeColor="Red" ValidationGroup="createNewDeal" Display="Dynamic"
                             ValidationExpression="^([^'\^&]*)$" />


                             </sup>
                        </td>
                    </tr>
                </table>
                   <asp:Button ID="btnOntoPayment" class="CreateDealButton" OnClick="CreateDeal" CausesValidation="true" ValidationGroup="createNewDeal"  runat="server" Text="Continue"/>
                   <br /><br />
                     <font color="#C62E62"><asp:Label ID="lblDealResponse" runat="server"></asp:Label></font>
                    <br />
            </div>
            </asp:Panel>
            
              <font color="#C62E62"> <asp:Label ID="regConfirmation" runat="server"></asp:Label> </font>
        
        <br /><br />
    </div>
     </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
