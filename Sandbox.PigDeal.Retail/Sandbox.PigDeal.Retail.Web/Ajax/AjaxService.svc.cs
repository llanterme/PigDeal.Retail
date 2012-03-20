using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Web.Ajax
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AjaxService
    {
        private readonly PigDealManager _outletManager = new PigDealManager();


       // [OperationContract]
       // [WebInvoke(Method = "POST",
       // BodyStyle = WebMessageBodyStyle.WrappedRequest,
       // ResponseFormat = WebMessageFormat.Json,
       // RequestFormat = WebMessageFormat.Json)]
       //// public bool DoesExists(string param)
       ////{
       //// //   return _outletManager.CheckDuplicate(param);
       ////}

        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        public string CreateOutlet(OutletEntity outlet)
        {
            try
            {
                _outletManager.CreateOutlet(outlet);
                return "success";
            }
            catch (Exception)
            {
                
                return "failed";
            }

            
        }
    }
}
