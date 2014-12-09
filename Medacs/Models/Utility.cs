using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medacs.Models
{
	public static class Utility
	{

		public static string Render(ControllerContext controller, string viewName, object model)
		{
			//controller.ViewData.Model = model;
			//controller.ViewData.Model = model;
			controller.Controller.ViewData.Model = model;


			using (var sw = new StringWriter())
			{
				var viewResult = ViewEngines.Engines.FindPartialView(controller, viewName);
				var viewContext = new ViewContext(controller, viewResult.View, controller.Controller.ViewData, controller.Controller.TempData, sw);
				viewResult.View.Render(viewContext, sw);
				viewResult.ViewEngine.ReleaseView(controller, viewResult.View);
				return sw.GetStringBuilder().ToString();
			}
		}
	}
}