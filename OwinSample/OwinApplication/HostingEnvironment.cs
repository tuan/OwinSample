using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace OwinApplication
{
    public static class HostingEnvironment
    {
        public static string Name { get; set; }

        public static IUnityContainer DependencyResolver { get; set; }
    }
}
