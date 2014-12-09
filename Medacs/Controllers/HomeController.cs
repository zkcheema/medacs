using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Medacs.Controllers
{


	public class HomeController : Controller
	{

	
		public ActionResult Index()
		{
			var usermanager = new UserManager();

			if (User.Identity.IsAuthenticated)

			{
				if (User.Identity.IsAuthenticated && usermanager.IsInRole(User.Identity.GetUserId(), "User") ||
				    (User.IsInRole("Admin")))
				{
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