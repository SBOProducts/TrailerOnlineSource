using DealerDAL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerBLL.BusinessObjects
{
    public class WebsiteUpdateInfoBO
    {
        List<WebsiteUpdateLogDO> _log = new List<WebsiteUpdateLogDO>();

        public WebsiteUpdateInfoBO(WebsiteUpdateDO SummaryData)
        {
            UpdateSummary = SummaryData;
        }

        public void AddLogEntry(WebsiteUpdateLogDO entry)
        {
            _log.Add(entry);
        }

        public WebsiteUpdateDO UpdateSummary { get; private set; }

        public IEnumerable<WebsiteUpdateLogDO> UpdateLog { get { return _log as IEnumerable<WebsiteUpdateLogDO>; } }
    }
}
