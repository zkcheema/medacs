using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IReporting
	{
		int GetRespondentNumber(Guid userId, string feebackUserType);
		List<FeedbackSectionReport> GetQuestionPercentage(FeedBack feedback, Guid userId);
	}
}
