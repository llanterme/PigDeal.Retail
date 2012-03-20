<%@ Page Title="" Language="C#" MasterPageFile="~/PigDeal.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Sandbox.PigDeal.Retail.Web.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="up1" EnablePartialRendering="true">
        <triggers>
    <asp:AsyncPostBackTrigger ControlID="Save" />
    <asp:AsyncPostBackTrigger ControlID="ddlExsistingBranches" EventName="SelectedIndexChanged" />
    
  </triggers>
        <contenttemplate>
        

    <div id="ContentWrapper">
        <fieldset>
        <legend><b><font color="#C62E62">Register </font></b></legend>
        <asp:Panel ID="pnlRegisterOutlet" runat="server">
            
            <div id="PanelRegistration">
                
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Outlet Name:
                                </label>
                            </td>
                            <td>
                                <%--<em><asp:TextBox ID="txbOutletName" runat="server" AutoPostBack="true"
                                    OnTextChanged="TxbOutletNameTextChanged"></asp:TextBox>
                                </em>--%>
                                <em><asp:TextBox ID="txbOutletName" runat="server"></asp:TextBox>
                                </em>
                                </td>
                                <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateOutletName" runat="server" ControlToValidate="txbOutletName"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletName" runat="server"  
                             ControlToValidate="txbOutletName"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createOutletGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            </td>

                            
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Description:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txbOutletDescription"></asp:TextBox>
                            </td>
                            <td>
                             <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateOutletDescription" runat="server" ControlToValidate="txbOutletDescription"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletDescription" runat="server"  
                             ControlToValidate="txbOutletDescription"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createOutletGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Login Email:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txbOutletLoginEmail"></asp:TextBox>
                            </td>

                             <td>
                             <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateOutletEmail" runat="server" ControlToValidate="txbOutletLoginEmail"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletEmail" runat="server"  
                             ControlToValidate="txbOutletLoginEmail"  
                             ErrorMessage="Invalid email address"   ForeColor="Red" ValidationGroup="createOutletGroup"
                              ValidationExpression= "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" />

                             </sup>
                            
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Login Password:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txbOutletPassword1" TextMode="Password" />
                            </td>

                             <td>
                             <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreatePassword1" runat="server" ControlToValidate="txbOutletPassword1"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletPassword" runat="server"  
                             ControlToValidate="txbOutletPassword1"  
                             ErrorMessage="No special characters"   ForeColor="Red" ValidationGroup="createOutletGroup"
                              ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                             </sup>
                            
                                
                            </td>
                            
                        </tr>

                         <tr>
                            <td>
                                <label>
                                    Retype Password:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txbOutletPassword2" TextMode="Password" />
                            </td>

                             <td>
                             <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreatePassword2" runat="server" ControlToValidate="txbOutletPassword2"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletPasswor2" runat="server"  
                             ControlToValidate="txbOutletPassword2"  Display="Dynamic" 
                             ErrorMessage="No special characters"   ForeColor="Red" ValidationGroup="createOutletGroup"
                              ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                          <asp:CompareValidator Display="Dynamic" ForeColor="Red" ID="CompareValidator1" runat="server" ControlToValidate="txbOutletPassword1" ControlToCompare="txbOutletPassword2"  ErrorMessage="Passwords do not match." ValidationGroup="createOutletGroup"/>
                            </sup>
                                
                            </td>
                            
                        </tr>


                        <tr>
                            <td class="style1">
                                <label>
                                    Contact Telephone:
                                </label>
                            </td>
                            <td class="style1">
                                <asp:TextBox runat="server" ID="txbOutletTelephone" />
                            </td>
                              <td>
                             <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateOutletTelephone" runat="server" ControlToValidate="txbOutletTelephone"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletTelephone" runat="server"  
                             ControlToValidate="txbOutletTelephone"  
                             ErrorMessage="Invalid telephone"   ForeColor="Red" ValidationGroup="createOutletGroup"
                                ValidationExpression="^[0-9]+$" />

                             </sup>
                            
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <label>
                                    Contact Person:
                                </label>
                            </td>
                            <td class="style1">
                                <asp:TextBox runat="server" ID="txbOutletContactPerson" />
                            </td>
                              <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateOutletContactPerson" runat="server" ControlToValidate="txbOutletContactPerson"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createOutletGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateOutletContactPerson" runat="server"  
                             ControlToValidate="txbOutletContactPerson"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createOutletGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            </td>
                        </tr>
                    </table>
                    
                    <asp:Button runat="server" ID="Save" OnClick="CreateOutlet" class="submitButton" Text="Add Customer" CausesValidation="true" ValidationGroup="createOutletGroup"/>
                    <font color="#C62E62"><asp:Label ID="validationMessage" runat="server"></asp:Label></font>
                    <br />
                </div>
            
            </asp:Panel>
           <font color="#C62E62"> <asp:Label ID="regConfirmation" runat="server"></asp:Label> </font>
        </fieldset>
        
         <div id="DivBranch">

         <asp:Panel ID="pnlBranches" runat="server" Visible="false">
    <fieldset>

     <legend><b><font color="#C62E62">Branches</font></b></legend>
        

        <div id="BranchRegistration">

            <table>

             <tr>

                    <td>

                        <label>

                            Existing Branches: 

                        </label>

                    </td>

                    <td>

                        <asp:DropDownList Width="297px" ID="ddlExsistingBranches" AutoPostBack="true" OnSelectedIndexChanged="GetBranchDetails" runat="server"></asp:DropDownList>

                    </td>

                    <td>

                      </td>

                 

                </tr>

                <tr>

                    <td>

                        <label>

                            Branch Name: 

                        </label>

                    </td>

                    <td>

                        <asp:TextBox runat="server" ID="txbBranchName"></asp:TextBox>

                    </td>

                     <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchName" runat="server" ControlToValidate="txbBranchName"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchName" runat="server"  
                             ControlToValidate="txbBranchName"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createBranchGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            </td>

                 

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            Address 1:

                        </label>

                    </td>

                    <td>

                        <asp:TextBox runat="server" ID="txbAddress1"></asp:TextBox>

                    </td>

                      <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchAddress1" runat="server" ControlToValidate="txbAddress1"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchAddress1" runat="server"  
                             ControlToValidate="txbAddress1"  
                             ErrorMessage="No special characters"   ForeColor="Red" ValidationGroup="createBranchGroup"
                              ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                             </sup>
                            </td>

                </tr>

        <tr>
                    <td class="style5">

                        <label>

                            Address 2:

                        </label>

                    </td>

                    <td>

                        <asp:TextBox runat="server" ID="txbAddress2"></asp:TextBox>

                    </td>

                       <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchAddress2" runat="server" ControlToValidate="txbAddress2"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchAddress2" runat="server"  
                             ControlToValidate="txbAddress2"  
                             ErrorMessage="No special characters"   ForeColor="Red" ValidationGroup="createBranchGroup"
                              ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                             </sup>
                            </td>

                    

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            City:

                        </label>

                    </td>

                    <td>

                        <asp:TextBox runat="server" ID="txbCity"></asp:TextBox>

                    </td>

                    

                     <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchCity" runat="server" ControlToValidate="txbCity"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchCity" runat="server"  
                             ControlToValidate="txbCity"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createBranchGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            </td>

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            Post Code:

                        </label>

                    </td>

                    <td>

                          <asp:TextBox runat="server" ID="txbPostCode"></asp:TextBox>

                    </td>

                        <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchPostCode" runat="server" ControlToValidate="txbPostCode"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchPostCode" runat="server"  
                             ControlToValidate="txbPostCode"  
                             ErrorMessage="Invalid postcode"   ForeColor="Red" ValidationGroup="createBranchGroup"
                                ValidationExpression="^[0-9]+$" />

                             </sup>
                            </td>

                </tr>

                

              

                    

                   

                

                <tr>

                    <td class="style5">

                        <label>

                            Branch Description:

                        </label>

                    </td>

                    <td>

                          <asp:TextBox runat="server" ID="txbBranchDescription"></asp:TextBox>

                    </td>

                    
    <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchDescription" runat="server" ControlToValidate="txbBranchDescription"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchDescription" runat="server"  
                             ControlToValidate="txbBranchDescription"  
                             ErrorMessage="Only enter letters, spaces and hyphens"   ForeColor="Red" ValidationGroup="createBranchGroup"
                             ValidationExpression="^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$" />

                             </sup>
                            </td>

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            Operating hours:

                        </label>

                    </td>

                    <td>

                      <asp:TextBox runat="server" ID="txbOperatingHours"></asp:TextBox>

                    </td>

                    

                  <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchOpHours" runat="server" ControlToValidate="txbOperatingHours"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchOpHours" runat="server"  
                             ControlToValidate="txbOperatingHours"  
                              ErrorMessage="No special characters"    ForeColor="Red" ValidationGroup="createBranchGroup"
                             ValidationExpression="^[a-zA-Z0-9\s.\?\,\'\;\!\-]+$" />

                             </sup>
                            </td>

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            Branch Telephone:

                        </label>

                    </td>

                    <td>

                          <asp:TextBox runat="server" ID="txbBranchTelephone"></asp:TextBox>

                    </td>

                    
     <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchTelephone" runat="server" ControlToValidate="txbBranchTelephone"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchTelephone" runat="server"  
                             ControlToValidate="txbBranchTelephone"  
                               ErrorMessage="Invalid telephone"   ForeColor="Red" ValidationGroup="createBranchGroup"
                                ValidationExpression="^[0-9]+$" />

                             </sup>
                            </td>

                </tr>

                <tr>

                    <td class="style5">

                        <label>

                            Branch Email:

                        </label>

                    </td>

                    <td>

                       <asp:TextBox runat="server" ID="txbBranchEmail"></asp:TextBox>

                    </td>

                        <td>
                                <sup>
                                   <asp:RequiredFieldValidator ID="rfvcreateBranchEmail" runat="server" ControlToValidate="txbBranchEmail"
                            ErrorMessage="*" ForeColor="Red"  ValidationGroup="createBranchGroup" Display="Dynamic" />

                             <asp:RegularExpressionValidator ID="revcreateBranchEmail" runat="server"  
                             ControlToValidate="txbBranchEmail"  
                               ErrorMessage="Invalid email address"   ForeColor="Red" ValidationGroup="createBranchGroup"
                              ValidationExpression= "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" />

                             </sup>
                            </td>
                            </tr>

                              <tr>

                    <td class="style5">

                        <label>

                            GPS Latitude:

                        </label>

                    </td>

                    <td>

                         <asp:TextBox runat="server" ID="txbBranchLat" Enabled="false"></asp:TextBox>

                    </td>

                    
                </tr>

                

                           

                <tr>

                    <td class="style5">

                        <label>

                            

                            GPS Longitude:

                        </label>

                    </td>

                    <td>

                     <asp:TextBox runat="server" ID="txbBranchLong" Enabled="false"></asp:TextBox>

                    </td>

                    

                </tr>

            </table>

            

              <asp:Button onclick="CreateBranch" runat="server" Text="Add Branch" class="submitButton" CausesValidation="true" ValidationGroup="createBranchGroup"/>

              <font color="#C62E62"><asp:Label ID="lblCreateBranchResponse" runat="server"></asp:Label></font>
                    <br />

        </div>
        
        </fieldset>
        </asp:Panel>
    </div>

    

       
   </div>
   
  </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
