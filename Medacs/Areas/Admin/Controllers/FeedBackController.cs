using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Medacs.Areas.Admin.Models;
using Medacs.Areas.Admin.Models.ViewModel;
using Medacs.Configure;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Medacs.Core.Managers;
using Microsoft.Ajax.Utilities;
using Ninject;

namespace Medacs.Areas.Admin.Controllers
{
	public class FeedBackController : Controller
	{
		[Inject]
		public FeedbackManager FeedbackManager { get; set; }

		//
		// GET: /Admin/FeedBack/
		[HttpGet]
		public ActionResult CreateFeedBack()
		{
			return View("Create");
		}

		[HttpPost]
		public ActionResult CreateFeedBack(FeedBackViewModel feedBackViewModel)
		{
			var feedBack = FeedBackConfigure.FeedBackViewModeltoFeedBack(feedBackViewModel);

			FeedbackManager.AddFeedBackRepository(feedBack);


			return View("Create");
		}


		public JsonResult EditFeedBack(FeedBackViewModel feedBackViewModel)
		{

			var feedback = FeedBackConfigure.FeedBackViewModeltoFeedBack(feedBackViewModel);
			FeedbackManager.UpdateFeedBack(feedback);

			return Json( JsonRequestBehavior.AllowGet); ;
		}

		[HttpGet]
		public ActionResult Edit(Guid id)
		{
			var questionViewModel = new EditViewModel();
			questionViewModel.FeedBackSectionViewModel = new FeedBackSectionViewModel();
			questionViewModel.FeedBackSectionViewModel.FeedBackId = id;

			return View("Edit", questionViewModel);
		}

		[HttpGet]
		public ActionResult List()
		{
			var feebackList = FeedbackManager.GetFeedBacks();
			var feebackViewList = FeedBackConfigure.FeedbackListtoFeedBackViewModelsList(feebackList);
			return View(feebackViewList);
		}

		[HttpGet]
		public JsonResult GetFeedBacks()
		{
			var feebackList = FeedbackManager.GetFeedBacks();
			var feebackViewList = FeedBackConfigure.FeedbackListtoFeedBackViewModelsList(feebackList);
			return Json(new {feebackViewList}, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AddFeedBackSection(FeedBackSectionViewModel feedBackSectionViewModel)
		{
			var feedBackSection = FeedBackConfigure.FeedBackSectionVewModeltoFeedBackSection(feedBackSectionViewModel);
			FeedbackManager.AddFeedBackSection(feedBackSection);
			return Json(new object {}, JsonRequestBehavior.AllowGet);;
		}

		public JsonResult GetFeedBackSections(Guid id)
		{
			var feedbackSection = FeedbackManager.GetFeedBackSections(id);
			var feebackSection = FeedBackConfigure.FeedBackSectionListtoFeedBackSectionViewModelList(feedbackSection);
			return Json(new {feebackSection}, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult AddQuestion(Guid id)
		{
			var questionViewModel = new QuestionViewModel();
			questionViewModel.FeedBackSectionId = id;
			return View("AddQuestion", questionViewModel);
		}
		
		public JsonResult CreateQuestion(QuestionViewModel questionViewModel)
		{
			var question = FeedBackConfigure.QuestionViewModeltoQuestion(questionViewModel);
			FeedbackManager.AddQuestion(question);
			
			return Json(new object {}, JsonRequestBehavior.AllowGet);
			}

		public JsonResult AddOptionGroup(OptionGroupViewModel optionGroupViewModel)
		{
			var optionGroup = FeedBackConfigure.OptionGroupViewModelToOptionGroup(optionGroupViewModel);
			var optiongroupId = FeedbackManager.AddOptionGroup(optionGroup);
			optionGroupViewModel.Id = optiongroupId;
			var optionChoicesList = FeedBackConfigure.OptionChoiceViewModelToOptionChoice(optionGroupViewModel);
			var inputTypes = FeedBackConfigure.OptionGroupViewModelToInPutTypes(optionGroupViewModel);
			FeedbackManager.AddInputTypes(inputTypes);
			FeedbackManager.AddOptionChoices(optionChoicesList);
			return Json(new {OptionGroupViewModel = optionGroupViewModel}, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult GetOptionGroup()
		{
			var optionGroupList = FeedbackManager.GetOptionGroup();
			return Json(new { OptionGroupList = optionGroupList.ToList() }, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult GetInputTypes()
		{
			var inputTypesList = FeedbackManager.GetInputTypes();
			return Json(new { InputTypesList = inputTypesList.ToList()}, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult GetQuestionBySection(Guid id)
		{
			var listofQuestion = FeedbackManager.GetQuestionbySection(id);

			return Json(new { listofQuestion = listofQuestion.ToList() }, JsonRequestBehavior.AllowGet);
		}

	}
}