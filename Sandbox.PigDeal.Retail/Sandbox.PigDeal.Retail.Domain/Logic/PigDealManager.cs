using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Mweb.Foundation.Practices.Logging;
using SandBox.PigDeal.Domain.Entities;
using SandBox.PigDeal.Infrastructure.Repository;
using Sandbox.PigDeal.Retail.Domain.Entities;
using Sandbox.PigDeal.Retail.Infrastructure.Catalog;
using Sandbox.PigDeal.Retail.Infrastructure.Interfaces;
using System.Configuration;

namespace Sandbox.PigDeal.Retail.Domain.Logic
{

    public class PigDealManager
    {
        private static readonly ILogger Log = LogManager.GetLogger(typeof(PigDealManager));
        private readonly IPigDealRepository _pigdealRepo;

        public PigDealManager()
        {
            _pigdealRepo = new PigDealRepository();
        }


        #region Outlet Logic

        //Creates a new Outlet
        public int CreateOutlet(OutletEntity newOutlet)
        {
            return _pigdealRepo.CreateOutLet(new Outlet
                                          {
                                              Description = newOutlet.Description,
                                              ContactNumber = newOutlet.ContactNumber,
                                              ContactPerson = newOutlet.ContactPerson,
                                              LoginEmail = newOutlet.LoginEmail,
                                              OutletName = newOutlet.OutletName,
                                              Password = newOutlet.Password,
                                          });
        }

        public OutletEntity GetOutlet(int outletId)
        {
            return (from allOutlets in _pigdealRepo.GetOutlets().Where(a => a.OutletId == outletId)
                    select new OutletEntity
                               {
                                   OutletName = allOutlets.OutletName,
                                   ContactNumber = allOutlets.ContactNumber,
                                   ContactPerson = allOutlets.ContactPerson,
                                   Description = allOutlets.Description,
                                   LoginEmail = allOutlets.LoginEmail,
                                   Password = allOutlets.Password,
                               }).SingleOrDefault();
        }

        //Authenticate a user
        public AuthEntity AuthenticateOutlet(string loginEmail, string loginPassword)
        {
            var validOutlet = new AuthEntity();
            Outlet outletQuery;
            try
            {
                outletQuery = (from allOutlets in
                                   _pigdealRepo.GetOutlets().Where(a => a.LoginEmail == loginEmail && a.Password == loginPassword)
                               select allOutlets).SingleOrDefault();

                if (outletQuery == null)
                {
                    validOutlet.IsAuthenticated = false;
                    validOutlet.OutletId = null;

                }

                else
                {
                    validOutlet.IsAuthenticated = true;
                    validOutlet.OutletId = outletQuery.OutletId;

                }
            }
            catch (Exception)
            {

                throw;
            }



            return validOutlet;
        }

        //Outlet name lookup
        public string GetOutLetName(int outletId)
        {
            return _pigdealRepo.GetOutlet(outletId).OutletName;
        }

        // Gets Deal information
        public DealEntity GetDealInformation(int dealId)
        {

            return (from alluserDeals in _pigdealRepo.GetDeals().Where(a => a.DealId == dealId)
                    select new DealEntity
                               {
                                   Coupons = GetCoupons(dealId),
                                   Discount = alluserDeals.Discount,
                                   Scoop = alluserDeals.Scoop,
                                   Title = alluserDeals.Title,

                               }).SingleOrDefault();
        }

