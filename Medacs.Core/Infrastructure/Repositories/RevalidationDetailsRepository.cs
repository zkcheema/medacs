using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.DataContext;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Infrastructure.Repositories
{
	public class RevalidationDetailsRepository : IRevalidationDetailcs
	{

		[Inject]
		public IMedacsDbContext DbContext { get; set; }

		public void Insert(RevalidationDetail revalidationDetails)
		{
			try
			{
				DbContext.RevalidationDetails.Add(revalidationDetails);
				DbContext.SaveChanges();

			}
			catch (Exception exception)
			{
				throw new Exception("Unable to Add Revalidation Details", exception);

			}


		}

		public void RevalidationTimeLineInsert(RevalidationTimeline revalidationTimeline)
		{
			try
			{
				DbContext.RevalidationTimelines.Add(revalidationTimeline);
				DbContext.SaveChanges();
			}
			catch (Exception exception)
			{
				throw new Exception("Unable to Add Revalidation Details", exception);


			}
		}

		public RevalidationDetail GetFeedBackbyHexCode(string code, string hexcode)
		{
			var intcode=Convert.ToInt32(code);

			var revalidationDetail =(from rvd in DbContext.RevalidationDetails.Include(a=>a.FeedBackUser).Include(u=>u.FeedBackUser.User)
					where rvd.HexCode.Equals(hexcode) &&
					rvd.Code.Equals(intcode)
					   select rvd).FirstOrDefault();

			return  revalidationDetail;

		}
	}
}
