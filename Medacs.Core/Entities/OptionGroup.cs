using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Medacs.Core.Entities
{
	
	public class OptionGroup
	{
		public Guid Id { get; set; }
		public string OptionGroupName { get; set; }
		public ICollection<OptionChoice> OptionChoice { get; set; }
		public ICollection<Question> Questions { get; set; }
		
	}
}
