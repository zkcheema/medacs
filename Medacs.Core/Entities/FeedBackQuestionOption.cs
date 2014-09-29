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
		public Question Question { get; set; }
	
		public OptionChoices OptionChoices { get; set; }
	}
}
