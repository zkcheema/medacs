using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Medacs.Core.Entities
{
	
	public class FeedBackSection
	{
		public Guid Id { get; set; }
		public string SectionName { get; set; }
		public string SectionTitle { get; set; }
		public string SectionSubTitle { get; set; }
		public string SectionSubHeading { get; set; }
		public bool SectionRequired { get; set; }
		public Guid FeedBackId { get; set; }
		public  FeedBack FeedBack { get; set; }
		public  ICollection<Question> Questions { get; set; }
		
		
	}
}
