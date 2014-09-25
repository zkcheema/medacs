using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.DataContext
{
	public interface IMedacsDbContext
	{
	
	    	IDbSet<FeedBack> FeedBacks { get; }
		 IDbSet<FeedBackQuestion> FeedBackQuestions { get;}
		 IDbSet<FeedBackQuestionAnswer> FeedBackQuestionAnswers { get;}
		IDbSet<OfferedAnswer> OfferedAnswers { get; }
		IDbSet<Question> Questions { get; }
		 IDbSet<User> Users { get; }
		 Database Database { get; }
		 int SaveChanges();
		
	}
}
