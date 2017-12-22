namespace PCBStore.Web.Areas.Admin.Controllers
{
   using System.Linq;
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Microsoft.EntityFrameworkCore;
   using Models.Customers;
   using Services.Admin;
   using Services.Admin.Model;
   using Services.News;
   using Web.Models.AccountViewModels;
   using static WebConstants;

   [Authorize(Roles = AdministratorRole)]
   [Route("[controller]/[action]")]
   public class CustomersController : BaseAdminController
   {
      private readonly IAdminUserService _users;
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly IComponentService _components;
      private readonly UserManager<Customer> _userManager;
      private readonly INewsArticleService _newsArticles;
      private readonly IOrderService _orderService;


      public CustomersController(IAdminUserService users, RoleManager<IdentityRole> roleManager,
         UserManager<Customer> userManager, IComponentService components, INewsArticleService newsArticles,
         IOrderService orderService)
      {
         this._users = users;
         this._roleManager = roleManager;
         this._userManager = userManager;
         this._components = components;
         this._newsArticles = newsArticles;
         this._orderService = orderService;


      }

      public async Task<IActionResult> Index()
      {

         var users = await this._users.AllAsync();

         var numberOfCustomers = users.Count();

         var components = await this._components.AllAsync();

         var numberOfComponents = components.Count();

         var articles = await this._newsArticles.AllAsync();

         var numberOfArticles = articles.Count();

         var NumberOfOrders = this._orderService.OrderCount();

         var logs = this._users.AllLogs();

         return View( new AdminPanelListingModel
         {
            NumberOfCustomers = numberOfCustomers,
            NumberOfComponents = numberOfComponents,
            NumberOfArticles = numberOfArticles,
            NumberOfOrders = NumberOfOrders,
            Logs = logs
            
         });
      }

      public async Task<IActionResult> AllCustomers()
      {
         var users = await this._users.AllAsync();
         
         var roles = await this._roleManager.Roles.Select(r => new SelectListItem
         {
            Text = r.Name,
            Value = r.Name,
         }).ToListAsync();


         return View(new AdminCustomerViewListingModel()
         {
            Users = users,
            Roles = roles

         });
         

      }

      [HttpPost]
      public  JsonResult Add([FromBody] RegisterViewModel model)
      {
         var customer = new Customer
         {
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = model.Address,
            Country = model.Country,

         };
         
         return Json(_userManager.CreateAsync(customer, model.Password));

      }



      [HttpPost]
      public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
      {
         var roleExists = await this._roleManager.RoleExistsAsync(model.Role);
         var user = await this._userManager.FindByIdAsync(model.UserId);

         var userExists = user != null;

         if (!roleExists || !userExists)
         {
            ModelState.AddModelError(string.Empty, "Invalid identity details.");
         }

         if (!ModelState.IsValid)
         {
            RedirectToAction(nameof(AllCustomers));
         }


         await this._userManager.AddToRoleAsync(user, model.Role);

         if (user != null)
         {
            TempData.AddSuccessMessage($"Successfully added user {user.UserName} to {model.Role} role");
         }
         return RedirectToAction(nameof(AllCustomers));
      }

      [HttpPost]
      public async Task<IActionResult> RemoveFromRole(AddUserToRoleFormModel model)
      {
         var roleExists = await this._roleManager.RoleExistsAsync(model.Role);
         var user = await this._userManager.FindByIdAsync(model.UserId);

         var userExists = user != null;

         if (!roleExists || !userExists)
         {
            ModelState.AddModelError(string.Empty, "Invalid identity details.");
         }

         if (!ModelState.IsValid)
         {
            RedirectToAction(nameof(AllCustomers));
         }

         await this._userManager.RemoveFromRoleAsync(user, model.Role);

         if (user != null)
         {
            TempData.AddSuccessMessage($"Successfully removed user {user.UserName} to {model.Role} role");
         }
         return RedirectToAction(nameof(AllCustomers));
      }




      public async Task<IActionResult> DeleteCustomer(string email)
      {

         return View( await this._users.Edit(email));
      }

      [HttpPost]
      public async Task<IActionResult> EditCustomer(string email ,CustomerEditModel model)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         var user = await _userManager.FindByEmailAsync(email);
        
         
         if (user != null)
         {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.Country = model.Country;
            
            await _userManager.UpdateAsync(user);

            TempData.AddSuccessMessage($"Successfully edited user");
            return RedirectToAction(nameof(AllCustomers));
         }
         TempData.ErrorMessage($"User does not exist");
         return RedirectToAction(nameof(Index));
      }

      [HttpPost]
      public async Task<IActionResult> DeletePermanitly(string email)
      {
         var user = _userManager.FindByEmailAsync(email);

         if (user != null)
         {
            await _userManager.DeleteAsync(await user);

            TempData.AddSuccessMessage($"Successfully deleted user");
            return RedirectToAction(nameof(AllCustomers));
         }

         TempData.ErrorMessage($"User does not exist");
         return RedirectToAction(nameof(Index));
      }
   }
}
