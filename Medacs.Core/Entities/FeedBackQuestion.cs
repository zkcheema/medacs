using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class FeedBackQuestion
	{
		public Guid Id { get; set; }
		public virtual FeedBack FeedBack { get; set; }
		public virtual Question Question { get; set; }
	}
}
