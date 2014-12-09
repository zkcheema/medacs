using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.DataContext;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Infrastructure.Repositories
{
	public class FeedBackRepository : IFeedBack
	{
		[Inject]
		public IMedacsDbContext DbContext { get; set; }

		public void AddFeedBack(FeedBack feedBack)
		{
			try
			{
				DbContext.FeedBacks.Add(feedBack);
				DbContext.SaveChanges();
			}
			catch (Exception exception)
			{
				throw new Exception("Unable to add Feedback entity", exception);
			}
		}

		public bool DeleteFeedBack(Guid id)
		{
			throw new NotImplementedException();
		}

		public void UpdateFeedBack(FeedBack feedBack)
		{
			try
			{
				var existingfeedback = DbContext.FeedBacks.Select(f => f).FirstOrDefault(a => a.Id.Equals(feedBack.Id));
				if (existingfeedback != null)
				{
					existingfeedback.FeedBackName = feedBack.FeedBackName;
					existingfeedback.Description = feedBack.Description;
					existingfeedback.StartDateTime = feedBack.StartDateTime;
					existingfeedback.IsOpen = feedBack.IsOpen;
					existingfeedback.Instruction = feedBack.Instruction;
					existingfeedback.OtherInformation = feedBack.OtherInformation;
					DbContext.SaveChanges();
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Unable to Update Feedback entity", exception);
			}

		}

		public List<FeedBack> GetFeedBacks()
		{
			return DbContext.FeedBacks.Select(a => a).ToList();
		}

		public FeedBack GetFeedBackbyId(Guid id)
		{
			throw new NotImplementedException();
		}

		public FeedBack GetFeedBackById(Guid id)
		{
			return DbContext.FeedBacks.Include(a => a.FeedBackSection).Select(fb => fb).FirstOrDefault(a => a.Id.Equals(id));
		}

		public void AddFeedBackSection(FeedBackSection feedBackSection)
		{
			try
			{
				DbContext.FeedBackSections.Add(feedBackSection);
				DbContext.SaveChanges();
			}
			catch (Exception exception)
			{
				throw new Exception("Uaable to Add FeedBackSecstion", exception);
			}
		}

		public List<FeedBackSection> GetFeedBackSection(Guid id)
		{
			var result = from fs in DbContext.FeedBackSections.Include(q => q.Questions)
				where fs.FeedBackId == id
				select fs;
			return result.ToList();

		}

		public Guid AddOptionGroup(OptionGroup optionGroup)
		{
			try
			{
				DbContext.OptionGroups.Add(optionGroup);
				DbContext.SaveChanges();
				return optionGroup.Id;
			}
			catch (Exception exception)
			{

				throw new Exception("Uaable to Add Option Group", exception);
				;
			}


		}

		public void AddInputTypes(InputType inputType)
		{
			try
			{
				var inputTypeExist =
					DbContext.InputTypes.Select(a => a.InputTypeName.Equals(inputType.InputTypeName)).FirstOrDefault();
				if (!inputTypeExist)
					DbContext.InputTypes.Add(inputType);

			}
			catch (Exception exception)
			{

				throw new Exception("Uaable to Add inputTypes", exception);
			}
		}

		public void OptionChoices(List<OptionChoices> optionChoicesList)
		{
			try
			{
				foreach (var optionChoice in optionChoicesList)
				{
					DbContext.OptionChoices.Add(optionChoice);
					DbContext.SaveChanges();
				}

			}
			catch (Exception exception)
			{

				throw new Exception("Uaable to Add Option Choices", exception);
			}
		}

		public List<OptionGroup> GetOptionGroups()
		{
			return DbContext.OptionGroups.Include(a => a.OptionChoices).Select(a => a).ToList();
		}

		public List<InputType> GetInputTypes()
		{
			return DbContext.InputTypes.Select(a => a).ToList();
		}

		public void AddQuestion(Question question)
		{
			try
			{
				DbContext.Questions.Add(question);
				DbContext.SaveChanges();

			}
			catch (Exception exception)
			{
				throw new Exception("Uaable to Add Questions", exception);

			}
		}

		public List<Question> GetQuestionBySection(Guid id)
		{

			return
				DbContext.Questions.Select(a => a)
					.Include(a => a.OptionGroup)
					.Include(b => b.InputType)
					.Include(o => o.OptionGroup.OptionChoices)
					.Where(q => q.FeedBackSectionId.Equals(id))
					.ToList();

		}

		public string GetLatestCodeForFeedBack(Guid id)
		{
			return (from c in DbContext.FeedBacks where c.Id == id select c.LatestCode).FirstOrDefault();
		}

		public int RecordLatestCode(Guid feedBackid, string nextNumber)
		{
			var feedBack =
		  (from i in DbContext.FeedBacks where i.Id == feedBackid select i).FirstOrDefault();

			if (feedBack == null)return 0;

			feedBack.LatestCode = nextNumber;
			DbContext.SaveChanges();

			return 1;
		}
	}
}
