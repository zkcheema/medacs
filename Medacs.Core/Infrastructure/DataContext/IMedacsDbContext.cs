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
		IDbSet<FeedBackHeader> FeedBackHeaders { get; }
		 IDbSet<FeedBackSection> FeedBackSections{ get;}
		 IDbSet<InputType> InputTypes{ get;}
		 IDbSet<OptionChoices> OptionChoices{ get;}
		 IDbSet<OptionGroup> OptionGroups{ get;}
		 IDbSet<Organization> Organizations{ get;}
		 IDbSet<FeedBackQuestionOption> FeedBackQuestionOptions { get; }
		IDbSet<Answer> Answers { get; }
		IDbSet<Question> Questions { get; }
		 IDbSet<User> Users { get; }
		 Database Database { get; }
		 int SaveChanges();
		
	}
}
