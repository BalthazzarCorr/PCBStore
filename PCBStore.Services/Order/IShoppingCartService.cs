namespace PCBStore.Services.Order
{
   using System.Collections.Generic;
   using Models;

   public interface IShoppingCartService
   {
      void AddToCart(string cartId, int productId);

      //void UpdateQuantity(string id, CartItem )

      void RemoveFromCart(string id, int productId);

      IEnumerable<CartItem> GetItems(string id);

   }
}
