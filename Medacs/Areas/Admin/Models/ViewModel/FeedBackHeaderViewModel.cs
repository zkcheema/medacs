using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medacs.Areas.Admin.Models
{
	public class FeedBackHeaderViewModel
	{
		public Guid Id { get; set; }
		public string FeedBackName { get; set; }
		public string Instruction { get; set; }
		public string OtherInformation { get; set; }
	}
}