﻿using System;
using System.Collections.Generic;
using System.Linq;
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
		public virtual Organization Organization { get; set; }
		public virtual ICollection<FeedBackSection> FeedBackSection { get; set; }
		
	}
}
