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
	public class RevalidationDetailsRepository :IRevalidationDetailcs
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
				throw  new Exception("Unable to Add Revalidation Details", exception );
				
				
			}


		}
	}
}
