using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Medacs.Areas.Admin.Models.ViewModel;
using Medacs.Core.Entities;
using Medacs.Core.Managers;
using Medacs.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin;
using Ninject;
using FeedBackViewModel = Medacs.Areas.Admin.Models.ViewModel.FeedBackViewModel;
using FormCollection = System.Web.Mvc.FormCollection;

namespace Medacs.Configure
{
	public static class FeedBackConfigure
	{
		
		public static FeedBack FeedBackViewModeltoFeedBack(FeedBackViewModel feedBackViewModel)
		{
			var feedBack = new FeedBack();
			feedBack.Description = feedBackViewModel.Description;
			feedBack.Id = feedBackViewModel.Id;
			feedBack.IsOpen = feedBackViewModel.IsOpen;
			feedBack.StartDateTime = Convert.ToDateTime(feedBackViewModel.StartDateTime);
			feedBack.EndDateTime = Convert.ToDateTime(feedBackViewModel.EndDateTime);
			return feedBack;
		}

		public static FeedBackViewModel FeedBacktoFeedBackViewModel(FeedBack feedBack)
		{
			var feedBackViewModel = new FeedBackViewModel();
			feedBackViewModel.Description = feedBack.Description;
			feedBackViewModel.Id = feedBack.Id;
			feedBackViewModel.IsOpen = feedBack.IsOpen;
			feedBackViewModel.StartDateTime = feedBack.StartDateTime.ToString();
			feedBackViewModel.EndDateTime = feedBack.EndDateTime.ToString();
			return feedBackViewModel;
		}



		public static List<FeedBackViewModel> FeedbackListtoFeedBackViewModelsList(List<FeedBack> feedBacksList)
		{
			var feedBackListViewModel = new List<FeedBackViewModel>();

			foreach (var feedBack in feedBacksList)
			{
				var feedBackViewModel = new FeedBackViewModel();

				feedBackViewModel.Description = feedBack.Description;
				feedBackViewModel.Id = feedBack.Id;
				feedBackViewModel.IsOpen = feedBack.IsOpen;
				feedBackViewModel.StartDateTime = feedBack.StartDateTime.ToString();
				feedBackViewModel.EndDateTime = feedBack.EndDateTime.ToString();

				feedBackListViewModel.Add(feedBackViewModel);
			}
			return feedBackListViewModel;
		}


		public static FeedBackSection FeedBackSectionVewModeltoFeedBackSection(FeedBackSectionViewModel feedBackSectionViewModel)
		{
			var feedBackSection = new FeedBackSection();

			feedBackSection.FeedBackId = feedBackSectionViewModel.FeedBackId;
			feedBackSection.Id = feedBackSectionViewModel.Id;
			feedBackSection.SectionName = feedBackSectionViewModel.SectionName;
			feedBackSection.SectionTitle = feedBackSectionViewModel.SectionTitle;
			feedBackSection.SectionSubHeading = feedBackSectionViewModel.SectionSubHeading;
			feedBackSection.SectionSubTitle = feedBackSectionViewModel.SectionSubTitle;
			feedBackSection.SectionRequired = feedBackSectionViewModel.SectionRequired;

			return feedBackSection;
		}


		public static List<FeedBackSectionViewModel> FeedBackSectionListtoFeedBackSectionViewModelList(List<FeedBackSection> feedBackSectionList)
		{

			var feedBackSectionListViewModel = new List<FeedBackSectionViewModel>();
			foreach (var feedBackSection in feedBackSectionList)
			{
				var feedBackSectionViewModel = new FeedBackSectionViewModel();

				feedBackSectionViewModel.FeedBackId = feedBackSection.FeedBackId;
				feedBackSectionViewModel.Id = feedBackSection.Id;
				feedBackSectionViewModel.SectionName = feedBackSection.SectionName;
				feedBackSectionViewModel.SectionTitle = feedBackSection.SectionTitle;
				feedBackSectionViewModel.SectionSubHeading = feedBackSection.SectionSubHeading;
				feedBackSectionViewModel.SectionSubTitle = feedBackSection.SectionSubTitle;
				feedBackSectionViewModel.SectionRequired = feedBackSection.SectionRequired;
				feedBackSectionListViewModel.Add(feedBackSectionViewModel);
				 ;
			}
			return feedBackSectionListViewModel;
		}


		public  static OptionGroup OptionGroupViewModelToOptionGroup(OptionGroupViewModel optionGroupViewModel)
		{
			var optionGroup = new OptionGroup();

			optionGroup.OptionGroupName = optionGroupViewModel.OptionGroupName;

			return optionGroup;
		}

		public static InputType OptionGroupViewModelToInPutTypes(OptionGroupViewModel optionGroupViewModel)
		{
			var inputType = new InputType();
			inputType.InputTypeName = Enum.Parse(typeof(InputTypeName), optionGroupViewModel.InputTypeName).ToString();
			return inputType;
		}

		public static List<OptionChoice> OptionChoiceViewModelToOptionChoice(OptionGroupViewModel optionGroupViewModel)
		{

			var optionChoicesList = new List<OptionChoice>();
			foreach (var optionChoiceView in optionGroupViewModel.OptionChoicesViewModel)
			{
				var optionChoices = new OptionChoice();
				optionChoices.OptionChoiceName = optionChoiceView.OptionChoiceName;
				optionChoices.OptionGroupId = optionGroupViewModel.Id;
				optionChoicesList.Add(optionChoices);
			}
			return optionChoicesList;
		}

