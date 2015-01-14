using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using OwinApplication;

namespace SelfHost
{
    public class Program
    {
        private const string baseUri = "http://localhost:5000";

        public static void Main(string[] args)
        {
            HostingEnvironment.Name = "SelfHost";

            using (WebApp.Start<Startup>(url: baseUri))
            {
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseUri).Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
        }
    }
}
