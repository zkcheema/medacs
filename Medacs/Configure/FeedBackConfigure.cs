using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medacs.Areas.Admin.Models.ViewModel;
using Medacs.Core.Entities;
using Microsoft.Ajax.Utilities;

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

		public static List<OptionChoices> OptionChoiceViewModelToOptionChoice(OptionGroupViewModel optionGroupViewModel)
		{

			var optionChoicesList = new List<OptionChoices>();
			foreach (var optionChoiceView in optionGroupViewModel.OptionChoicesViewModel)
			{
				var optionChoices = new OptionChoices();
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
	}
}