using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatAWebServerKnowsAboutYou.Controllers
{
    public class FingerprintController : Controller
    {
        // GET: Fingerprint
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Me()
        {
            return View();
        }
    }
}