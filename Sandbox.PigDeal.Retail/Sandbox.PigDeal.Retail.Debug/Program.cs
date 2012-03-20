using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Sandbox.PigDeal.Retail.Domain.Logic;

namespace Sandbox.PigDeal.Retail.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var _manager = new PigDealManager();
            var mailClient = new MailManager();

            var publicationParams = new Dictionary<string, string>();
            publicationParams.Add("#OutLetName#", "Steers");
            publicationParams.Add("#Username#", "llanterme@mweb.co.za");
            publicationParams.Add("#Password#", "password");
           
            mailClient.SendPublication("luke@pigdeal.co.za", publicationParams);


        }
    }
}