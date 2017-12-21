namespace PCBStore.Web.Areas.Admin.Models.Customers
{
   using System.Collections.Generic;
   using Services.Admin.Model;

   public class LogViewModel
    {
       private IEnumerable<LogModel> Logs { get; set; }
    }
}
