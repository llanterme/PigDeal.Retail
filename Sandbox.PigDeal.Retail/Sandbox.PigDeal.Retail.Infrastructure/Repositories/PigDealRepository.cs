using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Sandbox.PigDeal.Retail.Infrastructure.Catalog;
using Sandbox.PigDeal.Retail.Infrastructure.Context;
using Sandbox.PigDeal.Retail.Infrastructure.Interfaces;

namespace SandBox.PigDeal.Infrastructure.Repository
{
    public class PigDealRepository : BaseDataContext, IPigDealRepository 
    {
        public int CreateOutLet(Outlet outlet)
        {
            DataContext.Outlets.InsertOnSubmit(outlet);
            DataContext.SubmitChanges();

            return outlet.OutletId;
        }

        public List<Outlet> GetOutlets()
        {
            return DataContext.Outlets.ToList();
        }

        public Outlet GetOutlet(int outletId)
        {
            return DataContext.Outlets.Where(a => a.OutletId == outletId).SingleOrDefault();
        }

        public void CreateBranch(Branch branch)
        {
            DataContext.Branches.InsertOnSubmit(branch);
            DataContext.SubmitChanges();
        }

        public List<Branch> GetBranches()
        {
            return DataContext.Branches.ToList();
        }

        public int CreateDeal(Deal deal)
        {
            DataContext.Deals.InsertOnSubmit(deal);
            DataContext.SubmitChanges();

            return deal.DealId;
        }

        public List<Deal> GetDeals()
        {
            return DataContext.Deals.ToList();
        }

        public void UpdateStatus(int dealId, string status)
        {
            var dealQuery = (from deals in DataContext.Deals
                             where deals.DealId == dealId
                             select deals).First();

            dealQuery.Status = status;
            DataContext.SubmitChanges();
        }

        public void UpdatePaymentStatus(int dealId, int flag)
        {
            var dealQuery = (from deals in DataContext.Deals
                             where deals.DealId == dealId
                             select deals).First();

            dealQuery.Payment = flag;
            DataContext.SubmitChanges();
        }

        public List<Coupon> GetAllCoupons()
        {
            return DataContext.Coupons.ToList();
        }

        public void ClaimCoupon(Coupon coupon)
        {
            DataContext.Coupons.InsertOnSubmit(coupon);
            DataContext.SubmitChanges();

            UpdateClaimed(coupon.DealId);
        }

        private void UpdateClaimed(int dealId)
        {
            var dealQuery = (from deals in DataContext.Deals
                             where deals.DealId == dealId
                             select deals).First();

            dealQuery.Claimed = dealQuery.Claimed + 1;
            DataContext.SubmitChanges();
        }

        public void CreateInvoice(Invoice invoice)
        {
            DataContext.Invoices.InsertOnSubmit(invoice);
            DataContext.SubmitChanges();
        }

        public void UpdateInvoiceStatus(int dealId, int flag)
        {
            var dealQuery = (from deals in DataContext.Invoices
                             where deals.DealId == dealId
                             select deals).First();

            dealQuery.Furfilled = flag;
            DataContext.SubmitChanges();
        }

        public List<Invoice> GetInvoices(int ouletId)
        {
            return DataContext.Invoices.Where(a => a.OutletId == ouletId).ToList();
        }

    }
}
