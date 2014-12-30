using Dealer.Core;
using DealerBLL;
using DealerBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealer.Controllers
{
    public class WebsiteUpdatesController : Controller
    {
        /// <summary>
        /// Returns a partial view with instructions to update the website if an update exists
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAvailable()
        {
            return PartialView();
        }


        /// <summary>
        /// Updates the website and redirects to the update history screen
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            WebsiteUpdater updater = new WebsiteUpdater();
            updater.RunUpdates();
            return RedirectToAction("UpdateHistory");
        }


        /// <summary>
        /// Shows the history of updates made to the website
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateHistory()
        {
            IEnumerable<WebsiteUpdateInfoBO> model = WebsiteUpdateBLL.GetWebsiteUpdateInfo();
            return View(model);
        }

    }
}
