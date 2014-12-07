using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace WhatAWebServerKnowsAboutYou.Models
{
    public class Knowledge
    {
        public List<string> RequestList { get; private set; }
        public List<string> ResponseList { get; private set; } 

        public Knowledge(HttpRequest request, HttpResponse response)
        {
            MakeRequestMeaningFul(request);
            MakeResponseMeaningFul(response);
        }

        private void MakeRequestMeaningFul(HttpRequest request)
        {
            if (request.UserLanguages == null) return;
            foreach(var s in request.UserLanguages)
                RequestList.Add(s);
        }

        private void MakeResponseMeaningFul(HttpResponse response)
        {
            throw new NotImplementedException();
        }
    }
}