        //Send Forgot Password
        public bool SendPasswordReminder(string outletEmail)
        {
            try
            {
                //Get outlet Information
                var outletQuery = (from allOutlets in _pigdealRepo.GetOutlets().Where(a => a.LoginEmail == outletEmail)
                                   select allOutlets).FirstOrDefault();

                if (outletQuery != null)
                {
                    if (ConfigurationManager.AppSettings["IsMailEnabled"] == "true")
                    {
                        //fire off email
                        var mailClient = new MailManager();
                        var publicationParams = new Dictionary<string, string>();
                        publicationParams.Add("#OutLetName#", outletQuery.OutletName);
                        publicationParams.Add("#Username#", outletQuery.LoginEmail);
                        publicationParams.Add("#Password#", outletQuery.Password);

                        mailClient.SendPublication(outletEmail, publicationParams);
                    }

                    return true;
                }
                else
                {
                    //Email Not Found
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Branches Logic

        public void CreateBranch(BranchEntity newBranch)
        {
            _pigdealRepo.CreateBranch(new Branch
                                          {
                                              Address1 = newBranch.Address1,
                                              Address2 = newBranch.Address2,
                                              City = newBranch.City,
                                              Telephone = newBranch.Telephone,
                                              Description = newBranch.Description,
                                              PostCode = newBranch.PostCode,
                                              Email = newBranch.Email,
                                              Latitude = newBranch.Lat,
                                              Longitude = newBranch.Long,
                                              Name = newBranch.Name,
                                              OperatingHours = newBranch.OperatingHours,
                                              OutletId = newBranch.OutletId,
                                          });
        }

        public List<BranchEntity> GetOutletBranches(int outletId)
        {
            return (from allBranches in _pigdealRepo.GetBranches().Where(a => a.OutletId == outletId)
                    select new BranchEntity
                               {
                                   Address1 = allBranches.Address1,
                                   Address2 = allBranches.Address2,
                                   City = allBranches.City,
                                   BranchId = allBranches.BranchId,
                                   Description = allBranches.Description,
                                   Email = allBranches.Email,
                                   Lat = allBranches.Latitude,
                                   Long = allBranches.Longitude,
                                   Name = allBranches.Name,
                                   OperatingHours = allBranches.OperatingHours,
                               }).ToList();
        }

        public BranchEntity GetBranchDetails(int branchId)
        {
            return (from allBranches in _pigdealRepo.GetBranches().Where(a => a.BranchId == branchId)
                    select new BranchEntity
                    {
                        Address1 = allBranches.Address1,
                        Address2 = allBranches.Address2,
                        PostCode = allBranches.PostCode,
                        Telephone = allBranches.Telephone,
                        City = allBranches.City,
                        Description = allBranches.Description,
                        Email = allBranches.Email,
                        Lat = allBranches.Latitude,
                        Long = allBranches.Longitude,
                        Name = allBranches.Name,
                        OperatingHours = allBranches.OperatingHours,
                    }).SingleOrDefault();
        }

        public bool HasBranches(int outetId)
        {

            if (GetOutletBranches(outetId).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Deals Logic
        public int CreateDeal(DealEntity newDeal, InvoiceEntity newInvoice)
        {

            if (!IsValidDeal(int.Parse(newDeal.Duration), newDeal.StartDate, newDeal.StartTime))
            {
                var dealId = _pigdealRepo.CreateDeal(new Deal
                                            {
                                                BranchId = newDeal.BranchId,
                                                Claimed = 0,
                                                OutletId = newDeal.OutletId,
                                                Duration = newDeal.Duration,
                                                Scoop = newDeal.Scoop,
                                                Title = newDeal.Title,
                                                Created = newDeal.Created,
                                                Discount = newDeal.Discount,
                                                StartDate = newDeal.StartDate,
                                                StartTime = newDeal.StartTime,
                                                Payment = 0,
                                                Status = "Active"
                                            });

                _pigdealRepo.CreateInvoice(new Invoice
                                               {
                                                   DealId = dealId,
                                                   OutletId = newInvoice.OutletId,
                                                   Amount = newInvoice.Amount.ToString(),
                                                   DatePaid = DateTime.Now.ToString(),
                                                   Furfilled = 0,
                                                   InvoiceNumber = newInvoice.InvoiceNumber
                                               });
                //Update status
                UpdateStatus(dealId, int.Parse(newDeal.Duration), newDeal.StartDate, newDeal.StartTime);

                return dealId;
            }
            else
            {
                return 0;
            }


        }

        public List<DealEntity> GetOutletActiveDeals(int outletId)
        {
            var activeDealsQuery = from allDeals in _pigdealRepo.GetDeals().Where(a => a.OutletId == outletId)
                                   select allDeals;

            var activeDeals = new List<DealEntity>();
            foreach (Deal deal in activeDealsQuery)
            {
                //Update status
                UpdateStatus(deal.DealId, int.Parse(deal.Duration), deal.StartDate, deal.StartTime);

                if (!IsValidDeal(int.Parse(deal.Duration), deal.StartDate, deal.StartTime) && deal.Payment == 1)
                {

                    var startTime = Convert.ToDateTime(String.Format("{0} {1}", deal.StartDate, deal.StartTime));
                    activeDeals.Add(new DealEntity
                                        {
                                            Title = deal.Title,
                                            Created = deal.Created,
                                            Status = deal.Status,
                                            StartDate = startTime.ToString(),
                                            Expires = startTime.AddHours(double.Parse(deal.Duration)).ToString(),
                                            Claimed = deal.Claimed,
                                            DealId = deal.DealId
                                        });
                }
            }

            return activeDeals;
        }

        public List<DealEntity> GetOutletExpiredDeals(int outletId)
        {
            return (from alldeals in _pigdealRepo.GetDeals().Where(a => a.OutletId == outletId && a.Status.Trim() == "Expired")
                    select new DealEntity
                               {
                                   Title = alldeals.Title,
                                   Created = alldeals.Created,
                                   StartDate = Convert.ToDateTime(String.Format("{0} {1}", alldeals.StartDate, alldeals.StartTime)).ToString(),
                                   Expires = Convert.ToDateTime(String.Format("{0} {1}", alldeals.StartDate, alldeals.StartTime)).AddHours(double.Parse(alldeals.Duration)).ToString(),
                                   Status = alldeals.Status,
                                   Claimed = alldeals.Claimed,
                                   DealId = alldeals.DealId

                               }).ToList();
        }

        public void UpdatePaymentStatus(int dealId)
        {
            _pigdealRepo.UpdatePaymentStatus(dealId, 1);

        }

        private static bool IsValidDeal(int duration, string startDate, string startTime)
        {
            var today = DateTime.Now;
            var dealStarts = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime));
            var dealExpires = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime)).AddHours(duration);

            if (today > dealExpires)
            {
                //Console.WriteLine("Deal has expired!");
                return true;

            }
            else
            {
                //Console.WriteLine("Deal is valid!");
                return false;
            }
        }

        private void UpdateStatus(int dealId, int duration, string startDate, string startTime)
        {
            // Is deal in future
            var dealStarts = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime));
            var dealExpires = Convert.ToDateTime(string.Format("{0} {1}", (startDate), startTime)).AddHours(duration);

