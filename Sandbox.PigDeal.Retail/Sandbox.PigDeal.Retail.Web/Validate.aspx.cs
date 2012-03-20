using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class Validate : System.Web.UI.Page
    {
        private readonly PigDealManager _outletManager = new PigDealManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateCoupon(object sender, EventArgs e)
        {
            lblvalidationResponse.Text = string.Empty;
            var validationResult = _outletManager.ValidateCoupon(txbValidateDeal.Text.Trim());
            if(validationResult.IsCouponValid)
            {
                imgResult.ImageUrl = "~/images/tick.png";
            }
            else
            {
                lblvalidationResponse.Text = "<div ID='error'>" + validationResult.Message + "</div>";
            }
        }
    }
}