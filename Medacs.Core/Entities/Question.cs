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
		public virtual InputType InputType { get; set; }
		public virtual OptionGroup OptionGroup { get; set; }
		public virtual FeedBackSection FeedBackSection { get; set; }
	}
}
