﻿using Dealer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update()
        {
            SelfUpdate updater = new SelfUpdate(User.Identity.Name);

            return View();
        }



    }
}