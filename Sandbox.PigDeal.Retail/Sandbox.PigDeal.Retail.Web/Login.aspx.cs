using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly PigDealManager _pigDealManager = new PigDealManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogonClick(object sender, EventArgs e)
        {
            try
            {
                var authResponse = _pigDealManager.AuthenticateOutlet(txbUsername.Text.ToLower(), txbPassword.Text);
                if (authResponse.IsAuthenticated)
                {

                    FormsAuthentication.RedirectFromLoginPage(authResponse.OutletId.ToString(), true);
                    var tkt = new FormsAuthenticationTicket(1, authResponse.OutletId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), true, txbUsername.Text);
                    string cookiestr = FormsAuthentication.Encrypt(tkt);
                    var ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
                    {
                        Expires = tkt.Expiration,
                        Path = FormsAuthentication.FormsCookiePath
                    };

                    Response.Cookies.Add(ck);

                    string strRedirect = Request["ReturnUrl"];
                    if (strRedirect == null)
                    {
                        strRedirect = "~/MyAccount.aspx";
                        Response.Redirect(strRedirect, true);
                    }
                    else
                    {
                        Response.Redirect(strRedirect, true);
                    }



                }

                else
                {
                    lblAuthResponse.Text = "<div ID='error'>Invalid username or password.</div>";
                    lblAuthResponse.Visible = true;
                    txbUsername.Focus();
                }
            }
            catch (Exception)
            {

                lblAuthResponse.Text = "<div ID='error'>A error has occured. Please try again or contact our call center.</div>";
            }
           
        }

        protected void ShowPasswordPop(Object sender, EventArgs e)
        {
            pnlForgotPassword.Visible = true;
            updateViewDetails.Update();
            mdlPopupview.Show();
        }

        protected void SendPassword(Object sender, EventArgs e)
        {
            lblAuthResponse.Text = string.Empty;
            try
            {
               var doesExsist = _pigDealManager.SendPasswordReminder(txbForgotEmail.Text.Trim());

               if (doesExsist)
               {
                   lblAuthResponse.Text = "<div ID='error'>Email sent successfully.</div>";
                
               }

               else
               {
                   lblAuthResponse.Text = "<div ID='error'>We are unable to find you on our system.</div>";
                   
               }

            }
            catch (Exception)
            {

                lblAuthResponse.Text = "<div ID='error'>" + ConfigurationManager.AppSettings["SiteError"] + "</div>";
            }
        }
    }
}