using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;

namespace Medacs.Core.Infrastructure.Interfaces
{
	public interface IFeedBack
	{
		void AddFeedBack(FeedBack feedBack);
		bool DeleteFeedBack(Guid id);
		void UpdateFeedBack(FeedBack feedBack);
		List<FeedBack> GetFeedBacks();
		FeedBack GetFeedBackbyId(Guid id);
		FeedBack GetFeedBackById(Guid id);
		void AddFeedBackSection(FeedBackSection feedBackSection);


		List<FeedBackSection> GetFeedBackSection(Guid id);

		Guid AddOptionGroup(OptionGroup optionGroup);

		void AddInputTypes(InputType inputType);
		void OptionChoices(List<OptionChoices> optionChoicesList);
		List<OptionGroup> GetOptionGroups();
		List<InputType> GetInputTypes();

		void AddQuestion(Question question);
		List<Question> GetQuestionBySection(Guid id);

		string GetLatestCodeForFeedBack(Guid id);
		int RecordLatestCode(Guid feedBackid, string nextNumber);
	}
}
