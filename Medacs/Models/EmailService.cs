using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Medacs.Models
{
	public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var email = new MailMessage("wah032@googlemail.com", message.Destination);
 
            email.Subject = message.Subject;
 
            email.Body = message.Body;
 
            email.IsBodyHtml = true;
 
            var mailClient = new SmtpClient("smtp.live.com", 587) { Credentials = new NetworkCredential("waqashasan658@hotmail.com", "lxn9172"), EnableSsl = true };
 
            return mailClient.SendMailAsync(email);
        }
    }

}