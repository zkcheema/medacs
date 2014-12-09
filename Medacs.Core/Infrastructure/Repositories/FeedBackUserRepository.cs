using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.DataContext;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Infrastructure.Repositories
{
	public class FeedBackUserRepository:IFeedBackUser
	{

		[Inject]
		public IMedacsDbContext DbContext { get; set; }
		public void Insert(Entities.FeedBackUser feedBackUser)
		{
			try
			{
				DbContext.FeedBackUsers.Add(feedBackUser);
				DbContext.SaveChanges();
			}
			catch (Exception exception)
			{

				throw new Exception("Unable to add FeedbackUser entity", exception);
			}
			

		}

		public void AddFeedBackUser(FeedBackUser feedbackuser)
		{
			DbContext.FeedBackUsers.Add(feedbackuser);
			DbContext.SaveChanges();

		}


		public void UpdateFeedBackUser(FeedBackUser feedBackUser)
		{
			try
			{
				var existingUser = DbContext.FeedBackUsers.Select(fu => fu).FirstOrDefault(a => a.Id.Equals(feedBackUser.Id));

				
				if (existingUser != null)
				{
					existingUser.FirstName = feedBackUser.FirstName;
					existingUser.LastName = feedBackUser.LastName;
					existingUser.Email = feedBackUser.Email;
					existingUser.Profession = feedBackUser.Profession;
					DbContext.SaveChanges();
					return;
				}


			}
			catch (Exception exception)
			{
				
				throw new Exception("Unable to Upate FeedBackUser",exception);
			}
			

		}

		public bool Delete(Guid id)
		{
			try
			{
				var user = DbContext.FeedBackUsers.Select(fu => fu).FirstOrDefault(a => a.Id.Equals(id));
				DbContext.FeedBackUsers.Remove(user);
				DbContext.SaveChanges();

			return true;	

			}
			catch (Exception exception)
			{
			
				throw new Exception("Unable to Upate FeedBackUser", exception);

		}
			
		
	}

		public Guid GetFeedBackUserid(Guid id)
		{
			return DbContext.Users.Where(a => a.UserInfoId.Equals(id)).FirstOrDefault().Id;

		}


	public List<FeedBackUser> GetFeedBackUser(Guid userId)
		{
			return DbContext.FeedBackUsers.Select(a => a).Where(b => b.UserId.Equals(userId)).ToList();
		}

		public bool UpdateFeedBackUser(Guid id, FeedBackUser user)
		{
			try
			{
				var existinguser = DbContext.FeedBackUsers.Select(a => a).FirstOrDefault(b => b.Id.Equals(id));
				if (existinguser != null)
				{
					existinguser.Email = user.Email;
					existinguser.LastName = user.LastName;
					existinguser.FirstName = user.FirstName;
					existinguser.Profession = user.Profession;
					existinguser.PersonalizedMessage = user.PersonalizedMessage;
					existinguser.FeedbackUserGroup = user.FeedbackUserGroup;
					DbContext.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception exception)
			{
				
				throw  new Exception("Unable to Update FeedBack USer", exception);
			}
			
			
		}

		public bool CheckEmailExist(string email, Guid id)
		{
			var feebackuser = DbContext.FeedBackUsers.Select(a => a).Where(u => u.Email.Equals(email)).Where(c => c.UserId.Equals(id)).ToList();
			if (feebackuser.Count > 0)
			{ return false; }

			return true;
		}

		public bool UpdateEmail(string email, Guid id)
		{
			var feebackuser =DbContext.FeedBackUsers.Select(a => a).Where(u => u.Email.Equals(email)).FirstOrDefault(c => c.UserId.Equals(id));

			if (!feebackuser.Email.Equals(email))
			{
				return false;
			}
			return true;
		}

		public string GenerateRandomHexCode()
		{
			var requireCheck = true;
			var hexCode = "";
			var random = new Random();
			while (requireCheck)
			{
				//Generate a random hex code for the document
				var randomNumber = random.Next(100000, Int32.MaxValue);
				hexCode = randomNumber.ToString("X").PadLeft(8, '0');

				//Does this hex code already exist
				requireCheck = DbContext.RevalidationDetails.Any(a => a.HexCode == hexCode);
			}

			return hexCode;
		}




		public FeedBackUser GetFeedBackUserbyId(Guid Id)
		{
			return DbContext.FeedBackUsers.Select(a => a).FirstOrDefault(s => s.Id.Equals(Id));
		}
	}
}
