using DealerBLL.BusinessObjects;
using DealerDAL.DAL;
using DealerDAL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL
{


    public class WebsiteUpdateBLL
    {

        /// <summary>
        /// Gets a collection of all updates prformed on a website with the most recent items first
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<WebsiteUpdateInfoBO> GetWebsiteUpdateInfo()
        {
            List<WebsiteUpdateInfoBO> updates = new List<WebsiteUpdateInfoBO>();

            foreach (WebsiteUpdateDO summary in WebsiteUpdate.GetAll())
            {
                WebsiteUpdateInfoBO update = new WebsiteUpdateInfoBO(summary);

                foreach (WebsiteUpdateLogDO logEntry in WebsiteUpdateLog.GetByWebsiteUpdateLog_WebsiteUpdateId(summary.WebsiteUpdateId))
                    update.AddLogEntry(logEntry);

                updates.Add(update);
            }

            return updates.OrderByDescending(u => u.UpdateSummary.InstallDate);
        }
    }
}
