using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Managers
{
	public class ReportManager
	{[Inject]
		public IReporting ReportingRepository { get; set; }

		public int GetRespondentNumber(Guid userId,string feedBackUserType)
		{
			return ReportingRepository.GetRespondentNumber(userId, feedBackUserType);
		}


		public List<FeedbackSectionReport> GetQuestionPercentage(FeedBack feedback,Guid userId)
		{
			return ReportingRepository.GetQuestionPercentage(feedback, userId);
		}

		public byte[] GenerateReport(FeedBack feedback, List<FeedbackSectionReport> result)
		{
			var memStream = new MemoryStream();
			var doc = new Document();
			PdfWriter.GetInstance(doc, memStream).CloseStream = false;
			doc.Open();
			doc.NewPage();
			var paragraph = new Paragraph(feedback.Instruction);
			doc.Add(paragraph);
			foreach (var feedbackSectionReport in result)
			{
			

				feedbackSectionReport.QuestionPercentage.Select(a => a.OptionChoiceName).ToString();
				feedbackSectionReport.QuestionPercentage.Select(a => a.Percentage).ToString();
			}
			doc.Close();
			var pdfbytes = memStream.ToArray();
			memStream.Write(pdfbytes, 0, pdfbytes.Length);
			memStream.Position = 0;
			return pdfbytes;
		}
	}
}
