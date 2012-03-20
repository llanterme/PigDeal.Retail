using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    public class InvoiceEntity
    {
        public int DealId { get; set; }
        public int OutletId { get; set; }
        public int InvoiceId { get; set; }
        public string DatePaid { get; set; }
        public float Amount { get; set; }
        public string InvoiceNumber { get; set; }
        public string Title { get; set; }
        public int Furfilled { get; set; }
    }

}
