namespace PCBStore.Services.Admin.Model
{
   using System.Collections.Generic;
   using Data.Models;

   public class OrderListingModel
   {
      public Customer Customer { get; set; }

      public decimal TotalPrice { get; set; }

      public ICollection<OrderComponents> Components { get; set; } 
   }
}
