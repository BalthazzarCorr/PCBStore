namespace PCBStore.Services.Admin.Model
{
   using Common.Mapping;
   using Data.Models;
   using Data.Models.Enums;

   public class ComponetListingModel : IMapFrom<Component>
    {
      public int Id { get; set; }

       public string Name { get; set; }

       public ComponentType Type { get; set; }

       public ManufacturersEnum Manufacturer { get; set; }

       public string Price { get; set; }

      
    }
}
