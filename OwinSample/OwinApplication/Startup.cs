﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Practices.Unity;
using Owin;

namespace OwinApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var dependencyResolver = HostingEnvironment.DependencyResolver;
            var logger = dependencyResolver.Resolve<Common.ILogger>();

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                var response = string.Format(
                    CultureInfo.InvariantCulture, "Current hosting environment is {0}", 
                    HostingEnvironment.Name);

                logger.Information(response);

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync(response);
            });
        }
    }
}
