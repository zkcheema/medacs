using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class EditViewModel
	{
		 public Guid FeedBackId { get; set; }
		public FeedBackSectionViewModel FeedBackSectionViewModel { get; set; }

	}
}