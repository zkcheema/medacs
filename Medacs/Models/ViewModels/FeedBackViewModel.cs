using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medacs.Models.ViewModels
{
	public class FeedBackViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string Description { get; set; }
		public string StartDateTime { get; set; }
		public string EndDateTime { get; set; }
		public bool IsOpen { get; set; }



	}
}