using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class Answer
	{
		public Guid Id { get; set; }
		public FeedBackQuestionOption FeedBackQuestionOption { get; set; }
		public int AnswerNumeric { get; set; }
		public string AnswerText { get; set; }
		public bool AnsweryesNo { get; set; }
	}
}
