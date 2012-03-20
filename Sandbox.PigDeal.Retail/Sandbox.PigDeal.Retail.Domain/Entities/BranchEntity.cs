using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class BranchEntity
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public string OperatingHours { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public int OutletId { get; set; }
        public int BranchId { get; set; }
    }
}
