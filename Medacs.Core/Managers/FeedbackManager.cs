using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
		[Inject]
		public IFeedBackUser FeedBackUserRepository { get; set; }


		public void AddFeedBackRepository(FeedBack feedBack)
		{
			FeedBackRepository.AddFeedBack(feedBack);
		}

		public List<FeedBack> GetFeedBacks()
		{
			return FeedBackRepository.GetFeedBacks();
		}

		public FeedBack GetFeedBackById(Guid id)
		{
			return FeedBackRepository.GetFeedBackById(id);
		}

		public FeedBack GetFeedBackByName(string feedBackName)
		{
			return FeedBackRepository.GetFeedBackByName(feedBackName);
		}

		public void AddFeedBackSection(FeedBackSection feedBackSection)
		{
			FeedBackRepository.AddFeedBackSection(feedBackSection);
		}

		public List<FeedBackSection> GetFeedBackSections(Guid id)
		{
			return FeedBackRepository.GetFeedBackSection(id);
		}

		public Guid AddOptionGroup(OptionGroup optionGroup)
		{
			return FeedBackRepository.AddOptionGroup(optionGroup);
		}

		public void AddInputTypes(InputType inputTypes)
		{
			FeedBackRepository.AddInputTypes(inputTypes);

		}

		public void AddOptionChoices(List<OptionChoice> optionChoicesList)
		{
			FeedBackRepository.OptionChoices(optionChoicesList);
		}

		public List<OptionGroup> GetOptionGroup()
		{
			return FeedBackRepository.GetOptionGroups();

		}

		public  List<InputType> GetInputTypes()
		{
			return FeedBackRepository.GetInputTypes();
		}

		public  void AddQuestion(Question question)
		{
			FeedBackRepository.AddQuestion(question);
		}

		public List<Question> GetQuestionbySection(Guid id)
		{
		 return	FeedBackRepository.GetQuestionBySection(id);
		}

		public void UpdateFeedBack(FeedBack feedback)
		{
			 FeedBackRepository.UpdateFeedBack(feedback);
		}

		public string GetLatestCodeForFeedBack(Guid Id)
		{
			return FeedBackRepository.GetLatestCodeForFeedBack(Id);
		}

		public List<FeedBackQuestionOption> GetFeedBackQuestionOption()
		{
			return FeedBackRepository.GetFeedBackOption();
		}

		public void InsertAnswer(List<Answer> answers)
		{
			FeedBackRepository.InsertAnswer(answers);
		}

		public User GetUser(Guid id)
		{
			return FeedBackUserRepository.GetUser(id);
		}

		
	}
}