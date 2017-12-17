namespace PCBStore.Web.Areas.Admin.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models.Components;
   using Services.Admin;
   using Services.Admin.Model;
   using static WebConstants;

   [Authorize(Roles = AdministratorRole)]
   [Route("[controller]/[action]")]
   public class ComponentsController : BaseAdminController
   {
      private readonly IComponentService _component;

      private readonly UserManager<Customer> _userManager;



      public ComponentsController(IComponentService component, UserManager<Customer> userManager)
      {
         this._component = component;
         this._userManager = userManager;
      }

      public async Task<IActionResult> Index()
      {
         var components = await this._component.AllAsync();

         return View(new ComponentLisitingViewModel
         {
            Componets = components
         });
      }

      public IActionResult AddComponent()
      {
         return View();
      }


      [HttpPost]
      public async Task<IActionResult> AddComponent(ComponentAddViewModel model)
      {
         var userId = _userManager.GetUserId(User);

         await this._component.Create(model.Name, model.Description, model.Type, model.Manufacturer, model.Price, userId);

        return  RedirectToAction(nameof(AddComponent));
      }


   }
}
