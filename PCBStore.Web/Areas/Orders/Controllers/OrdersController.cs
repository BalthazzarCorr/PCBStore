namespace PCBStore.Web.Areas.Orders.Controllers
{
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Admin.Models.Components;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Infrastructure.Extensions;
   using LearningSystem.Web.Infrastructure.Extensions;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Http;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using Services.Admin;
   using Services.Order;
   using Services.Order.Models;
   using static WebConstants;



   [Route("[controller]/[action]")]
   [Area(OrdersArea)]
   public class OrdersController : Controller
   {
      private readonly IShoppingCartService _cartService;
      private readonly PcbStoreDbContext _db;
      private readonly IComponentService _componentService;
      private readonly UserManager<Customer> _userManager;
      private byte[] _fileContents;

      public OrdersController(IShoppingCartService cartService, PcbStoreDbContext db, IComponentService
         componentService, UserManager<Customer> userManager)
      {
         this._cartService = cartService;
         this._db = db;
         this._componentService = componentService;
         this._userManager = userManager;

         this._fileContents = new byte[20000000];
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

         //var itemsIds = items.Select(i => i.ProductId);

         var itemsWithDetails = this.GetCartItems(items);

         return View(itemsWithDetails);
      }

      public IActionResult AddToCart(int componentId)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         this._cartService.AddToCart(shoppingCartId, componentId);

         return RedirectToAction(nameof(Items));
      }


      public IActionResult RemoveFromCart(int componentId)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         this._cartService.RemoveFromCart(shoppingCartId, componentId);
         return RedirectToAction(nameof(Items));
      }


      [HttpPost]
      public IActionResult UpdateCart(int componentId, int quantity)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         var componet = this._db.Components.First(c => c.Id == componentId);
         _cartService.UpdateItem(componet, quantity,shoppingCartId);
         return RedirectToAction(nameof(Items));
      }

      [HttpPost]
      [Authorize]
      public async Task<IActionResult> UploadSchematics(IFormFile schematicZip)
      {
         if (!schematicZip.FileName.EndsWith(".zip")|| schematicZip.Length > DataConstants.SchematicAndPcbFileLength)
         {
            TempData.ErrorMessage("Your submission should be a '.zip' file with no more than 20 MB in size!");
            return RedirectToAction(nameof(Items));
         }

          this._fileContents = await schematicZip.ToByteArrayAsync();

         return RedirectToAction(nameof(Items) );
      }

      [Authorize]
      public IActionResult FinishOrder()
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

         var items = this._cartService.GetItems(shoppingCartId);
         
         var itemsWithDetails = this.GetCartItems(items);
         

         var order = new Order
         {
            CustomerId = this._userManager.GetUserId(User),
            TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity),
            Schematic = this._fileContents
            
         };

         foreach (var item in items)
         {
            order.Components.Add(new OrderComponents
            {
               ComponentId = item.ProductId,
               Quantity = item.Quantity,
               ComponentPrice = item.Price,
               

            });
         }
         this._db.Add(order);
         this._db.SaveChanges();

         _cartService.Clear(shoppingCartId);

         return RedirectToAction("Home","Home",new {area = "" });
      }

      private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> items)
      {
         var itemsIds = items.Select(i => i.ProductId);

         var itemsWithDetails = this._db.Components
                     .Where(pr => itemsIds
                   .Contains(pr.Id))
                   .ProjectTo<CartItemViewModel>()
                   .ToList();


         var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);




         itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.Id]);

         return itemsWithDetails;
      }

   }
}

