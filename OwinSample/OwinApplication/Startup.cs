using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace OwinApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                var response = string.Format(
                    CultureInfo.InvariantCulture, "Current hosting environment is {0}", 
                    HostingEnvironment.Name);

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync(response);
            });
        }
    }
}
