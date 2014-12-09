using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IFeedBackUser
	{
		void Insert(FeedBackUser feedBackUser);
		void AddFeedBackUser(FeedBackUser feedbackuser);
		bool Delete(Guid id);
		Guid GetFeedBackUserid(Guid id);
		List<FeedBackUser> GetFeedBackUser(Guid userId);
		bool UpdateFeedBackUser(Guid id, FeedBackUser user);
		FeedBackUser GetFeedBackUserbyId(Guid Id);

		bool CheckEmailExist(string email, Guid id);
		bool UpdateEmail(string email, Guid id);
		string GenerateRandomHexCode();
	}
}

