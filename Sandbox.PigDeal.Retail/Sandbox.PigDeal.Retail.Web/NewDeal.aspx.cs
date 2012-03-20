using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class NewDeal : System.Web.UI.Page
    {
        private readonly PigDealManager _pigdealManager = new PigDealManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_pigdealManager.HasBranches(int.Parse(User.Identity.Name)))
                {
                    GetExsitingBranches();
                    lbloutletName.Text = _pigdealManager.GetOutLetName(int.Parse(User.Identity.Name));
                }

                else
                {
                    regConfirmation.Text = "<div ID='error'><br/>Its seems as though you have not created any branches. Please go <a href='MyAccount.aspx'>here</a> to add at least 1 branch.<br/></div>";
                    pnlNewDeal.Visible = false;
                }
            }
        }

        protected void GetExsitingBranches()
        {
            if (User.Identity.Name != string.Empty)
            {
                var outletId = User.Identity.Name;
                var branches = _pigdealManager.GetOutletBranches(int.Parse(outletId));
                foreach (var value in branches)
                {
                    ddlBranches.Items.Add(new ListItem
                                              {
                                                  Value = value.BranchId.ToString(),
                                                  Text = value.Name
                                              });
                }
                ddlBranches.DataBind();

            }
        }

        protected void CreateDeal(object sender, EventArgs e)
        {
            float dealCost = float.Parse(ConfigurationSettings.AppSettings["DealCost"]);
            
            var invoiceNumber = _pigdealManager.RandomString(8);
            try
            {
                var dealId = _pigdealManager.CreateDeal(new DealEntity
                    {
                        BranchId = int.Parse(ddlBranches.SelectedItem.Value),
                        Duration = ddlDealDuration.SelectedItem.Value,
                        Scoop = txbDealDetails.Text,
                        Title = txbDealTitle.Text,
                        Created = DateTime.Now.ToString(),
                        Discount = txbDealDiscount.Text,
                        StartDate = DealDate.Text,
                        StartTime =
                            string.Format("{0}:{1}", ddlDealHours.Text,
                                            ddlDealMin.Text),
                        OutletId = int.Parse(User.Identity.Name),
                    }, 
                      new InvoiceEntity
                    {
                        Amount = float.Parse(ConfigurationSettings.AppSettings["DealCost"]),
                        InvoiceNumber = invoiceNumber,
                        OutletId = int.Parse(User.Identity.Name),

                    });

                //Create Sessions for the Invoice
                Session["dealId"] = dealId;
                Session["InvoiceNumber"] = invoiceNumber;
                Session["DealTitle"] = txbDealTitle.Text;

                if (dealId != 0)
                {

                    Response.Redirect("~/Invoice.aspx");
                }
                else // Deal in invalid = Expired
                {
                    lblDealResponse.Text = "<div ID='error'>The deal you have entered is in the past.</div>";
                }
            }
            catch (Exception)
            {
                //Log
                throw;
            }
         
           
        }

      


    }
}