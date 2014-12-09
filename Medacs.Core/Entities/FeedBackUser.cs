using System;

namespace Medacs.Core.Entities
{
	public class FeedBackUser
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public  string LastName { get; set; }
		public string Profession { get; set; }
		public string PersonalizedMessage { get; set; }
		public string FeedbackUserGroup { get; set; }
		public virtual User User { get; set; }
		public virtual Guid UserId { get; set; }
	 }
}
