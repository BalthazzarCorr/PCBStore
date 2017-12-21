using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBStore.Web.Areas.Admin.Models.Orders
{
   using Services.Admin.Model;

   public class OrderListingViewModel
    {
      public IEnumerable<OrderListingModel> Orders { get; set; }
   }
}
