using System;
using System.Collections.Generic;
using System.Linq;
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

		public void AddOptionChoices(List<OptionChoices> optionChoicesList)
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
	}
}