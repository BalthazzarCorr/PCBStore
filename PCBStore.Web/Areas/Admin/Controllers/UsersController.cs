namespace PCBStore.Web.Areas.Admin.Controllers
{
   using System.Linq;
   using System.Threading.Tasks;
   using Data.Models;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Microsoft.EntityFrameworkCore;
   using Models.Customers;
   using Services.Admin;

   public class UsersController : BaseAdminController
   {
      private readonly IAdminUserService _users;
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly UserManager<Customer> _userManager;



      public UsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager,
         UserManager<Customer> userManager)
      {
         this._users = users;
         this._roleManager = roleManager;
         this._userManager = userManager;

      }


      public async Task<IActionResult> Index()
      {
         var users = await this._users.AllAsync();

         var roles = await this._roleManager.Roles.Select(r => new SelectListItem
         {
            Text = r.Name,
            Value = r.Name
         }).ToListAsync();


         return View(new AdminCustomerViewListingModel
         {
            Users = users,
            Roles = roles

         });

      }
   }
}
