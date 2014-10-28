using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Medacs.Core.Entities
{
	public class User 

	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public DateTime LastLoginDateTime { get; set; }
		public DateTime InviteDateTime { get; set; }
		public FeedBack FeedBack { get; set; }
	
	}
}
