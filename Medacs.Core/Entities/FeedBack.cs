using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Medacs.Core.Entities
{
	public class FeedBack
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public string Instruction { get; set; }
		public string FeedBackName { get; set; }
		public string OtherInformation { get; set; }
		public bool IsOpen { get; set; }
		public string LatestCode { get; set; }
		public virtual Guid OrganizationId { get; set; }
		public  Organization Organization { get; set; }
		public  ICollection<FeedBackSection> FeedBackSection { get; set; }
		
	}
}
