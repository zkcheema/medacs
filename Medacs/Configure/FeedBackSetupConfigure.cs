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
	}
}