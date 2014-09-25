using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IFeedBack
	{
		void AddFeedBack(FeedBack feedBack);
		bool DeleteFeedBack(Guid id);
		void UpdateFeedBack(FeedBack feedBack);
		FeedBack GetBack();
		FeedBack GetFeedBackbyId(Guid id);
	}
}
