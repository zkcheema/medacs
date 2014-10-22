using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class OptionChoices
	{
		public Guid Id { get; set; }
		public string OptionChoiceName { get; set; }
		public Guid OptionGroupId { get; set; }
		public OptionGroup OptionGroup { get; set; }

	}
}
