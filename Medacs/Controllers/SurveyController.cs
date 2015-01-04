using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;
using Medacs.Configure;
using Medacs.Core.Managers;
using Medacs.Models.ViewModels;
using Newtonsoft.Json;
using Ninject;

namespace Medacs.Controllers
{
    public class SurveyController : Controller
    {

		[Inject]
		public FeedbackManager FeedbackManager { get; set; }
		[Inject]
		public RevalidationDetailManager RevalidationDetailManager { get; set; }
		[Inject]
		public QuestionManager QuestionManager { get; set; }
		//
        // GET: /FeedBack/
		[HttpGet]
		public ActionResult ViewFeedBack(string encryptedUrl)
		{

			var rawUrl = Request.ServerVariables["UNENCODED_URL"];
			string code;
			string hexcode;
			var surveyviewModel = new SurveyViewModel();
			//Redeem is at the start of this url - remove it using index values
			encryptedUrl = rawUrl.Remove(0, 21);

			//If someone has placed a querystring on this URL it needs to be removed.
			var indexOfQueryString = encryptedUrl.IndexOf('?');
			if (indexOfQueryString != -1)
			{
				encryptedUrl = encryptedUrl.Remove(indexOfQueryString, encryptedUrl.Length - indexOfQueryString);
			}
			if (encryptedUrl.Length == 15)
			{
				var invertedCode = encryptedUrl.Substring(0, 7);
				hexcode = encryptedUrl.Substring(7, 8);

				var charArray = invertedCode.ToCharArray();
				Array.Reverse(charArray);
				var codeAsHex = new string(charArray);
				//The URL may have been tampered with so try and parse it into a integer
				int parsedCode;
				if (Int32.TryParse(codeAsHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out parsedCode))
				{
					code = parsedCode.ToString(CultureInfo.InvariantCulture);
					var revalidationDetail = RevalidationDetailManager.GetFeedBackbyHexCode(code, hexcode);
					var feedback = FeedbackManager.GetFeedBackById(revalidationDetail.FeedBackId);
					 surveyviewModel = FeedBackConfigure.FeedBacktoSurveyViewModel(feedback);
					 surveyviewModel.UrlCode = encryptedUrl;
					if (feedback.FeedBackName.ToLower().Equals("Colleague".ToLower()))
					{
						return View("FeedBackView", surveyviewModel);
					}

					if (feedback.FeedBackName.ToLower().Equals("Patient".ToLower()))
					{
						return View("FeedBackViewPatient", surveyviewModel);
					}
				}
				else
				{
					return View("Error");
				}
			}
			return View("Error");
        }


	    [HttpPost]
	    public ActionResult PostForm(FormCollection formCollection)
	    {


			var encryptedUrl = formCollection["UrlCode"];
		    string code;
		    string hexcode;
		    //Redeem is at the start of this url - remove it using index values
		   
		    //If someone has placed a querystring on this URL it needs to be removed.
		    var indexOfQueryString = encryptedUrl.IndexOf('?');
		    if (indexOfQueryString != -1)
		    {
			    encryptedUrl = encryptedUrl.Remove(indexOfQueryString, encryptedUrl.Length - indexOfQueryString);
		    }
		    if (encryptedUrl.Length == 15)
		    {
			    var invertedCode = encryptedUrl.Substring(0, 7);
			    hexcode = encryptedUrl.Substring(7, 8);

			    var charArray = invertedCode.ToCharArray();
			    Array.Reverse(charArray);
			    var codeAsHex = new string(charArray);
			    //The URL may have been tampered with so try and parse it into a integer
			    int parsedCode;
			    if (Int32.TryParse(codeAsHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out parsedCode))
			    {
				    code = parsedCode.ToString(CultureInfo.InvariantCulture);
				    var revalidationDetail = RevalidationDetailManager.GetFeedBackbyHexCode(code, hexcode);

				    var answer = FeedBackConfigure.SurveryViewModeltoAnswer(formCollection, revalidationDetail.FeedBackUserId, revalidationDetail.FeedBackUser.UserId);
					FeedbackManager.InsertAnswer(answer);
					return View("Submit");
				   
			    }
				
			    return View("Error");


		    }
			return View("Error");
	    }

	    [HttpGet]
		public JsonResult ShowFeedBack(string id)
		{
			//var feedbackId = Guid.Parse("4FEE0E81-ED4A-E411-ADD7-001999EF2DC2");
			var feedback = FeedbackManager.GetFeedBackById(Guid.Parse(id));
			var rating1 = feedback.FeedBackSection.Where(b => b.SectionName.Equals("Rating1")).Select(a => a).ToList().SelectMany(feedbak => feedbak.Questions);

					
			 var ratings1= JsonConvert.SerializeObject(rating1);

			 return Json(new {result="Success", ratings1 = ratings1 }, JsonRequestBehavior.AllowGet);
		}

	}
}