namespace PCBStore.Services.Admin.Model
{
   using System.Collections.Generic;

   public class AdminPanelListingModel
   {
      public int NumberOfArticles { get; set; }

      public int NumberOfCustomers { get; set; }

      public int NumberOfComponents { get; set; }

      public int NumberOfOrders { get; set; }

      public IEnumerable<LogModel> Logs { get; set; }
   }

}