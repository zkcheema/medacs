using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medacs.Core.Managers;
using Medacs.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace Medacs.Controllers
{
    public class ReportController : Controller
    {
       [Inject]
		public ReportManager ReportManager { get; set; }
		[Inject]
	   public FeedbackManager FeedbackManager { get; set; }
		// GET: Report
        public ActionResult Index()
        {
            return View();
        }


	    public FileResult GenerateColleagueReport(string id)
	    {
		    byte[] pdfbytes = null;
			if (User.Identity.IsAuthenticated)
		    {
				var user = FeedbackManager.GetUser(Guid.Parse(User.Identity.GetUserId()));

				var totalRespondent = ReportManager.GetRespondentNumber(user.Id, "colleague".ToLower());
				var feedback = FeedbackManager.GetFeedBackByName("Colleague");
				var result = ReportManager.GetQuestionPercentage(feedback, user.Id);

			    pdfbytes = ReportManager.GenerateReport(feedback,result);

			   return File(pdfbytes, "application/pdf", "DownloadName.pdf");
		    }

			return File(pdfbytes, "application/pdf", "DownloadName.pdf");
	    }
    }
}