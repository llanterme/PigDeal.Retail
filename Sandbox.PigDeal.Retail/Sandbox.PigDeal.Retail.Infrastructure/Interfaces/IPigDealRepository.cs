using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.PigDeal.Retail.Infrastructure.Catalog;

namespace Sandbox.PigDeal.Retail.Infrastructure.Interfaces
{
    public interface IPigDealRepository
    {
        // Outlets
        int CreateOutLet(Outlet outlet);
        List<Outlet> GetOutlets();
        Outlet GetOutlet(int outletId);

        //Branches
        void CreateBranch(Branch branch);
        List<Branch> GetBranches();

        //Deals
        int CreateDeal(Deal deal);
        void UpdateStatus(int dealId, string status);
        void UpdatePaymentStatus(int dealId, int flag);
        List<Deal> GetDeals();

        //Coupons
        List<Coupon> GetAllCoupons();
        void ClaimCoupon(Coupon coupon);

        //Invoices
        void CreateInvoice(Invoice invoice);
        void UpdateInvoiceStatus(int dealId, int flag);
        List<Invoice> GetInvoices(int ouletId);
    }
}
