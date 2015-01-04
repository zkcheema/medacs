using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace Medacs.Core.Managers
{
	public class EmailManager
	{
		[Inject]
		public IEmail EmailRepository { get; set; }


		public bool SendEmail(string subject,string firstName,string lastName,string email, string html)
		{
			return EmailRepository.SendEmail(subject,firstName, lastName, email, html);
		}
	}
}
