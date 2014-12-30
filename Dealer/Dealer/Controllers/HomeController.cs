using Dealer.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealer.Controllers
{
    public class HomeController : Controller
    {
        private static ILog logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update()
        {
            WebsiteUpdater updater = new WebsiteUpdater();
            updater.RunUpdates();
            return View();
        }

        public ActionResult Restore()
        {
            WebsiteUpdater updater = new WebsiteUpdater();
            updater.RestorePackage(14122901);
            return View();
        }



    }
}
