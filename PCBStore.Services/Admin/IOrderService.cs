namespace PCBStore.Services.Admin
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Model;

   public interface IOrderService
    {
      Task<IEnumerable<OrderListingModel>> AllAsync();
       int OrderCount();
   }
}
