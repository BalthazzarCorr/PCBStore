namespace PCBStore.Services.Admin.Model
{
   using System.Collections.Generic;
   using Common.Mapping;
   using Data.Models;
   public class AdminUserListingModel : IMapFrom<Customer>
   {
      public string Id { get; set; }

      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Username { get; set; }

      public string Email { get; set; }

      public IList<string> CurrentRole { get; set; }
   }
}
