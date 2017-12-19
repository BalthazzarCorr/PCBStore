namespace PCBStore.Web.Infrastructure.Extensions
{
   using System;
   using Microsoft.AspNetCore.Http;
   using Services.Order.Models;

   public static class SessionExtension 
   {
      public const string SessionCartId = "Shopping_cart_Id";

      public static string GetShoppingCartId(this ISession session)
      {
         var shoppingCartId = session.GetString(SessionCartId);

         if (shoppingCartId == null)
         {
            shoppingCartId = Guid.NewGuid().ToString();

            session.SetString("Shopping_cart_Id", shoppingCartId);
         }

         return shoppingCartId;
      }

   }
}
