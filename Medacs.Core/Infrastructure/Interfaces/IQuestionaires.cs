using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IQuestionaires
	{
		void AddQuestions(Question feedBack);
		bool DeleteQuestions(Guid id);
		void UpdateQuestions(Question feedBack);
		Question GetBack();
		Question GetQuestionbyId(Guid id);
	}
}
