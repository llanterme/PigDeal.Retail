using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PigDealRestService : IPigDealRestService
    {
        private readonly PigDealManager _pigDealManager = new PigDealManager();
        public List<HandHeldDealsEntity> GetHandHeldLocationDeals(string password, string phonelat, string phonelon, string range, string city)
        {
            if (ConfigurationManager.AppSettings["ServicePassword"] != password)
            {
                return new List<HandHeldDealsEntity>
                             {
                                 new HandHeldDealsEntity
                                     {
                                         Message = "Authentication Failure."

                                     }
                             };
            }
            else
            {
                return _pigDealManager.GetHandHeldLocationDeals(double.Parse(phonelat), double.Parse(phonelon), range, city).ToList();
            }


        }

        public string TakeUpDeal(string password, double phonelat, double phonelon, int dealId, string deviceIdentifier)
        {
            if (ConfigurationManager.AppSettings["ServicePassword"] != password)
            {
                return "Authentication Failure.";
            }
            else
            {
                return _pigDealManager.TakeUpDeal(phonelat, phonelon, dealId, deviceIdentifier);    
            }
            
        }
    }
}
