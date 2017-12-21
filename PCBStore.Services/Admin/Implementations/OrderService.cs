namespace PCBStore.Services.Admin.Implementations
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Microsoft.EntityFrameworkCore;
   using Model;

   public class OrderService : IOrderService
   {
      private readonly PcbStoreDbContext _db;

      public OrderService(PcbStoreDbContext db)
      {
         this._db = db;

      }


      public async Task<IEnumerable<OrderListingModel>> AllAsync()
         => await this._db.Orders.ProjectTo<OrderListingModel>().ToListAsync();
   }
}
