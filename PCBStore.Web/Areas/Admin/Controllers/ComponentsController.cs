namespace PCBStore.Web.Areas.Admin.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models.Components;
   using Services.Admin;
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

         if (ModelState.IsValid)
         {
            await this._component.Create(model.Name, model.Description, model.Type, model.Manufacturer, model.Price,
               model.ImgAddress, userId);
            TempData.AddSuccessMessage("Add element");
            return RedirectToAction(nameof(AddComponent));
         }

         TempData.ErrorMessage("Can`t add empty component");
         return RedirectToAction(nameof(AddComponent));

      }


      public async Task<IActionResult> DeleteComponet(int id)
      {
         var component = await this._component.ComponentById(id);

         if (component != null)
         {
            this._component.DeleteComponent(id);
         }

         return RedirectToAction(nameof(Index));
      }

   }
}
