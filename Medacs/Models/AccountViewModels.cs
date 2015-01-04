using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medacs.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
		public string Email { get; set; }
		public string code { get; set; }
        
		[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

	public class RegisterViewModel
	{



		[Required]
		[Display(Name = "User name")]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string Gender { get; set; }
		public string Profession { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string PostCode { get; set; }
		public  IEnumerable<Salutation> ProfessionList = new List<Salutation>
		{
			new Salutation
			{
				Id = "1",
				Title = "Doctor"
			},
			new Salutation()
			{
				Id = "2",
				Title = "Nurse"
			}
		};
	}

	public class CallBackViewModel
	{
		public string UserId { get; set; }
		public string Code { get; set; }
		public string CallBackUrl { get; set; }
	}


	public class Salutation
	{
		public  string Id { get; set; }
		public string Title { get; set; }
	}


}
