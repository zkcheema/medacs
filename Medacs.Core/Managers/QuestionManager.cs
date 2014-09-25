using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Managers
{
	public class QuestionManager
	{
		[Inject]
		public IQuestionaires QuesitonRepository { get; set; }

		public void AddQuestion(Question question)
		{
			QuesitonRepository.AddQuestions(question);
		}


	}
}
