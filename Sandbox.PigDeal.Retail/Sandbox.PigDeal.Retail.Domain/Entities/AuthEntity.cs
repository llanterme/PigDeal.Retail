using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class AuthEntity
    {
        public bool IsAuthenticated { get; set; }
        public int? OutletId { get; set; }
    }
}
