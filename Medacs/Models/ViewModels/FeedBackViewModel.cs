using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Medacs.Areas.Admin.Models.ViewModel;
using Medacs.Core.Entities;

namespace Medacs.Models.ViewModels
{
	public class FeedBackViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string Description { get; set; }
		public string StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public string Instruction { get; set; }
		public bool IsOpen { get; set; }
		public List<FeedBackSectionViewModel> FeedBackSectionViewModel { get; set; }


	}
}