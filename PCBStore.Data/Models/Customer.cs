namespace PCBStore.Data.Models
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Microsoft.AspNetCore.Identity;
   using static DataConstants;

   public class Customer : IdentityUser
   {
      [Required]
      [MinLength(FirstNameMinLenght)]
      [MaxLength(FirstNameMaxLenght)]
      public string FirstName { get; set; }

      [Required]
      [MinLength(LastNameMinLenght)]
      [MaxLength(LastNameMaxLenght)]
      public string LastName { get; set; }

      [Required]
      public string Address { get; set; }

      [Required]
      public string Country { get; set; }

      public ICollection<Order> Orders { get; set; } = new List<Order>();

      public ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();

      public ICollection<Comment> Comments { get; set; } = new List<Comment>();

   }
}
