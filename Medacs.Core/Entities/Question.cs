using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class Question
	{
		public Guid Id { get; set; }
		public string QuestionName { get; set; }
		public string QuestionText { get; set; }
		public string QuestionSubText { get; set; }
		public bool AnswerRequired { get; set; }
		public Guid InputTypeId { get; set; }
		public  InputType InputType { get; set; }
		public   Guid OptionGroupId{get; set; }
		public  OptionGroup OptionGroup { get; set; }
		public Guid FeedBackSectionId { get; set; }
		public  FeedBackSection FeedBackSection { get; set; }
		public ICollection<FeedBackQuestionOption> FeedBackQuestionOptions { get; set; }
	}
}
