namespace PCBStore.Web.Models.AccountViewModels
{
   using System.ComponentModel.DataAnnotations;
   using static Data.DataConstants;

   public class RegisterViewModel
   {
      [Required]
      [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
         MinimumLength = 6)]
      public string UserName { get; set; }

      [Required]
      [StringLength(FirstNameMaxLenght,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",MinimumLength = FirstNameMinLenght)]
      public string FirstName { get; set; }

      [Required]
      [StringLength(LastNameMaxLenght,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",MinimumLength = LastNameMinLenght)]
      public string LastName { get; set; }

      [Required]
      public string Address { get; set; }

      [Required]
      public string Country { get; set; }

      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }
      
      [Required]
      [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirm password")]
      [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }
   }
}
