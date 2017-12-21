namespace PCBStore.Services.Order
{
   using System.Collections.Generic;
   using Models;
   using Data.Models;

   public interface IShoppingCartService
   {
      void AddToCart(string cartId, int productId);

      //void UpdateQuantity(string id, CartItem )

      void RemoveFromCart(string id, int productId);

      IEnumerable<CartItem> GetItems(string id);

      void Clear(string id);

      void UpdateItem(Component componet, int quantity, string shoppingCartId);


   }
}
