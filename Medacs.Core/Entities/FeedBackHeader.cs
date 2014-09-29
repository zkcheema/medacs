using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class FeedBackHeader
	{
		public Guid Id { get; set; }
		public string FeedBackName { get; set; }
		public string Instruction { get; set; }
		public string OtherInformation { get; set; }
		public FeedBack FeedBack { get; set; }
		

	}
}
