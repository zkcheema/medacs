using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medacs.Areas.Admin.Models.ViewModel
{
	public class OptionGroupViewModel
	{
		public Guid Id { get; set; }
		public string OptionGroupName { get; set; }
		public Guid InpuTypeId{get; set;}
		public string InputTypeName { get; set; }
		public List<OptionChoicesViewModel> OptionChoicesViewModel { get; set; }
		
	}

	public class OptionChoicesViewModel
	{
		public Guid Id { get; set; }
		public string OptionChoiceName { get; set; }
		
	}
}