using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Sandbox.PigDeal.Retail.Infrastructure.Catalog;


namespace Sandbox.PigDeal.Retail.Infrastructure.Context
{
    public class BaseDataContext
    {
        private LinqCatalogDataContext _dataContext;
        public LinqCatalogDataContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = new LinqCatalogDataContext(ConfigurationManager.ConnectionStrings["PigDeal"].ConnectionString);
                }

                return _dataContext;
            }
        }


    }
}
