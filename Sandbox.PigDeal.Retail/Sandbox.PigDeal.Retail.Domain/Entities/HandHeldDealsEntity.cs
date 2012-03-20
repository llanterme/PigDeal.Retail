using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{

    [XmlType("Deal")]
    [XmlRoot("Deal")]
    public class HandHeldDealsEntity
    {
        [XmlElement(ElementName = "dealsClaimed")]
        public int Claimed { get; set; }

        [XmlElement(ElementName = "dealTitle")]
        public string Title { get; set; }

        [XmlElement(ElementName = "dealDesc")]
        public string Scoop { get; set; }

        [XmlElement(ElementName = "dealExpire")]
        public string Expires { get; set; }

        [XmlElement(ElementName = "dealDiscount")]
        public string Discount { get; set; }


        [XmlElement(ElementName = "dealAddress")]
        public string Address { get; set; }

        [XmlElement(ElementName = "dealTelephone")]
        public string Telephone { get; set; }

        [XmlElement(ElementName = "OutletName")]
        public string BranchName { get; set; }

        [XmlElement]
        public double Range { get; set; }

        [XmlElement(ElementName = "DealId")]
        public int DealId { get; set; }

        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }

    }


}
