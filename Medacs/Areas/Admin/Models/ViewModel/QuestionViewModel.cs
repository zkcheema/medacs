using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class QuestionViewModel
	{
		public Guid Id { get; set; }
		public string QuestionName { get; set; }
		public string QuestionText { get; set; }
		public string QuestionSubText { get; set; }
		public bool AnswerRequired { get; set; }
		
		public Guid InputTypeId { get; set; }
		public Guid OptionGroupId{get; set; }
		public Guid FeedBackSectionId { get; set; }
		

	}
}