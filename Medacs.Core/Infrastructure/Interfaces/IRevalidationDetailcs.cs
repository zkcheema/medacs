using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public  interface IRevalidationDetailcs
	{
		void Insert(RevalidationDetail revalidationDetails);
		void RevalidationTimeLineInsert(RevalidationTimeline revalidationTimeline);
	}
}
