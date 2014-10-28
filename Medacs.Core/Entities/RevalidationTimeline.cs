using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class RevalidationTimeline
	{
		public Guid Id { get; set; }
		public DateTime? StatDateTime { get; set; }
		public DateTime? EndDateTime { get; set; }
	}
}
