using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class Answer
	{
		public Guid Id { get; set; }
		
		public Guid FeedBackQuestionOptionId { get; set; }
		public FeedBackQuestionOption FeedBackQuestionOption { get; set; }
		public int AnswerNumeric { get; set; }
		public Guid AnswerGuid { get; set; }
		public string AnswerText { get; set; }
		public bool AnsweryesNo { get; set; }
		
		public Guid FeedBackUserId { get; set; }
		public FeedBackUser FeedBackUser { get; set; }
		public Guid UserId { get;set; }
		
	}
}
