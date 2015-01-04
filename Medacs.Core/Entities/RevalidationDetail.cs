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
		public  Guid FeedBackId { get; set; }
		public  FeedBack FeedBack { get; set; }
		public  Guid FeedBackUserId { get; set;}
		public  FeedBackUser FeedBackUser { get; set; }
		
		public string HexCode { get; set; }
		public int Code { get; set; }
		public bool EmailSent { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		



		
	}
}
