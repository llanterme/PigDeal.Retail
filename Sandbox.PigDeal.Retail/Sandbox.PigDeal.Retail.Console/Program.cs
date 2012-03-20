using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SandBox.PigDeal.Infrastructure.Repository;
using Sandbox.PigDeal.Retail.Infrastructure.Catalog;
using Sandbox.PigDeal.Retail.Infrastructure.Interfaces;

namespace Sandbox.PigDeal.Retail.Console
{
   public class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                ExpireDeals();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public static void ExpireDeals()
        {
            try
            {
                IPigDealRepository pigdealRepo = new PigDealRepository();

                var activeDealsQuery = from allDeals in pigdealRepo.GetDeals().Where(a => a.Status != "Expire")
                                       select allDeals;

                foreach (Deal deal in activeDealsQuery)
                {
                    UpdateStatus(deal.DealId, int.Parse(deal.Duration), deal.StartDate, deal.StartTime);
                }
            }
            catch (Exception)
            {
                
                //LOG
                throw;
            }
           

        }

        private static void UpdateStatus(int dealId, int duration, string startDate, string startTime)
        {
            try
            {
                IPigDealRepository pigdealRepo = new PigDealRepository();

                // Is deal in future
                var dealStarts = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime));
                var dealExpires = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime)).AddHours(duration);

                if (dealStarts > DateTime.Now)
                {
                    //Update status to pending
                    pigdealRepo.UpdateStatus(dealId, "Pending");



                }
                else if (dealStarts < DateTime.Now && DateTime.Now < dealExpires)
                {
                    //Update status to active
                    pigdealRepo.UpdateStatus(dealId, "Active");


                }

                else
                {
                    //Update status to expired
                    pigdealRepo.UpdateStatus(dealId, "Expired");


                }

            }
            catch (Exception)
            {
                //LOG
                throw;
            }
            

        }
    }
}
