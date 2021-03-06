﻿namespace PCBStore.Web.Areas.Admin.Controllers
{
   using System.Threading.Tasks;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Mvc;
   using Models.Orders;
   using Services.Admin;
   using static  WebConstants;

   [Authorize(Roles = ModeratorRole )]
   public class OrdersController : BaseAdminController
   {
      private readonly IOrderService _orderService;

      public OrdersController(IOrderService orderService)
      {
         this._orderService = orderService;

      }

      public async Task<IActionResult> Index()
      {
         var orders = await this._orderService.AllAsync();

         return View(new OrderListingViewModel
         {
            Orders = orders
         });
      }

   }
}
