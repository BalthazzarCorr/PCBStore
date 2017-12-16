namespace PCBStore.Web.Infrastructure.Extensions
{
   using Microsoft.AspNetCore.Mvc;
   using Services.News.Models;

   public static class ControllerExtensions
    {
      public static IActionResult ViewOrNotFound(this Controller controller, object model)
      {
         if (model == null)
         {
            return controller.NotFound();
         }

         return controller.View(model);
      }
   }
}
