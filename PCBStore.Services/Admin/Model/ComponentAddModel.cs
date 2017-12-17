namespace PCBStore.Services.Admin.Model
{
   using Common.Mapping;
   using Data.Models;
   using Data.Models.Enums;

   public class ComponentAddModel : IMapFrom<Component>
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public ComponentType Type { get; set; }

      public string Description { get; set; }

      public ManufacturersEnum Manufacturer { get; set; }

      public decimal Price { get; set; }

   }
}
