using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Medacs.Configure;
using Medacs.Core.Entities;
using Medacs.Core.Managers;
using Medacs.Models;
using Medacs.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Ninject;

namespace Medacs.Controllers
{
    public class SetupController : Controller
    {
		[Inject]
		public EmailManager EmailManager  { get; set; }
		[Inject]
		public SetupManager SetupManager { get; set; }
		// GET: Setup
		[Inject]
		public RevalidationDetailManager RevalidationDetailManager { get; set; }
	
		[HttpGet]
        public ActionResult SetupSurvey()
        {

            return View("~/Views/Survey/Configure.cshtml");
        }
		
		
		[HttpPost]
		public JsonResult SetupUser(FeedBackUserViewModel feedBackUserViewModel)
		{
			var feedBackuser= FeedBackSetupConfigure.FeedBackUserViewModeltoFeedBackUser(feedBackUserViewModel);
			feedBackuser.UserId = SetupManager.GetFeedBackUserid(Guid.Parse(User.Identity.GetUserId()));
			SetupManager.InsertFeedBackUser(feedBackuser);
			return Json(new { result = "Success"}, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult GetFeedBackUser()
		{
			var userId=SetupManager.GetFeedBackUserid(Guid.Parse(User.Identity.GetUserId()));

			 var result = SetupManager.GetFeedBackUser(userId);

			if (result != null)
			{
				return Json(new{result = "Success", feedBackUserList=result}, JsonRequestBehavior.AllowGet);
			}

			return Json(new { result = "failed", feedBackUserList = result }, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
	    public JsonResult CheckEmailExist(string email)
	    {

		    var result = SetupManager.CheckEmailExist(email,  SetupManager.GetFeedBackUserid(Guid.Parse(User.Identity.GetUserId())));
		    if (result)
		    {
				return Json(new { result = "Success" }, JsonRequestBehavior.AllowGet);
		    }

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);
		}

	    [HttpGet]
	    public JsonResult CheckUpdateEmail(string email)
	    {

			var result =SetupManager.UpdateEmail(email,Guid.Parse(User.Identity.GetUserId()));

			if (result)
			{
				return Json(new { result = "Success" }, JsonRequestBehavior.AllowGet);
			}

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);


	    }
		[HttpDelete]
		
		public JsonResult DeleteFeedBackUser(Guid id )
		{
			
		   var result = SetupManager.DeleteFeedBackUser(id);
		   
				if (result)
				{
					return Json(new { result = "Success" }, JsonRequestBehavior.AllowGet);
				}

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);
		}

	    [HttpPut]
	    public JsonResult UpdateFeedBackUser(Guid id, FeedBackUserViewModel feedBackUserViewModel)
	    {
			var feedBackuser = FeedBackSetupConfigure.FeedBackUserViewModeltoFeedBackUser(feedBackUserViewModel);

			var result = SetupManager.UpdateFeeBackUser(id, feedBackuser);
			if (result)
			{
				return Json(new { result = "Success" }, JsonRequestBehavior.AllowGet);
			}

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);
		}

	    public JsonResult SendEmail(FeedBackUserViewModel feddBackUserViewModel)
	    {
				var manager = new UserManager();
				var user =manager.FindById(User.Identity.GetUserId());
				var feedBackuser=SetupManager.GetFeedBackUserbyId(feddBackUserViewModel.Id);
				// Later on When order Details are available we we will pull the FeedBackId from there 
				// For the moment we are pulling it from config as we now we have only one feedBack.
				var colleagueFeedBackId = ConfigurationManager.AppSettings["ColleagueFeedBackId"];
				var revalidationdetail = new RevalidationDetail();
				revalidationdetail.FeedBackUserId = feedBackuser.Id;
				revalidationdetail.HexCode = SetupManager.GenerateRandomHexCode();
				revalidationdetail.Code =int.Parse(SetupManager.GenerateRandomCode(Guid.Parse(colleagueFeedBackId)));
				var codeAsHex = SetupManager.GenerateLink(revalidationdetail.Code);
				var url = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + "/Survey/ViewFeedBack/" + HttpUtility.UrlEncodeUnicode(codeAsHex) + revalidationdetail.HexCode;
				var surveyLink =FeedBackSetupConfigure.FeedbackViewModeltoSurveyLinkEmailViewModel(feddBackUserViewModel, user,url);

				var emailHtml = Utility.Render(ControllerContext, "~/Views/Mailer/SurveryLinkMail.cshtml", surveyLink);

				var eamilResult = EmailManager.SendEmail("Colleague Survey", feedBackuser, emailHtml);

		    if (eamilResult)
		    {
			   // revalidationdetail.EmailSent = true;
				RevalidationDetailManager.Insert(revalidationdetail);
			    return Json(new {result = "Success"}, JsonRequestBehavior.AllowGet);
		    }

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);




	    }


    }
}