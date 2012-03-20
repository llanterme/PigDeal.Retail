using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web
{
    public partial class DealHistory : System.Web.UI.Page
    {
        private readonly PigDealManager _pigdealManager = new PigDealManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindDealHistory();
            }
        }

        protected void BindDealHistory()
        {
            var expiredDeals = _pigdealManager.GetOutletExpiredDeals(int.Parse(User.Identity.Name));

            if (expiredDeals.Count != 0)
            {
                lvDealHistory.DataSource = expiredDeals;
                lvDealHistory.DataBind();
            }

            else
            {
                lblNoDeal.Text = "<div ID='error'>No deals where found.</div>";
                lblNoDeal.Visible = true;
            }
        }

        protected void ViewDealDetails(object sender, ImageClickEventArgs e)
        {
            var btnView = sender as ImageButton;
            var dealInformation = _pigdealManager.GetDealInformation(int.Parse(btnView.CommandArgument));

            ddlCoupons.DataSource = dealInformation.Coupons;
            ddlCoupons.DataValueField = "CouponId";
            ddlCoupons.DataTextField = "UserReference";
            ddlCoupons.DataBind();

            lblTitle.Text = dealInformation.Title;
            lblDiscount.Text = dealInformation.Discount + "%";
            txbDealDetails.Text = dealInformation.Scoop;

            updateViewDetails.Update();
            mdlPopupview.Show();
        }
    }
}