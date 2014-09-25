using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.DataContext
{
	public class MedacsDbContext : DbContext , IMedacsDbContext
	{
		public MedacsDbContext() : base("name=medacs")
        { }
        public MedacsDbContext(string databaseName) : base(databaseName)
        { }

		public IDbSet<FeedBack> FeedBacks { get; set; }
		public IDbSet<FeedBackQuestion> FeedBackQuestions { get; set; }
		public IDbSet<FeedBackQuestionAnswer> FeedBackQuestionAnswers { get; set; }
		public IDbSet<OfferedAnswer> OfferedAnswers { get; set; }
		public IDbSet<Question> Questions { get; set; }
		public IDbSet<User> Users { get; set; }



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FeedBack>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<FeedBackQuestion>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<FeedBackQuestionAnswer>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<OfferedAnswer>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Question>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<User>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


		}


	}
}
