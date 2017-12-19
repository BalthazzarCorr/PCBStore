namespace PCBStore.Services.Order.Implementations
{
   using System.Collections.Concurrent;
   using System.Collections.Generic;
   using System.Linq;
   using Data;
   using Data.Models;
   using Models;

   public class ShoppingCartService : IShoppingCartService
   {
      private readonly ConcurrentDictionary<string, ShoppingCart> _carts;
      private readonly PcbStoreDbContext _db;


      public ShoppingCartService(PcbStoreDbContext db)
      {
         this._db = db;
         this._carts = new ConcurrentDictionary<string, ShoppingCart>();
      }

      public void AddToCart(string cartId, int productId)
      {
         var shoppingCart = GetShoppingCart(cartId);


         shoppingCart.AddtoCart(productId);
      }

      public void RemoveFromCart(string cartId, int productId)
      {
         var shoppingCart = GetShoppingCart(cartId);

         shoppingCart.RemoveFromCart(productId);
      }

      //public Component GetItemsWithDetails(IEnumerable<int> itemsIds)
      //               => this._db
      //   .Components
      //   .Where(pr => itemsIds
      //   .Contains(pr.Id))
      //   .Select(pr => new
      //   {
            
      //   }).ToList()



      public IEnumerable<CartItem> GetItems(string cartId)
      {
         var shoppingCart = GetShoppingCart(cartId);
         return new List<CartItem>(shoppingCart.Items);
      }

      private ShoppingCart GetShoppingCart(string cartId)
      {
         return this._carts.GetOrAdd(cartId, new ShoppingCart());
      }

   }
}
