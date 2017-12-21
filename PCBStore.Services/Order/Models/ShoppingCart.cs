namespace PCBStore.Services.Order.Models
{
   using System.Collections.Generic;
   using System.Linq;

   public class ShoppingCart
   {
      private readonly IList<CartItem> items;


      public ShoppingCart()
      {
         this.items = new List<CartItem>();
      }

      public List<CartItem> Items => new List<CartItem>(this.items); 

      public void AddtoCart(int productId)
      {

         var cartItem = this.items.FirstOrDefault(c => c.ProductId == productId);

         if (cartItem == null)
         {
            cartItem = new CartItem
            {
               ProductId = productId,
               Quantity = 1
            };

            this.items.Add(cartItem);
         }
         else
         {
            cartItem.Quantity++;
         }

          
         
      }

      public void RemoveFromCart(int productId)
      {
         var cartItems = this.items.FirstOrDefault(c => c.ProductId == productId);

         if (cartItems != null)
         {
            this.items.Remove(cartItems);
         }
      }


      public void Clear() => this.items.Clear();

   }
}
