using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Core.Managers;
using Medacs.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;


namespace Medacs.Controllers
{


	public class HomeController : Controller
	{
		[Inject]
		public ReportManager ReportManager { get; set; }
		[Inject]
		public FeedbackManager FeedbackManager { get; set; }
	
		public ActionResult Index()
		{
			var usermanager = new UserManager();

			if (User.Identity.IsAuthenticated)

			{
				if (User.Identity.IsAuthenticated && usermanager.IsInRole(User.Identity.GetUserId(), "User".ToLower()) ||
				    (User.IsInRole("Admin".ToLower())))
				{
					
					var user =FeedbackManager.GetUser(Guid.Parse(User.Identity.GetUserId()));
				
					

					return View();
				}
			}

			return View("Error");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}