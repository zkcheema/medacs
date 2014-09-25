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
		public string QuestionText { get; set; }
		public string QuestionType { get; set; }
		public virtual FeedBack FeedBack { get; set; }

	}
}
