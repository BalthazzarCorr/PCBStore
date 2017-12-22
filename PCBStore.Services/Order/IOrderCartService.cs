namespace PCBStore.Services.Order
{
   using System.Collections.Generic;
   using Data.Models;
   using Models;

   public interface IOrderCartService
   {
      Component ComponentById(int id);

      void CreateOrder(Order order);

      List<CartItemViewModel> ItemsWithDetails(IEnumerable<int> ids);
   }
}
