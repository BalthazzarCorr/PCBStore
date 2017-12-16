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
   using Web.Models.AccountViewModels;
   using static WebConstants;

   [Authorize(Roles = AdministratorRole)]
   [Route("[controller]/[action]")]
   public class CustomersController : BaseAdminController
   {
      private readonly IAdminUserService _users;
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly UserManager<Customer> _userManager;



      public CustomersController(IAdminUserService users, RoleManager<IdentityRole> roleManager,
         UserManager<Customer> userManager)
      {
         this._users = users;
         this._roleManager = roleManager;
         this._userManager = userManager;

      }

      public IActionResult Index()
      {
         return View();
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
