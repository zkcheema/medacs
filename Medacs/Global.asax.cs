using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Medacs.Core.Infrastructure.DataContext;
using Newtonsoft.Json;

namespace Medacs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()

        {
			Database.SetInitializer<MedacsDbContext>(null);
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());
			var dbContent = new MedacsDbContext();
			dbContent.Database.CreateIfNotExists();
			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				Formatting = Newtonsoft.Json.Formatting.Indented,
				ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			};
        }
    }
}
