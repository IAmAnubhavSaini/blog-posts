using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhatAWebServerKnowsAboutYou.Startup))]
namespace WhatAWebServerKnowsAboutYou
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
