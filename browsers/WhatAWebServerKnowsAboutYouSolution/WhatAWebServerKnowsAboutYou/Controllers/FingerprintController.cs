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
            List<string> Info = new List<string>();
            Info.Add("-------------------------------Browser Info-------------------------------");
            foreach (var key in Request.Browser.Capabilities.Keys)
            {
                Info.Add(key + " = " + Request.Browser.Capabilities[key]);
            }
            Info.Add("-------------------------------Requst Header Info-------------------------------");
            for (int i = 0; i < Request.Headers.Count; i++ )
            {
                Info.Add(Request.Headers[i]);
            }
            Info.Add("-------------------------------Response Header Info-------------------------------");
            for (int i = 0; i < Response.Headers.Count; i++)
            {
                Info.Add(Response.Headers[i]);
            }
            Info.Add("-------------------------------Accepted types-------------------------------");
            foreach (var type in Request.AcceptTypes)
            {
                Info.Add(type);
            }
            
            return View(Info);
        }
    }
}