		public static Question QuestionViewModeltoQuestion(QuestionViewModel questionViewModel)
		{
			var question = new Question();
			question.FeedBackSectionId = questionViewModel.FeedBackSectionId;
			question.OptionGroupId = questionViewModel.OptionGroupId;
			question.QuestionName = questionViewModel.QuestionName;
			question.QuestionText = questionViewModel.QuestionSubText;
			question.InputTypeId = questionViewModel.InputTypeId;
			question.AnswerRequired = questionViewModel.AnswerRequired;

			return question;

		}

		public static SurveyViewModel FeedBacktoSurveyViewModel(FeedBack feedBack)
		{
			var surveryViewModel = new SurveyViewModel();

			surveryViewModel.FeedBackViewModel= new Models.ViewModels.FeedBackViewModel();

			surveryViewModel.FeedBackViewModel.Description = feedBack.Description;
			surveryViewModel.FeedBackViewModel.EndDateTime = feedBack.EndDateTime;
			surveryViewModel.FeedBackViewModel.Id = feedBack.Id;
			surveryViewModel.FeedBackViewModel.IsOpen = feedBack.IsOpen;
			surveryViewModel.FeedBackViewModel.Instruction = feedBack.Instruction;
			surveryViewModel.FeedBackViewModel.FeedBackSectionViewModel= new List<FeedBackSectionViewModel>();
			foreach (var feedbackSection in feedBack.FeedBackSection)
			{
				var feedBackSectionViewModel = new FeedBackSectionViewModel();
				feedBackSectionViewModel.Id = feedbackSection.Id;
				feedBackSectionViewModel.FeedBackId = feedbackSection.FeedBackId;
				feedBackSectionViewModel.SectionName = feedbackSection.SectionName;
				feedBackSectionViewModel.SectionSubHeading = feedbackSection.SectionSubHeading;
				feedBackSectionViewModel.SectionSubTitle = feedbackSection.SectionSubTitle;
				feedBackSectionViewModel.SectionTitle = feedbackSection.SectionTitle;
				feedBackSectionViewModel.SectionRequired = feedbackSection.SectionRequired;
			
				feedBackSectionViewModel.QuestionsViewModel = new List<QuestionViewModel>();

						foreach (var question in feedbackSection.Questions)
						{
							var questionViewModel = new QuestionViewModel();

							questionViewModel.Id = question.Id;
							questionViewModel.QuestionName = question.QuestionName;
							questionViewModel.FeedBackSectionId = question.FeedBackSectionId;
							questionViewModel.InputTypeId = question.InputTypeId;
							questionViewModel.OptionGroupId = question.OptionGroupId;
						questionViewModel.QuestionSubText = question.QuestionSubText;
						questionViewModel.QuestionText = question.QuestionText;
						questionViewModel.InputViewModel =  new InputTypeViewModel();
						questionViewModel.InputViewModel.Id = question.InputType.Id;
						questionViewModel.InputViewModel.InputTypeName = question.InputType.InputTypeName;
						questionViewModel.OptionGroupViewModel= new OptionGroupViewModel();
						questionViewModel.OptionGroupViewModel.OptionGroupName = question.OptionGroup.OptionGroupName;
						questionViewModel.OptionGroupViewModel.Id = question.OptionGroup.Id;
						questionViewModel.OptionGroupViewModel.InpuTypeId = question.InputType.Id;
							questionViewModel.OptionGroupViewModel.InputTypeName = question.InputType.InputTypeName;
						questionViewModel.OptionGroupViewModel.OptionChoicesViewModel = new List<OptionChoicesViewModel>();
						foreach (var optionchoices in question.OptionGroup.OptionChoice)
						{
							var optionViewModel = new OptionChoicesViewModel();
							
								optionViewModel.Id = optionchoices.Id;
								optionViewModel.OptionChoiceName = optionchoices.OptionChoiceName;
							questionViewModel.OptionGroupViewModel.OptionChoicesViewModel.Add(optionViewModel);
							 
						}
							feedBackSectionViewModel.QuestionsViewModel.Add(questionViewModel);
						
					}
						surveryViewModel.FeedBackViewModel.FeedBackSectionViewModel.Add(feedBackSectionViewModel);

			

			}

			return surveryViewModel;
		}

		public static List<Answer> SurveryViewModeltoAnswer(FormCollection formCollection, Guid feedBackUserId, Guid userId)
		{
			var answers = new List<Answer>();
			foreach (var questionid in formCollection.AllKeys)
			{
				if (questionid != "UrlCode")
				{
						var answer = new Answer();
						answer.FeedBackQuestionOption = new FeedBackQuestionOption();
						answer.FeedBackQuestionOption.Id=Guid.NewGuid();
						answer.FeedBackQuestionOption.QuestionId = Guid.Parse(questionid);
						answer.FeedBackQuestionOption.OptionChoiceId= Guid.Parse(formCollection.Get(questionid));
						answer.AnswerGuid = Guid.Parse(formCollection.Get(questionid));
						answer.UserId = userId;
						answer.FeedBackUserId = feedBackUserId;
						answers.Add(answer);
					

				}

			}

			
			return answers;
		}
	}
}