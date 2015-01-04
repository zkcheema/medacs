using System;
using System.Web.Mvc;

namespace Medacs.Models.ViewModels
{
	public class SurveyViewModel
	{
		[HiddenInput(DisplayValue = false)]
		public string UrlCode { get; set; }
		public FeedBackViewModel FeedBackViewModel { get; set; }
	}
}