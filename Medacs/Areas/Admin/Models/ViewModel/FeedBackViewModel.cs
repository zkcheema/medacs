using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class FeedBackViewModel
	{

		public Guid Id { get; set; }
		public string Description { get; set; }
		public string StartDateTime { get; set; }
		public string EndDateTime { get; set; }
		public bool IsOpen { get; set; }


	}
}