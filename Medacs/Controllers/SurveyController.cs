using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Core.Managers;
using Ninject;

namespace Medacs.Controllers
{
    public class SurveyController : Controller
    {

		[Inject]
		public FeedbackManager FeedbackManager { get; set; }
		//
        // GET: /FeedBack/
		[HttpGet]
        public ActionResult ViewFeedBack(string Code)
		{
			var feedbackId = Guid.Parse("4FEE0E81-ED4A-E411-ADD7-001999EF2DC2");
			var feedback =FeedbackManager.GetFeedBackById(feedbackId);
			var question = feedback.FeedBackSection.Select(a => a.Questions).ToList();
			return View("FeedBackView",feedback);
        }


	}
}