using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Repositories;
using Ninject;

namespace Medacs.Core.Managers
{
	
	public class RevalidationDetailManager
	{
		[Inject]
		public RevalidationDetailsRepository RevalidationDetailsRepository { get; set; }


		public void Insert(RevalidationDetail revalidationDetail)
		{
			RevalidationDetailsRepository.Insert(revalidationDetail);
		}


		public void RevalidationTimeLineInsert(RevalidationTimeline revalidationTimeline)
		{

			RevalidationDetailsRepository.RevalidationTimeLineInsert(revalidationTimeline);
		}


		public RevalidationDetail GetFeedBackbyHexCode(string code, string hexcode)
		{
			return RevalidationDetailsRepository.GetFeedBackbyHexCode(code, hexcode);
		}
	}
}