            if (dealStarts > DateTime.Now)
            {
                //Update status to pending
                _pigdealRepo.UpdateStatus(dealId, "Pending");
                Console.WriteLine("Deal is in future so pending.");


            }
            else if (dealStarts < DateTime.Now && DateTime.Now < dealExpires)
            {
                //Update status to active
                _pigdealRepo.UpdateStatus(dealId, "Active");
                Console.WriteLine("Deal is currently active.");

            }

            else
            {
                //Update status to expired
                _pigdealRepo.UpdateStatus(dealId, "Expired");
                Console.WriteLine("Deal expired.");

            }

        }

        #endregion

        #region Geo Location Logic
        public Coordinate LookupLatLong(string address1, string address2, string city, string postcode)
        {
            var completeAddress = string.Format("{0} {1} {2} {3}", address1, address2, city, postcode);
            return GetLatitudeAndLongitudeByAddress(completeAddress);

        }

        private static Coordinate GetLatitudeAndLongitudeByAddress(string address)
        {
            var coordinates = new Coordinate();
            var client = new WebClient();

            const string geoCodeUrl = "http://maps.google.com/maps/geo?sensor=false&output=csv&ce=utf8&q={0}&key={1}";

            string formattedUri = String.Format(CultureInfo.InvariantCulture,
                                  geoCodeUrl, address, "");

            string[] geocodeParams = client.DownloadString(formattedUri).Split(',');
            if (geocodeParams[0] == "200")
            {
                coordinates.Latitude = Convert.ToSingle(geocodeParams[2]);
                coordinates.Longitude = Convert.ToSingle(geocodeParams[3]);
            }
            return coordinates;
        }

        public static double CalulateDistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        #endregion

