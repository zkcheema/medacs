using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Medacs.Core.Entities;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class FeedBackSectionViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string SectionName { get; set; }
		[Display(Name = "Title")]
		public string SectionTitle { get; set; }
		[Display(Name = "SubTitle")]
		public string SectionSubTitle { get; set; }
		[Display(Name = "SubHeading")]
		public string SectionSubHeading { get; set; }
		[Display(Name = "SectionRequired")]
		public bool SectionRequired { get; set; }

		public Guid FeedBackId { get; set; }

		public ICollection<QuestionViewModel> QuestionsViewModel { get; set; } 


	}
}