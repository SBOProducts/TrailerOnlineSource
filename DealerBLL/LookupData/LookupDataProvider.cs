using DealerDAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.LookupData
{
    /// <summary>
    /// Provides general, low-level data management service using category, name, and value 
    /// </summary>
    public class LookupDataProvider: ILookupDataProvider
    {
        ILookupService _lookupService;

        public LookupDataProvider(ILookupService LookupService)
        {
            _lookupService = LookupService;
        }


    }
}
