using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class FeedBackQuestionOption
	{
		public Guid Id { get; set; }
		public  Guid QuestionId { get; set; }
		public  Question Question { get; set; }
		public  Guid OptionChoiceId { get; set; }
		public   OptionChoice OptionChoice { get; set; }

	}
}
