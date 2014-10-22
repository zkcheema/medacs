using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class OptionGroup
	{
		public Guid Id { get; set; }
		public string OptionGroupName { get; set; }
		public  virtual ICollection<OptionChoices> OptionChoices { get; set; }
	}
}
