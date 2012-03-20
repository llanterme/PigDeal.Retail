using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class DealValidationEntity
    {
        public string Message { get; set; }
        public bool IsCouponValid { get; set; }
    }
}
