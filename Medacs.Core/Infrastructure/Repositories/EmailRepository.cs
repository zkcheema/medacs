using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;

namespace Medacs.Core.Infrastructure.Repositories
{
	public class EmailRepository:IEmail
	{
		public bool SendEmail(string subject, string firstname, string lastname, string email,  string html)
		{
			var emailmessage = new Mandrill.EmailMessage
			{
				
				subject = subject,
				html = html,
								
			};

			emailmessage.from_email = ConfigurationManager.AppSettings["FromEmail"];
			emailmessage.from_name = ConfigurationManager.AppSettings["FromName"];
			var address = new List<EmailAddress>();
			
			address.Add(new EmailAddress()
			{
				email = email,
				name = firstname + " " + lastname,
			});
			


			try
			{
				emailmessage.to = address;

				var mandrill = new MandrillApi(ConfigurationManager.AppSettings["EmailAPIKey"], false);
				var results = mandrill.SendMessage(emailmessage);
				foreach (var emailResult in results)
				{
					if (emailResult.Status != Mandrill.EmailResultStatus.Sent)
					{
					
						//LogManager.Current.LogError(emailResult.Email, "", "", "", null,
						//string.Format("Email failed to send: {0}", emailResult.RejectReason));
					}
					return true;
				}

			}
		catch (Exception exception)
			{
			
				throw new Exception("Unable to Send Email",exception);
			}
			return false;
		}
	}
}
