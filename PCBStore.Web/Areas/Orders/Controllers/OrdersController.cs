namespace PCBStore.Web.Areas.Orders.Controllers
{
   using System.Linq;
   using System.Threading.Tasks;
   using Admin.Models.Components;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using Services.Admin;
   using Services.Order;
   using static WebConstants;



   [Route("[controller]/[action]")]
   [Area(OrdersArea)]
   public class OrdersController : Controller
   {
      private readonly IShoppingCartService _cartService;
      private readonly PcbStoreDbContext _db;
      private readonly IComponentService _componentService;
      public OrdersController(IShoppingCartService cartService, PcbStoreDbContext db, IComponentService
         componentService)
      {
         this._cartService = cartService;
         this._db = db;
         this._componentService = componentService;

      }

      public async Task<IActionResult> Index()
      {
         var components = await this._componentService.AllAsync();

         return View(new ComponentLisitingViewModel
         {
            Componets = components
         });
      }

      public IActionResult Items()
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

         var items = this._cartService.GetItems(shoppingCartId);

         var itemsIds = items.Select(i => i.ProductId);

         var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);

         //var itemsWithDetails = this._db.Components
         //   .Where(pr => itemsIds
         //   .Contains(pr.Id))
         //   .Select(pr => new CartItemViewModel
         //   {
         //      Id = pr.Id,
         //      Name = pr.Name,
         //      Price = pr.Price,
         //      ImgAddress = pr.ImgAddress

         //   }).ToList();

         var itemsWithDetails = this._db.Components
            .Where(pr => itemsIds
               .Contains(pr.Id)).ProjectTo<CartItemViewModel>().ToList();
            

         itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.Id]);


         return View(itemsWithDetails);
      }

      public IActionResult AddToCart(int componentId)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         this._cartService.AddToCart(shoppingCartId, componentId);

         return RedirectToAction(nameof(Items));
      }
   }
}

