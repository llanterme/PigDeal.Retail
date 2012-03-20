using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sandbox.PigDeal.Retail.Domain.Entities
{
    [XmlType("DealTakeUp")]
    [XmlRoot("DealTakeUp")]
    public class TakeUpDealEntity
    {

         [XmlElement(ElementName = "Message")]
        public string Message { get; set; }
    }
}
