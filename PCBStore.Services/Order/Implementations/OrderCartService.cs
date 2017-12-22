namespace PCBStore.Services.Order.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Models;

   public class OrderCartService : IOrderCartService
   {

      private readonly PcbStoreDbContext _db;

      public OrderCartService(PcbStoreDbContext db)
      {
         this._db = db;
      }

      public Component ComponentById(int id)
         => this._db.Components.First(c => c.Id == id);


      public void CreateOrder(Order order)
      {
         if (order != null)
         {
            this._db.Add(order);
            this._db.SaveChanges();
            
         }
      }


      public List<CartItemViewModel> ItemsWithDetails(IEnumerable<int> ids)
         => this._db.Components
            .Where(pr => ids.Contains(pr.Id))
            .ProjectTo<CartItemViewModel>()
            .ToList();
   }
}
