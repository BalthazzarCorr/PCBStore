namespace PCBStore.Web.Areas.PCB.Controllers
{
   using System;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Http;
   using Microsoft.AspNetCore.Mvc;
   using Services.Order;
   using Services.Order.Models;

   public class OrdersController : Controller
   {
      private readonly IShoppingCartService _cartService;


      public OrdersController(IShoppingCartService cartService)
      {
         this._cartService = cartService;

      }

      public IActionResult Items()
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

         var items  = this._cartService.GetItems(shoppingCartId);

         return View(items);
      }

      public IActionResult AddToCart(int componentId)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         this._cartService.AddToCart(shoppingCartId, componentId);

         return RedirectToAction(nameof(Items));
      }
   }
}
