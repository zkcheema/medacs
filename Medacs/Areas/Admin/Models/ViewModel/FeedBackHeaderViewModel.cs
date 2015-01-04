using System;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class FeedBackHeaderViewModel
	{
		public Guid Id { get; set; }
		public string FeedBackName { get; set; }
		public string Instruction { get; set; }
		public string OtherInformation { get; set; }
	}
}