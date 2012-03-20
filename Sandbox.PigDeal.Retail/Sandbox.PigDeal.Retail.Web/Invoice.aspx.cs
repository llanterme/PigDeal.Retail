using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["dealId"] !=null)
            {
            var dealCost = float.Parse(ConfigurationSettings.AppSettings["DealCost"]);
            var taxAmount = (dealCost * 14 / 114);

            // Set Invoice Data
            lblInvoiceNumber.Text = Session["InvoiceNumber"].ToString();
            lblTotalDue.Text = "R" + dealCost;
            lblDescription.Text = Session["DealTitle"].ToString();

            lblUnitCost.Text = dealCost.ToString();
            lblCost.Text = Math.Round(dealCost - taxAmount, 2).ToString();
            lblPrice.Text = "R" + dealCost;
            lblTax.Text = "R" + Math.Round(taxAmount,2);

            
            lblDate.Text = String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Now);

            }

            else
            {
                Response.Redirect("~/MyAccount.aspx");
            }

        }

        protected void ProcessPayment(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                // Create the order in your DB and get the ID
                string amount = ConfigurationSettings.AppSettings["DealCost"];
                string name = "Pigdeal, Invoice #" + Session["InvoiceNumber"];
                string description = Session["DealTitle"].ToString();

                string site = string.Empty;
                string merchantId = string.Empty;
                string merchantKey = string.Empty;

                // Check if we are using the test or live system
                string paymentMode = ConfigurationSettings.AppSettings["PaymentMode"];

                if (paymentMode == "test")
                {
                    site = "https://sandbox.payfast.co.za/eng/process?";
                    merchantId = "10000100";
                    merchantKey = "46f0cd694581a";
                }
                else if (paymentMode == "live")
                {
                    site = "https://www.payfast.co.za/eng/process?";
                    merchantId = ConfigurationSettings.AppSettings["PF_MerchantID"];
                    merchantKey = ConfigurationSettings.AppSettings["PF_MerchantKey"];
                }
                else
                {
                    throw new InvalidOperationException("Cannot process payment if PaymentMode (in web.config) value is unknown.");
                }

                // Build the query string for payment site

                StringBuilder str = new StringBuilder();
                str.Append("merchant_id=" + HttpUtility.UrlEncode(merchantId));
                str.Append("&merchant_key=" + HttpUtility.UrlEncode(merchantKey));
                str.Append("&return_url=" + HttpUtility.UrlEncode(ConfigurationSettings.AppSettings["PF_ReturnURL"]));
                str.Append("&cancel_url=" + HttpUtility.UrlEncode(ConfigurationSettings.AppSettings["PF_CancelURL"]));
                str.Append("&notify_url=" + HttpUtility.UrlEncode(ConfigurationSettings.AppSettings["PF_NotifyURL"]));

                str.Append("&m_payment_id=" + HttpUtility.UrlEncode(Session["dealId"].ToString()));
                str.Append("&amount=" + HttpUtility.UrlEncode(amount));
                str.Append("&item_name=" + HttpUtility.UrlEncode(name));
                str.Append("&item_description=" + HttpUtility.UrlEncode(description));

                // Redirect to PayFast
                Response.Redirect(site + str.ToString());




            }
            catch (Exception ex)
            {
                // Handle your errors here (log them and tell the user that there was an error)
            }
        }
    }
}