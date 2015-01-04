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
	[Authorize(Roles = "user,admin")]
	public class SetupController : Controller
    {
		[Inject]
		public EmailManager EmailManager  { get; set; }
		[Inject]
		public SetupManager SetupManager { get; set; }
		[Inject]
		public FeedbackManager FeedbackManager { get; set; }
		[Inject]
		public RevalidationDetailManager RevalidationDetailManager { get; set; }
	
		[HttpGet]
        public ActionResult SetupSurvey(string id)
        {
			if (id.ToLower() == "Colleague".ToLower())
			{
				return View("~/Views/Survey/Configure.cshtml");
			}
			else
			{
				return View("~/Views/Survey/ConfigurePatient.cshtml");

				
			}
			
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
		public JsonResult GetFeedBackUserColleague()
		{
			var userId=SetupManager.GetFeedBackUserid(Guid.Parse(User.Identity.GetUserId()));

			var feedbackList = SetupManager.GetFeedBackUser(userId, "Colleague".ToLower());
			var result = FeedBackSetupConfigure.FeedBackUsertoFeedBackUserViewModel(feedbackList);

			if (result != null)
			{
				return Json(new{result = "Success", feedBackUserList=result}, JsonRequestBehavior.AllowGet);
			}

			return Json(new { result = "failed", feedBackUserList = result }, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetFeedBackUserPatient()
		{
			var userId = SetupManager.GetFeedBackUserid(Guid.Parse(User.Identity.GetUserId()));

			var feedbackList = SetupManager.GetFeedBackUser(userId,"patient".ToLower());
			var result=FeedBackSetupConfigure.FeedBackUsertoFeedBackUserViewModel(feedbackList);


			if (result != null)
			{
				return Json(new { result = "Success", feedBackUserList = result }, JsonRequestBehavior.AllowGet);
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

	    public JsonResult SendEmail(FeedBackUserViewModel feedBackUserViewModel)
	    {
				var manager = new UserManager();
				var user =manager.FindById(User.Identity.GetUserId());
				var feedBackuser=SetupManager.GetFeedBackUserbyId(feedBackUserViewModel.Id);
				// Later on When order Details are available we we will pull the FeedBackId from there 
				// For the moment we are pulling it from config as we now we have only one feedBack.
		    var feedBack = FeedbackManager.GetFeedBackByName(feedBackUserViewModel.FeedBackUserType.ToLower());

				//var colleagueFeedBackId = feedback.Id.ToString();//ConfigurationManager.AppSettings["ColleagueFeedBackId"];

				//var feedBack =FeedbackManager.GetFeedBackById(Guid.Parse(colleagueFeedBackId));
				var revalidationdetail = new RevalidationDetail();
				revalidationdetail.FeedBackUserId = feedBackuser.Id;
				revalidationdetail.FeedBackId = feedBack.Id;
				revalidationdetail.StartDateTime = DateTime.Now;
				revalidationdetail.EndDateTime = DateTime.Now.AddYears(1);
				revalidationdetail.HexCode = SetupManager.GenerateRandomHexCode();
				revalidationdetail.Code =int.Parse(SetupManager.GenerateRandomCode(feedBack.Id));
				var codeAsHex = SetupManager.GenerateLink(revalidationdetail.Code);
				var url = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + "/Survey/ViewFeedBack/" + HttpUtility.UrlEncodeUnicode(codeAsHex) + revalidationdetail.HexCode;
				var surveyLink =FeedBackSetupConfigure.FeedbackViewModeltoSurveyLinkEmailViewModel(feedBackUserViewModel, user,url);

				var emailHtml = Utility.Render(ControllerContext, "~/Views/Mailer/SurveryLinkMail.cshtml", surveyLink);

				var eamilResult = EmailManager.SendEmail("Colleague Survey", feedBackuser.FirstName,feedBackuser.LastName,feedBackuser.Email, emailHtml);

		    if (eamilResult)
		    {
			    revalidationdetail.EmailSent = true;
				
				RevalidationDetailManager.Insert(revalidationdetail);
			    return Json(new {result = "Success"}, JsonRequestBehavior.AllowGet);
		    }

			return Json(new { result = "failed" }, JsonRequestBehavior.AllowGet);




	    }


    }
}