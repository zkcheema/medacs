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
	public class QuestionRepository:IQuestionaires
	{
		[Inject]
		public IMedacsDbContext DbContext { get; set; }

		public void AddQuestions(Question question)
		{
			try
			{
				DbContext.Questions.Add(question);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to Add the Question",ex);
			}
			
		}

		public bool DeleteQuestions(Guid id)
		{
			throw new NotImplementedException();
		}

		public void UpdateQuestions(Question feedBack)
		{
			throw new NotImplementedException();
		}

		public Question GetBack()
		{
			throw new NotImplementedException();
		}

		public Question GetQuestionbyId(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
