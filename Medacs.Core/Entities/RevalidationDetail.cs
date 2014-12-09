using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class RevalidationDetail
	{
		public Guid Id { get; set; }
		public virtual Guid FeedBackId { get; set; }
		public virtual FeedBack FeedBack { get; set; }
		public virtual Guid FeedBackUserId { get; set;}
		public virtual FeedBackUser FeedBackUser { get; set; }
		public virtual RevalidationTimeline RevalidationTimeline { get; set; }
		public virtual Guid RevalidationTimeLineId { get; set; }
		public string HexCode { get; set; }
		public int Code { get; set; }
		public bool EmailSent { get; set; }
		



		
	}
}
