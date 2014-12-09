using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Medacs.Models
{
	public class UserManager : UserManager<ApplicationUser>
	{
		public UserManager()
			: base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
		{
			UserValidator = new UserValidator<ApplicationUser>(this) { AllowOnlyAlphanumericUserNames = false };
			var provider = new DpapiDataProtectionProvider("Medacs");
			UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, string>(provider.Create("UserToken"))
				as IUserTokenProvider<ApplicationUser, string>;
			EmailService = new EmailService();

			
		}

	}
}