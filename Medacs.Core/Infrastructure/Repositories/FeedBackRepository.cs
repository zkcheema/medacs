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
	public class FeedBackRepository :IFeedBack
	{
		[Inject]
		public IMedacsDbContext DbContext { get; set; }
		public void AddFeedBack(FeedBack feedBack)
		{
			try
			{
				DbContext.FeedBacks.Add(feedBack);
				DbContext.SaveChanges();
				}
			catch (Exception exception)
			{
				throw new Exception("Unable to add Feedback entity", exception);
			}
		}

		public bool DeleteFeedBack(Guid id)
		{
			throw new NotImplementedException();
		}

		public void UpdateFeedBack(FeedBack feedBack)
		{
			throw new NotImplementedException();
		}

		public FeedBack GetBack()
		{
			throw new NotImplementedException();
		}

		public FeedBack GetFeedBackbyId(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
