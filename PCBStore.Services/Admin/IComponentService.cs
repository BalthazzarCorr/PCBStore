namespace PCBStore.Services.Admin
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Data.Models.Enums;
   using Model;

   public interface IComponentService
   {
      Task Create(string name,string description,ComponentType type,ManufacturersEnum manufacturer, decimal price, string userId,string imgAddress);

      Task<IEnumerable<ComponetListingModel>> AllAsync();
   }
}
