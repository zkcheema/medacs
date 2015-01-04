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
		public IDbSet<FeedBackSection> FeedBackSections { get; set; }
		public IDbSet<InputType> InputTypes { get; set; }
		public IDbSet<OptionChoice> OptionChoices { get; set; }
		public IDbSet<OptionGroup> OptionGroups { get; set; }
		public IDbSet<Organization> Organizations { get; private set; }
		public IDbSet<FeedBackQuestionOption> FeedBackQuestionOptions { get; set; }
		public IDbSet<Answer> Answers { get; set; }
		public IDbSet<Question> Questions { get; set; }
		public IDbSet<User> Users { get;  set; }
		public IDbSet<RevalidationTimeline> RevalidationTimelines { get; set; }
		public IDbSet<FeedBackUser> FeedBackUsers { get; set; }
		public IDbSet<RevalidationDetail> RevalidationDetails { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FeedBack>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<FeedBackSection>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<InputType>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<OptionChoice>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<OptionGroup>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			
			modelBuilder.Entity<Question>().HasKey(q => q.Id);
			modelBuilder.Entity<OptionChoice>().HasKey(oc => oc.Id);
			
			modelBuilder.Entity<FeedBackQuestionOption>()
				.HasRequired(t => t.Question)
				.WithMany(t => t.FeedBackQuestionOptions)
				.HasForeignKey(t => t.QuestionId).WillCascadeOnDelete(false);

			modelBuilder.Entity<FeedBackQuestionOption>()
				.HasRequired(t => t.OptionChoice)
				.WithMany(t => t.FeedBackQuestionOptions)
				.HasForeignKey(t => t.OptionChoiceId).WillCascadeOnDelete(false);


			modelBuilder.Entity<Organization>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Answer>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Question>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<User>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<RevalidationTimeline>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<FeedBackUser>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<RevalidationDetail>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			
		}


	}
}
