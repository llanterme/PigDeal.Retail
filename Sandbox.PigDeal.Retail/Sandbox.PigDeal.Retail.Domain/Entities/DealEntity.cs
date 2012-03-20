using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class DealEntity
    {
        public int OutletId { get; set; }
        public int DealId { get; set; }
        public int BranchId { get; set; }
        public int Claimed { get; set; }
        public string Title { get; set; }
        public string Scoop { get; set; }
        public string Expires { get; set; }
        public string Discount { get; set; }
        public string Created { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public int Payment { get; set; }
        public List<CouponEntity> Coupons { get; set; }

    }
}
