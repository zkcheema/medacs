using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medacs.Core.Entities;
using Medacs.Models;
using Medacs.Models.ViewModels;

namespace Medacs.Configure
{
	public static class FeedBackSetupConfigure
	{

		public static FeedBackUser FeedBackUserViewModeltoFeedBackUser(FeedBackUserViewModel feedBackUserViewModel)
		{
			var feedBackUser = new FeedBackUser();
			
			feedBackUser.Email = feedBackUserViewModel.Email;
			feedBackUser.FirstName = feedBackUserViewModel.FirstName;
			feedBackUser.LastName = feedBackUserViewModel.LastName;
			feedBackUser.Profession = feedBackUserViewModel.Profession;
			feedBackUser.FeedBackUserType = feedBackUserViewModel.FeedBackUserType;
			return feedBackUser;
		}

		public static RevalidationDetail FeedBackUserViewModeltoRevalidationDetail(FeedBackUserViewModel feedBackUserViewModel)
		{
			var revalidationDetail = new RevalidationDetail();
			revalidationDetail.FeedBackUserId = feedBackUserViewModel.Id;
			return revalidationDetail;
		}

		public static SurveyLinkEmailViewModel FeedbackViewModeltoSurveyLinkEmailViewModel(FeedBackUserViewModel feedBackViewModel, ApplicationUser user, string url)
		{

			var surveyLinkEmailViewModel = new SurveyLinkEmailViewModel();

			surveyLinkEmailViewModel.FirstName = user.FirstName;
			surveyLinkEmailViewModel.LastName = user.LastName;
			surveyLinkEmailViewModel.FeedBackUserFirstName= feedBackViewModel.FirstName;
			surveyLinkEmailViewModel.FeedBackUserLastName = feedBackViewModel.LastName;
			surveyLinkEmailViewModel.Url = url;
			surveyLinkEmailViewModel.FeedBackUserEmail = feedBackViewModel.Email;
			return surveyLinkEmailViewModel;
		}


		public static List<FeedBackUserViewModel> FeedBackUsertoFeedBackUserViewModel(List<FeedBackUser> feedBackUsers)
		{
			 var feedbackUserviewModelList = new List<FeedBackUserViewModel>();

			foreach (var feedBackUser in feedBackUsers)
			{
				var feedbackUserViewModel = new FeedBackUserViewModel();

				feedbackUserViewModel.Id = feedBackUser.Id;
				feedbackUserViewModel.FirstName = feedBackUser.FirstName;
				feedbackUserViewModel.LastName = feedBackUser.LastName;
				feedbackUserViewModel.Profession = feedBackUser.Profession;
				feedbackUserViewModel.Email = feedBackUser.Email;
				feedbackUserViewModel.FeedBackUserType = feedBackUser.FeedBackUserType;
				feedbackUserViewModel.FeedBackUserGroup= feedBackUser.FeedbackUserGroup;
				feedbackUserviewModelList.Add(feedbackUserViewModel);

			}
			return feedbackUserviewModelList;
		}
	}
}