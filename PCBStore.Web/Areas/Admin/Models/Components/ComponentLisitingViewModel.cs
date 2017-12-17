namespace PCBStore.Web.Areas.Admin.Models.Components
{
   using System.Collections.Generic;
   using Services.Admin.Model;

   public class ComponentLisitingViewModel 
   {
      public IEnumerable<ComponetListingModel> Componets { get; set; }
   }
}
