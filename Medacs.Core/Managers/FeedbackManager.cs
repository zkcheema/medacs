using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Managers
{
	public class FeedbackManager
	{
		[Inject]
		public IFeedBack FeedBackRepository { get; set; }

		public void AddFeedBackRepository(FeedBack feedBack)
		{
			FeedBackRepository.AddFeedBack(feedBack);
		}
	}
}