        #region HandHeld Logic
        public IEnumerable<HandHeldDealsEntity> GetHandHeldLocationDeals(double phonelat, double phonelon, string range, string city)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            try
            {

                // Check if distance param is set to "City"
                if (range.ToLower().Trim() == "city")
                {
                    range = ConfigurationManager.AppSettings["MaxDistance"];
                }

                var activeDealsQuery = from allDeals in _pigdealRepo.GetDeals()
                                       select allDeals;

                if (city.ToLower().Trim() == string.Empty)
                {
                    activeDealsQuery = activeDealsQuery.Where(a => a.Status.Trim() == "Active" && a.Payment == 1);
                }

                else
                {
                    activeDealsQuery = activeDealsQuery.Where(a => a.Status.Trim() == "Active" && a.Branch.City.ToLower() == city.Trim().ToLower() && a.Payment == 1);
                }



                var handHelpDealsList = new List<HandHeldDealsEntity>();
                foreach (var value in activeDealsQuery)
                {
                    if (CalulateDistance(phonelat, phonelon, double.Parse(value.Branch.Latitude), double.Parse(value.Branch.Longitude), 'K') <= Int64.Parse(range))
                    {
                        handHelpDealsList.Add(new HandHeldDealsEntity
                        {
                            Title = value.Title,
                            BranchName = value.Branch.Name,
                            Scoop = value.Scoop,
                            Discount = value.Discount + "%",
                            Range = Math.Round(CalulateDistance(phonelat, phonelon, double.Parse(value.Branch.Latitude), double.Parse(value.Branch.Longitude), 'K'), 2),
                            Expires = Convert.ToDateTime(string.Format("{0} {1}", (value.StartDate), value.StartTime)).AddHours(double.Parse(value.Duration)).ToString(),
                            DealId = value.DealId,
                            Telephone = value.Branch.Telephone,
                            Address = string.Format("{0},{1},{2},{3}", value.Branch.Address1, value.Branch.Address2, value.Branch.City, value.Branch.PostCode),
                            Claimed = value.Claimed,
                            Message = "Success",
                        });
                    }
                }

                return handHelpDealsList.OrderBy(a => a.Range);
            }

            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("Exception {0}", ex.Message));
                return new List<HandHeldDealsEntity>
                           {
                              new HandHeldDealsEntity
                                  {
                                        Message = "An Error has occured.",
                                        Title = null,
                                        BranchName = null,
                                        Scoop = null,
                                        Discount = null,
                                        Range = 0,
                                        Expires = null,
                                        DealId = 0,
                                        Telephone = null,
                                        Address = null,
                                        Claimed = 0,
                                  }

                           };

                // Log Exception
            }

        }

        public string TakeUpDeal(double phonelat, double phonelon, int dealId, string deviceIdentifier)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                //Check if user is at the outlet - within 500m at least
                var dealDetails = (from allDeals in _pigdealRepo.GetDeals().Where(a => a.DealId == dealId)
                                   select allDeals).FirstOrDefault();

                // Check if is dealId is valid
                if (dealDetails == null)
                {
                    // Log --> Invalid Deal Id
                    Log.Info(methodName, string.Format("Invalid Deal Id: {0}", dealId));
                    return ConfigurationManager.AppSettings["TakeUpErrorText"];
                }

                var distance = CalulateDistance(phonelat, phonelon, double.Parse(dealDetails.Branch.Latitude),
                                                double.Parse(dealDetails.Branch.Longitude), 'K');

                if (distance > double.Parse(ConfigurationManager.AppSettings["RangeToOutlet"]))
                {
                    //Not at Outlet.
                    return string.Format((ConfigurationManager.AppSettings["NotAtOutLetText"]),
                    Math.Round(
                        CalulateDistance(phonelat, phonelon,
                                         double.Parse(dealDetails.Branch.Latitude),
                                         double.Parse(dealDetails.Branch.Longitude), 'K'), 2));
                }

                else //User is at outlet
                {

                    // Check if user has already claimed this deal
                    var hasClaimedQuery =
                        (from allCoupons in _pigdealRepo.GetAllCoupons().Where(a => a.DeviceIdentifier == deviceIdentifier && a.DealId == dealId)
                         select allCoupons).FirstOrDefault();

                    if (hasClaimedQuery == null)
                    {
                        // Claim Deal
                        var userRef = RandomString(10);
                        _pigdealRepo.ClaimCoupon(new Coupon
                        {
                            DealId = dealId,
                            DeviceIdentifier = deviceIdentifier,
                            UserReference = userRef,

                        });

                        return string.Format((ConfigurationManager.AppSettings["CongratsText"]),
                                          userRef);

                    }

                    else // User has already claimed deal
                    {

                        return string.Format((ConfigurationManager.AppSettings["AlreadyClaimedText"]), hasClaimedQuery.UserReference);
                    }
                }

            }
            catch (Exception ex)
            {

                Log.Info(methodName, string.Format("Exception {0}", ex.Message));
                return ConfigurationManager.AppSettings["TakeUpErrorText"];

            }



        }

        #endregion

        #region Coupons Logic

        public DealValidationEntity ValidateCoupon(string reference)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                var validationResult = new DealValidationEntity();
                var couponQuery = (from allCoupons in _pigdealRepo.GetAllCoupons().Where(a => a.UserReference == reference.ToUpper())
                                   select allCoupons).SingleOrDefault();

                if (couponQuery == null)
                {
                    // Cant find coupon at all
                    validationResult.IsCouponValid = false;
                    validationResult.Message = "Deal reference not found.";

                }

                else // Found coupon
                {
                    // Now check if deal is still valid
                    {
                        if (!IsValidDeal(int.Parse(couponQuery.Deal.Duration.Trim()), couponQuery.Deal.StartDate, couponQuery.Deal.StartTime))
                        {
                            // Still active
                            validationResult.IsCouponValid = true;
                            validationResult.Message = string.Empty;
                        }

                        else
                        {
                            // Deal is not valid anymore
                            validationResult.IsCouponValid = false;
                            validationResult.Message = "Deal has expired or is no longer valid.";
                        }
                    }

                }

                return validationResult;
            }
            catch (Exception ex)
            {
                Log.Info(methodName, string.Format("Exception: {0}", ex.Message));
                return new DealValidationEntity
                           {
                               IsCouponValid = false,
                               Message = ConfigurationManager.AppSettings["SiteError"],

                           };
            }



        }

        private List<CouponEntity> GetCoupons(int dealId)
        {
            return (from allCoupons in _pigdealRepo.GetAllCoupons().Where(a => a.DealId == dealId)
                    select new CouponEntity
                    {
                        CouponId = allCoupons.CouponId,
                        UserReference = allCoupons.UserReference,
                    }).ToList();
        }

        #endregion

        #region Invoice
        public void UpdateInvoiceStatus(int dealId)
        {
            _pigdealRepo.UpdateInvoiceStatus(dealId, 1);

        }

        public IEnumerable<InvoiceEntity> GetOutletInvoices(int outletId)
        {
            return (from allInvoices in _pigdealRepo.GetInvoices(outletId).Where(a => a.Furfilled == 1)
                    select new InvoiceEntity
                               {
                                    Amount = float.Parse(allInvoices.Amount),
                                    DatePaid = allInvoices.DatePaid,
                                    InvoiceNumber = allInvoices.InvoiceNumber,
                                    Title = allInvoices.Deal.Title,
                               }).OrderByDescending(a => a.InvoiceId).ToList();
        }

        #endregion

        #region Utils
        public bool IsOutletRegistered(string outletName, string outletEmail)
        {
            var query = (from allOutlets in _pigdealRepo.GetOutlets().Where(a => a.OutletName == outletName && a.LoginEmail == outletEmail)
                         select allOutlets).SingleOrDefault();

            if (query == null)
            {
                return false;
            }

            else
            {
                return true;
            }


        }

        public bool IsBranchRegistered(string branchName, string branchEmail)
        {
            var query = (from allbranches in _pigdealRepo.GetBranches().Where(a => a.Name == branchName && a.Email == branchEmail)
                         select allbranches).SingleOrDefault();

            if (query == null)
            {
                return false;
            }

            else
            {
                return true;
            }


        }

        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        public string RandomString(int size)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        #endregion


    }
}
