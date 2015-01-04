using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IEmail
	{
		bool SendEmail(string subject, string firstname, string lastname, string email, string html);
	}
}
