using Ninject;
using Ninject.Web.Common.WebHost;
using SSGeek.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSGeek
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        // Configure the dependency injection container.
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            string connectionString = ConfigurationManager.ConnectionStrings["SSGeek"].ConnectionString;

            // Set up the bindings
            //kernel.Bind<IInterface>.To<Class>();
            kernel.Bind<IForumPostDAL>().To<ForumPostSqlDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IProductDAL>().To<ProductSqlDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
