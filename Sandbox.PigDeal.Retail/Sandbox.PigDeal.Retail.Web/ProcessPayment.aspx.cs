using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mweb.Foundation.Practices.Logging;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class ProcessPayment : System.Web.UI.Page
    {
        private static readonly ILogger Log = LogManager.GetLogger(typeof(ProcessPayment));

        string orderId = "";
        string processorOrderId = "";
        string strPostedVariables = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            // Can't have a postback on this page, it is called
            // once by the payment processor.
            if (Page.IsPostBack) return;

            try
            {
                // Get the posted variables. Exclude the signature (it must be excluded when we hash and also when we validate).
                Log.Info(methodName, string.Format("Get the posted variables {0}", "PigDeal"));

                NameValueCollection arrPostedVariables = new NameValueCollection(); // We will use later to post data
                NameValueCollection req = Request.Form;
                string key = "";
                string value = "";
                for (int i = 0; i < req.Count; i++)
                {
                    key = req.Keys[i];
                    value = req[i];

                    if (key != "signature")
                    {
                        strPostedVariables += key + "=" + value + "&";
                        arrPostedVariables.Add(key, value);
                    }
                }

                // Remove the last &
                strPostedVariables = strPostedVariables.TrimEnd(new char[] { '&' });

                // Also get the Ids early. They are used to log errors to the orders table.

                orderId = Request.Form["m_payment_id"];
                processorOrderId = Request.Form["pf_payment_id"];
                Log.Info(methodName, string.Format("Got IDS {0}, {1}", orderId, processorOrderId));

                // Are we testing or making live payments
                string site = "";
                string merchant_id = "";
                string paymentMode = ConfigurationSettings.AppSettings["PaymentMode"];

                if (paymentMode == "test")
                {
                    site = "https://sandbox.payfast.co.za/eng/query/validate";
                    merchant_id = "10000100";
                }
                else if (paymentMode == "live")
                {
                    site = "https://www.payfast.co.za/eng/query/validate";
                    merchant_id = ConfigurationSettings.AppSettings["PF_MerchantID"];
                }
                else
                {
                    throw new InvalidOperationException("Cannot process payment if PaymentMode (in web.config) value is unknown.");
                }

                Log.Info(methodName, string.Format("Payment Environment {0}", site));

                // Get the posted signature from the form.
                string postedSignature = Request.Form["signature"];
                Log.Info(methodName, string.Format("Got Posted Signature {0}", postedSignature));

                if (string.IsNullOrEmpty(postedSignature))
                    throw new Exception("Signature parameter cannot be null");

                // Check if this is a legitimate request from the payment processor
                Log.Info(methodName, string.Format("Starting Security Checks..", ""));

                PerformSecurityChecks(arrPostedVariables, merchant_id);

                // The request is legitimate. Post back to payment processor to validate the data received
                Log.Info(methodName, string.Format("Validating Data...", ""));
                ValidateData(site, arrPostedVariables);

                // All is valid, process the order
                Log.Info(methodName, string.Format("Processing Data...", ""));
                ProcessOrder(arrPostedVariables);
            }
            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("Exception {0}", ex.Message));
            }

        }

        private void PerformSecurityChecks(NameValueCollection arrPostedVariables, string merchant_id)
        {

            // Verify that we are the intended merchant
            string receivedMerchant = arrPostedVariables["merchant_id"];

            if (receivedMerchant != merchant_id)
                throw new Exception("Mechant ID mismatch");

            // Verify that the request comes from the payment processor's servers.

            // Get all valid websites from payment processor
            string[] validSites = new string[] { "www.payfast.co.za", "sandbox.payfast.co.za", "w1w.payfast.co.za", "w2w.payfast.co.za" };

            // Get the requesting ip address
            string requestIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(requestIp))
                throw new Exception("IP address cannot be null");

            // Is address in list of websites
            if (!IsIpAddressInList(validSites, requestIp))
                throw new Exception("IP address invalid");
        }

        private bool IsIpAddressInList(string[] validSites, string ipAddress)
        {
            // Get the ip addresses of the websites
            ArrayList validIps = new ArrayList();

            for (int i = 0; i < validSites.Length; i++)
            {
                validIps.AddRange(System.Net.Dns.GetHostAddresses(validSites[i]));
            }

            IPAddress ipObject = IPAddress.Parse(ipAddress);

            if (validIps.Contains(ipObject))
                return true;
            else
                return false;
        }

        private void ValidateData(string site, NameValueCollection arrPostedVariables)
        {
            WebClient webClient = null;

            try
            {
                webClient = new WebClient();
                byte[] responseArray = webClient.UploadValues(site, arrPostedVariables);

                // Get the response and replace the line breaks with spaces
                string result = Encoding.ASCII.GetString(responseArray);
                result = result.Replace("\r\n", " ").Replace("\r", "").Replace("\n", " ");

                // Was the data valid?
                if (result == null || !result.StartsWith("VALID"))
                    throw new Exception("Data validation failed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (webClient != null)
                    webClient.Dispose();
            }
        }

        private void ProcessOrder(NameValueCollection arrPostedVariables)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;

            // Determine from payment status if we are supposed to credit or not
            string paymentStatus = arrPostedVariables["payment_status"];

            try
            {

                if (paymentStatus == "COMPLETE")
                {
                    var pigdealManager = new PigDealManager();
                    var dealId = orderId;
                    pigdealManager.UpdatePaymentStatus(int.Parse(dealId));
                    pigdealManager.UpdateInvoiceStatus(int.Parse(dealId));
                }
                else if (paymentStatus == "FAILED")
                {
                    // Update order to failed
                }
                else
                {
                    // Log for investigation
                }
            }
            catch (Exception ex)
            {
                // Handle errors here    
                Log.Info(methodName, string.Format("Exception {0}", ex.Message));
            }

        }


    }
}
