using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Areas.Admin.Models;
using Medacs.Areas.Admin.Models.ViewModel;
using Medacs.Configure;
using Medacs.Core.Managers;
using Ninject;

namespace Medacs.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
		[Inject]
		public FeedbackManager FeedbackManager { get; set; } 
        //
        // GET: /Admin/Question/
        public ActionResult Index()
        {
            return View();
        }
}
}