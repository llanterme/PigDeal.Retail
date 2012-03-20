using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{

    public partial class Register : System.Web.UI.Page
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

                    Save.Visible = false;
                    pnlBranches.Visible = true;
                    
                }
                GetExsitingBranches();
            }
        }

        protected void CreateOutlet(object sender, EventArgs e)
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

                validationMessage.Text = "The Outlet Name and email address combination is already registered!";

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
                                                                   LoginEmail = txbOutletLoginEmail.Text,
                                                                   OutletName = txbOutletName.Text,
                                                                   Password = txbOutletPassword1.Text,
                                                               });

                regConfirmation.Text = "Outlet successfully registered. Please click <a href='Login.aspx'>here</a> to login and verify your account.";
                pnlBranches.Visible = false;

                //TODO fire off email

            }

        }

        protected void CreateBranch(object sender, EventArgs e)
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
                    lblCreateBranchResponse.Text = "Branch created successfully.";

                }

                else // GPS lookup error
                {
                    lblCreateBranchResponse.Text = "Please check your address as it seems to be invalid.";
                }

            }

            else // Branch name and email check.
            {
                lblCreateBranchResponse.Text = "The branch Name and email address combination is already registered!";
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