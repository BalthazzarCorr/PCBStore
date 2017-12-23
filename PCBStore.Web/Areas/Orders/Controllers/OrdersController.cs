namespace PCBStore.Web.Areas.Orders.Controllers
{
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Admin.Models.Components;
   using Data;
   using Data.Models;
   using Infrastructure.Extensions;
   using Infrastructure.Filters;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Http;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Services.Admin;
   using Services.Order;
   using Services.Order.Models;
   using static WebConstants;



   [Route("[controller]/[action]")]
   [Area(OrdersArea)]
   public class OrdersController : Controller
   {
      private readonly IShoppingCartService _cartService;
      private readonly IComponentService _componentService;
      private readonly UserManager<Customer> _userManager;
      private readonly IOrderCartService _orderService;

      public OrdersController(IShoppingCartService cartService, IComponentService
         componentService, UserManager<Customer> userManager, IOrderCartService orderService)
      {
         this._cartService = cartService;
         this._componentService = componentService;
         this._userManager = userManager;
         this._orderService = orderService;

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
      [ValidateModelState]
      public IActionResult UpdateCart(int componentId, int quantity)
      {
         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
         var componet = this._orderService.ComponentById(componentId);
         _cartService.UpdateItem(componet, quantity, shoppingCartId);
         return RedirectToAction(nameof(Items));
      }

      [HttpPost]
      [ValidateModelState]
      [Authorize]
      public async Task<IActionResult> UploadSchematics(IFormFile schematicZip)
      {
         if (schematicZip != null)
         {

            if (!schematicZip.FileName.EndsWith(".zip") || !schematicZip.FileName.EndsWith(".xml") || schematicZip.Length > DataConstants.SchematicAndPcbFileLength)
            {
               TempData.ErrorMessage("Your schematics  should be a '.zip' or '.xml' file with no more than 20 MB in size!");
               return RedirectToAction(nameof(Items));
            }


            var fileContents = await schematicZip.ToByteArrayAsync();

            this._cartService.SavingFile(fileContents);

            TempData.AddSuccessMessage("File uploaded successfully");

            return RedirectToAction(nameof(Items));
         }

         TempData.ErrorMessage("Your didn`t submit a schematic file");

         return RedirectToAction(nameof(Items));
      }

      [Authorize]
      public IActionResult FinishOrder()
      {


         var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

         var items = this._cartService.GetItems(shoppingCartId);

         if (!items.Any())
         {
            TempData.ErrorMessage("Can`t have an empty cart");
            return RedirectToAction(nameof(Items));
         }

         var itemsWithDetails = this.GetCartItems(items);


         var order = new Order
         {
            CustomerId = this._userManager.GetUserId(User),
            TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity),
            Schematic = this._cartService.SavedFile()


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

         this._orderService.CreateOrder(order);
         _cartService.Clear(shoppingCartId);

         TempData.AddSuccessMessage("Order Sent");

         return RedirectToAction("Home", "Home", new { area = "" });
      }

      private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> items)
      {
         var itemsIds = items.Select(i => i.ProductId);

         var itemsWithDetails = this._orderService.ItemsWithDetails(itemsIds);


         var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);




         itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.Id]);

         return itemsWithDetails;
      }

   }
}

