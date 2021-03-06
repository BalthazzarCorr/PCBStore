﻿namespace PCBStore.Services.Order
{
   using System.Collections.Generic;
   using Models;
   using Data.Models;
   

   public interface IShoppingCartService
   {
      void AddToCart(string cartId, int productId);

     
      void RemoveFromCart(string id, int productId);

      IEnumerable<CartItem> GetItems(string id);

      void Clear(string id);

      void UpdateItem(Component componet, int quantity, string shoppingCartId);

      byte[] SavingFile(byte[] file);

      byte[] SavedFile();


   }
}
