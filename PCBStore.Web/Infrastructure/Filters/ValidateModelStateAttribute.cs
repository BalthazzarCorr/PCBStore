namespace PCBStore.Web.Infrastructure.Filters
{
   using System.Linq;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Filters;

   public class ValidateModelStateAttribute : ActionFilterAttribute
   {

      public override void OnActionExecuting(ActionExecutingContext context)
      {
         if (!context.ModelState.IsValid)
         {
            var controller = context.Controller as Controller;

            if (controller == null)
            {
               return;
            }

            var model = context.ActionArguments.FirstOrDefault(a => a.Key.ToLower().Contains("model")).Value;


            if (model == null)
            {

            }
            context.Result = controller.View(model);
         }
      }
   }
}
