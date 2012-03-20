using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sandbox.PigDeal.Retail.Domain.Entities;

namespace Sandbox.PigDeal.Retail.Service
{
    
    [XmlSerializerFormat]
    [ServiceContract(Namespace = "http://flickit.co.za")]
    public interface IPigDealRestService
    {
        [OperationContract]
        [Description("Returns a list of active deals based on users current location")]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
        Method = "GET",
        UriTemplate = "/GetHandHeldLocationDeals?password={password}&phonelat={phonelat}&phonelon={phonelon}&range={range}&city={city}",
        RequestFormat = WebMessageFormat.Xml,
        ResponseFormat = WebMessageFormat.Xml)]
        List<HandHeldDealsEntity> GetHandHeldLocationDeals(string password,string phonelat, string phonelon, string range, string city);


        [OperationContract]
        [Description("Take up the deal")]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
        Method = "GET",
        UriTemplate = "/TakeUpDeal?password={password}&phonelat={phonelat}&phonelon={phonelon}&dealId={dealId}&deviceIdentifier={deviceIdentifier}",
        RequestFormat = WebMessageFormat.Xml,
        ResponseFormat = WebMessageFormat.Xml)]
        string TakeUpDeal(string password, double phonelat, double phonelon, int dealId, string deviceIdentifier);

    }
}
