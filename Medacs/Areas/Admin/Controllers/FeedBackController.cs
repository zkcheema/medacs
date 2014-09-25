using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Areas.Admin.Models.ViewModel;

namespace Medacs.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        //
        // GET: /Admin/FeedBack/
		[HttpGet]
        public ActionResult FeedBack()
        {
            return View("Create");
        }

		[HttpPost]
	    public ActionResult FeedBack(FeedBackViewModel  feedBackViewModel)
	    {


			return View("Create");
	    }
	}
}