using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class InvoiceHistory : System.Web.UI.Page
    {
        private readonly PigDealManager _pigdealManager = new PigDealManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindInvoiceHistory();
            }
        }

        protected void BindInvoiceHistory()
        {
            try
            {
                var expiredDeals = _pigdealManager.GetOutletInvoices(int.Parse(User.Identity.Name));

                if (expiredDeals.Count() > 0)
                {
                    lvDealHistory.DataSource = expiredDeals;
                    lvDealHistory.DataBind();
                }

                else
                {
                    lblNoInvoice.Text = "<div ID='error'>No invoices where found.</div>";
                    lblNoInvoice.Visible = true;
                }

            }
            catch (Exception)
            {

                lblNoInvoice.Text = "<div ID='error'>A error has occured. Please try again or contact our call center.</div>";
            }
            
        }
    }
}