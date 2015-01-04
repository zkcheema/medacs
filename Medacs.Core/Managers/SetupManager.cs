using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Medacs.Core.Entities;
using Medacs.Core.Infrastructure.Interfaces;
using Ninject;

namespace Medacs.Core.Managers
{
	public class SetupManager
	{
		[Inject]
		public IFeedBackUser FeedBackUserRepository { get; set; }
		[Inject]
		public IFeedBack FeedBackRepository { get; set; }
		[Inject]
		public FeedbackManager FeedbackManager { get; set; }
		
		public void InsertFeedBackUser(FeedBackUser feedbackuser)
		{
			FeedBackUserRepository.AddFeedBackUser(feedbackuser);
		}

		public List<FeedBackUser> GetFeedBackUser(Guid userId,string userType)
		{
			return FeedBackUserRepository.GetFeedBackUser(userId,userType);
		}

		public Guid GetFeedBackUserid(Guid id)
		{
			return FeedBackUserRepository.GetFeedBackUserid(id);
		}

		public bool CheckEmailExist(string email,Guid id)
		{
			return FeedBackUserRepository.CheckEmailExist(email,id);
		}

		public bool UpdateFeeBackUser(Guid id, FeedBackUser user)
		{
			return FeedBackUserRepository.UpdateFeedBackUser(id, user);
		}

		public FeedBackUser GetFeedBackUserbyId(Guid id)
		{
			return FeedBackUserRepository.GetFeedBackUserbyId(id);
		}


		public bool DeleteFeedBackUser(Guid id)
		{
			return	FeedBackUserRepository.Delete(id);
		}

		public bool UpdateEmail(string email, Guid id)
		{
			return FeedBackUserRepository.UpdateEmail(email,id);
		}

		public string GenerateRandomHexCode()
		{
			return FeedBackUserRepository.GenerateRandomHexCode();
		}

		public List<int> GetRandomNumbers(int noOfNumbers, int maxValue)
		{
			var generator = new Random();
			var ranInts = new List<int>(noOfNumbers);
			var uniqueInts = Enumerable.Range(maxValue + 1, noOfNumbers * 3).ToList();
			for (var i = 1; i <= noOfNumbers; i++)
			{
				var index = generator.Next(uniqueInts.Count);
				ranInts.Add(((uniqueInts[index])));
				uniqueInts.RemoveAt(index);
			}
			return ranInts.OrderByDescending(x => x).ToList();
		}

		public string  GenerateRandomCode(Guid feedBackid)
		{
			var lastCode = FeedbackManager.GetLatestCodeForFeedBack(feedBackid);
			var lastCodeNumbers = Regex.Match(lastCode, @"\d+").Value;
			var randomNumbers = GetRandomNumbers(1, Convert.ToInt32(lastCodeNumbers));
			IEnumerable<int> codes = randomNumbers.Select(code => code);
			var updated = FeedBackRepository.RecordLatestCode(feedBackid, randomNumbers.FirstOrDefault().ToString());
			if (updated > 0)
				return codes.FirstOrDefault().ToString();
			return null;
		}

		public string GenerateLink(int code)
		{
			var codeAsNumber = code;
			var codeAsHex = codeAsNumber.ToString("X").PadLeft(7, '0');
			var charArray = codeAsHex.ToCharArray();
			Array.Reverse(charArray);
			codeAsHex = new string(charArray);
			return codeAsHex;


		}
	}
}
