using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class OutletEntity
    {
        public string OutletName { get; set; }
        public string Description { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public int OutletId { get; set; }
    }
}
