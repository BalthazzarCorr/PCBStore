﻿namespace PCBStore.Services.Order.Implementations
{
   using System.Collections.Concurrent;
   using System.Collections.Generic;
   using Data.Models;
   using Models;
   using Microsoft.AspNetCore.Http;
   

   public class ShoppingCartServices : IShoppingCartService
   {
      private readonly ConcurrentDictionary<string, ShoppingCart> _carts;
     public ShoppingCartServices()
      {
         
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
      

      public IEnumerable<CartItem> GetItems(string cartId)
      {
         var shoppingCart = GetShoppingCart(cartId);

         return new List<CartItem>(shoppingCart.Items);
      }

      public void Clear(string id) => this.GetShoppingCart(id).Clear();


      public void UpdateItem(Component componet, int quantity,string shoppingCartId)
      {
        
         var shoppingCart = GetShoppingCart(shoppingCartId);

         var item = shoppingCart.Items.Find(c => c.ProductId == componet.Id);

         item.Quantity = quantity;
         
         
      }

     

      private ShoppingCart GetShoppingCart(string cartId)
      {
         return this._carts.GetOrAdd(cartId, new ShoppingCart());
      }

   }
}
