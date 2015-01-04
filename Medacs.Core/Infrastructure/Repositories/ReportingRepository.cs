using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Common;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.DataContext;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;
using RestSharp.Extensions;

namespace Medacs.Core.Infrastructure.Repositories
{
	public class ReportingRepository : IReporting
	{
		[Inject]
		public IMedacsDbContext DbContext { get; set; }

		public int GetRespondentNumber(Guid userId, string feebackUserType)
		{
			return (from c in DbContext.Answers
				join fbu in DbContext.FeedBackUsers on c.FeedBackUserId equals fbu.Id
				where c.UserId.Equals(userId)
				where fbu.FeedBackUserType.Equals(feebackUserType)
				select c.FeedBackUserId).Distinct().Count();

		}

		public List<FeedbackSectionReport> GetQuestionPercentage(FeedBack feedback, Guid userId)
		{


			var feedbackSectionReportList = new List<FeedbackSectionReport>();

			var feedbackSections = feedback.FeedBackSection.Select(a => a).ToList();

			//var tab = DbContext.Answers.Join(DbContext.FeedBackQuestionOptions, a => a.FeedBackQuestionOptionId,
			//	fbqo => fbqo.Id, (a, fbqo) => new { a, fbqo })
			//	.Join(DbContext.OptionChoices, fb => fb.fbqo.OptionChoiceId, oc => oc.Id, (oc, fb) => new { oc, fb })
			//	.Join(DbContext.OptionGroups, ocs => ocs.fb.OptionGroupId, og => og.Id, (ocs, og) => new { ocs, og })
			//	.Join(DbContext.Questions, qcs => qcs.ocs.oc.fbqo.QuestionId, q => q.Id, (qcs, q) => new { qcs, q })
			//	.Join(DbContext.FeedBackSections, fbs => fbs.q.FeedBackSectionId, fs => fs.Id, (fbs, fs) => new { fbs, fs })
			//	.Join(DbContext.FeedBacks, f => f.fs.FeedBackId, feed => feed.Id, (feed, f) => new { feed, f })
			//	.Where(u => u.feed.fbs.qcs.ocs.oc.a.UserId.Equals(userId))
			//	.Where(q => q.feed.fbs.q.QuestionName.Equals("Diagnosis"))
			//	.GroupBy(g => new { g.feed.fbs.q.QuestionName, g.feed.fbs.qcs.ocs.fb.OptionChoiceName })
			//	.Select(r => new
			//	{
			//		value = r.Key,
			//		Percentage = r.Count()

			//	}).ToList();




			foreach (var feedbacksection in feedbackSections)
			{
				foreach (var question in feedbacksection.Questions)
				{
					var feedBackSectionReport = new FeedbackSectionReport
					{
						FeedbackSectionName = feedbacksection.SectionName,
						QuestionPercentage = new List<QuestionPercentageReport>()
					};

					//if (question.QuestionName != "Other (please specify):" && question.QuestionName != "Your professional role" &&
					//	question.InputType.InputTypeName != InputTypes.Label.ToString())
					//{
						var result = from a in DbContext.Answers
							join fbqo in DbContext.FeedBackQuestionOptions on a.FeedBackQuestionOptionId equals fbqo.Id
							join oc in DbContext.OptionChoices on fbqo.OptionChoiceId equals oc.Id
							join og in DbContext.OptionGroups on oc.OptionGroupId equals og.Id
							join q in DbContext.Questions on fbqo.QuestionId equals q.Id
							join fbs in DbContext.FeedBackSections on q.FeedBackSectionId equals fbs.Id
							join fb in DbContext.FeedBacks on fbs.FeedBackId equals fb.Id
							join fbu in DbContext.FeedBackUsers on a.FeedBackUserId equals fbu.Id
							where a.UserId.Equals(userId)
							      && q.QuestionName.Equals(question.QuestionName)
							group q by new {q.Id, q.QuestionName, oc.OptionChoiceName}
							into grp
							select new
							{
								questionId = grp.Key.Id,
								questionName = grp.Key.QuestionName,
								optionChoiceName = grp.Key.OptionChoiceName,
								Percentage = grp.Count()
							};

						if (result.Select(a => a.Percentage).Any())
						{
							var total = result.Sum(a => a.Percentage);
							var percentageReport = from c in result
								group c by new {c.Percentage, c.questionName, optionChoice = c.optionChoiceName}
								into grp
								select new QuestionPercentageReport
								{
									QuestionName = grp.Key.questionName,
									OptionChoiceName = grp.Key.optionChoice,
									Percentage = 100*grp.Key.Percentage/total
								};

							feedBackSectionReport.QuestionPercentage = percentageReport.ToList();
							feedbackSectionReportList.Add(feedBackSectionReport);
						}
					//}



				}




			}

			return feedbackSectionReportList;
		}


	}
}

public enum InputTypes
{
	TextBox,Radio,Label
}

public class FeedbackSectionReport

{
	public string FeedbackSectionName { get; set; }
	public List<QuestionPercentageReport> QuestionPercentage { get; set; }
	
}
public class QuestionPercentageReport
{
	public Guid Id { get; set; }
	public string QuestionName { get; set; }
	public string OptionChoiceName { get; set; }
	public decimal Percentage { get; set; }
	
}