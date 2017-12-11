namespace PCBStore.Data.Models
{
   using System.Collections.Generic;
   using Microsoft.AspNetCore.Identity;

   public class Customer : IdentityUser
   {


      public string Address { get; set; }

      public string Country { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public ICollection<Order> Orders { get; set; }
   }
}
