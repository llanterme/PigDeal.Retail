using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{

    public partial class MyAccount : System.Web.UI.Page
    {
        private readonly PigDealManager _outletManager = new PigDealManager();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (User.Identity.Name != string.Empty)
                {
                    var outlet = _outletManager.GetOutlet(int.Parse(User.Identity.Name));
                    txbOutletName.Text = outlet.OutletName;
                    txbOutletName.Enabled = false;

                    txbOutletContactPerson.Text = outlet.ContactPerson;
                    txbOutletContactPerson.Enabled = false;

                    txbOutletDescription.Text = outlet.Description;
                    txbOutletDescription.Enabled = false;

                    txbOutletLoginEmail.Text = outlet.LoginEmail;
                    txbOutletLoginEmail.Enabled = false;

                    txbOutletPassword1.Enabled = false;
                    txbOutletPassword1.Text = "*********";

                    txbOutletPassword2.Enabled = false;
                    txbOutletPassword2.Text = "*********";

                    txbOutletTelephone.Text = outlet.ContactNumber;
                    txbOutletTelephone.Enabled = false;

                    cboxTerms.Checked = true;

                    Save.Visible = false;
                    pnlBranches.Visible = true;
                    
                }
                GetExsitingBranches();
            }
        }



        protected void CreateOutlet(object sender, EventArgs e)
        {
            // Check if Terms has been checked:
            if (cboxTerms.Checked == false)
            {

                validationMessage.Text = "<div ID='error'>You need to accept the terms in order to continue.</div>";
                return;
            }

            
                
            

            try
            {
                //Reset
                txbOutletName.Attributes.Add("Class", "removeValidation");
                txbOutletLoginEmail.Attributes.Add("Class", "removeValidation");
                validationMessage.Text = string.Empty;

                // Duplicate outlet name and email check
                if (_outletManager.IsOutletRegistered(txbOutletName.Text, txbOutletLoginEmail.Text))
                {
                    txbOutletName.Attributes.Add("Class", "validation");
                    txbOutletLoginEmail.Attributes.Add("Class", "validation");

                    validationMessage.Text = "<div ID='error'>The Outlet name and email address combination is already registered.</div>";

                    validationMessage.Visible = true;
                    txbOutletName.Focus();
                }

                else // Not duplicate so insert
                {
                    pnlRegisterOutlet.Visible = false;
                    var outletId = _outletManager.CreateOutlet(new OutletEntity
                    {
                        ContactNumber = txbOutletTelephone.Text,
                        ContactPerson = txbOutletContactPerson.Text,
                        Description = txbOutletDescription.Text,
                        LoginEmail = txbOutletLoginEmail.Text.ToLower(),
                        OutletName = txbOutletName.Text,
                        Password = txbOutletPassword1.Text,
                    });

                    regConfirmation.Text = "<div class='forms'><br/>Outlet successfully registered. Please click <a href='Login.aspx'>here</a> to login and verify your account.<br/></div>";
                    pnlBranches.Visible = false;

                    //** DEBUG - switch off mail untill setup.
                    if(ConfigurationManager.AppSettings["IsMailEnabled"] == "true")
                    {
                    //fire off email
                    var mailClient = new MailManager();
                    var publicationParams = new Dictionary<string, string>();
                    publicationParams.Add("#OutLetName#", txbOutletName.Text);
                    publicationParams.Add("#Username#", txbOutletLoginEmail.Text);
                    publicationParams.Add("#Password#", txbOutletPassword1.Text);

                    mailClient.SendPublication(txbOutletLoginEmail.Text, publicationParams);
                    }


                }


            }
            catch (Exception)
            {
                //LOG
                regConfirmation.Text = ConfigurationManager.AppSettings["SiteError"];
            }

            
            
          

        }

        protected void CreateBranch(object sender, EventArgs e)
        {

            try
            {
                lblCreateBranchResponse.Text = string.Empty;


                // Check is branch name and email exsist
                if (!_outletManager.IsBranchRegistered(txbBranchName.Text, txbBranchEmail.Text))
                {

                    // GPS Lookup
                    var coOrds = _outletManager.LookupLatLong(txbAddress1.Text, txbAddress2.Text, txbCity.Text, txbPostCode.Text);
                    if (coOrds.Latitude != 0.0 && coOrds.Longitude != 0.0)
                    {

                        _outletManager.CreateBranch(new BranchEntity
                        {
                            Address1 = txbAddress1.Text,
                            Address2 = txbAddress2.Text,
                            PostCode = txbPostCode.Text,
                            City = txbCity.Text,
                            Telephone = txbBranchTelephone.Text,
                            Description = txbBranchDescription.Text,
                            Email = txbBranchEmail.Text,
                            Lat = coOrds.Latitude.ToString(),
                            Long = coOrds.Longitude.ToString(),
                            Name = txbBranchName.Text,
                            OperatingHours = txbOperatingHours.Text,
                            OutletId = int.Parse(User.Identity.Name),

                        });

                        txbBranchLat.Text = coOrds.Latitude.ToString();
                        txbBranchLong.Text = coOrds.Longitude.ToString();

                        // Clear and rebind dropdown
                        ddlExsistingBranches.Items.Clear();
                        GetExsitingBranches();

                        //Confirm
                        lblCreateBranchResponse.Text = "<div ID='error'>Branch created successfully.</div>";

                    }

                    else // GPS lookup error
                    {
                        lblCreateBranchResponse.Text = "<div ID='error'>Please check your address as it seems to be invalid.</div>";
                    }

                }

                else // Branch name and email check.
                {
                    lblCreateBranchResponse.Text = "<div ID='error'>The branch Name and email address combination is already registered!</div>";
                }
            }
            catch (Exception)
            {
                //LOG
                lblCreateBranchResponse.Text = ConfigurationManager.AppSettings["SiteError"];
            }
           


        }

        protected void GetExsitingBranches()
        {
            if (User.Identity.Name != string.Empty)
            {

             var outletId = User.Identity.Name;
            var branches = _outletManager.GetOutletBranches(int.Parse(outletId));
            foreach(var value in branches)
            {
                ddlExsistingBranches.Items.Add(new ListItem
                                                   {
                                                       Value = value.BranchId.ToString(),
                                                       Text = value.Name
                                                   });
            }
            ddlExsistingBranches.DataBind();
            ddlExsistingBranches.Items.Insert(0, new ListItem("Select your branch", "Select"));
            }
        }

        protected void GetBranchDetails(Object sender, EventArgs e)
        {
            
            var branchDetails = _outletManager.GetBranchDetails(int.Parse(ddlExsistingBranches.SelectedItem.Value));

            txbAddress2.Text = branchDetails.Address2;
            txbPostCode.Text = branchDetails.PostCode;
            txbCity.Text = branchDetails.City;
            txbBranchTelephone.Text = branchDetails.Telephone;
            txbBranchDescription.Text = branchDetails.Description;
            txbBranchEmail.Text = branchDetails.Email;
            txbBranchLat.Text = branchDetails.Lat;
            txbBranchLong.Text = branchDetails.Long;
            txbBranchName.Text = branchDetails.Name;
            txbOperatingHours.Text = branchDetails.OperatingHours;
        }

     


    }
}