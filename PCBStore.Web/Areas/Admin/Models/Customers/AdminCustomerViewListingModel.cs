namespace PCBStore.Web.Areas.Admin.Models.Customers
{
   using System.Collections.Generic;

   using Microsoft.AspNetCore.Mvc.Rendering;
   using Services.Admin.Model;

   public class AdminCustomerViewListingModel
    {

       public IEnumerable<AdminUserListingModel> Users { get; set; }

       public IEnumerable<SelectListItem> Roles { get; set; }
   }
}
