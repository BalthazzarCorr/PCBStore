namespace PCBStore.Services.Admin
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Data.Models.Enums;
   using Model;

   public interface IComponentService
   {
      Task Create(string name,string description,ComponentType type,ManufacturersEnum manufacturer, decimal price, string imgAddress, string userId);

      Task<IEnumerable<ComponetListingModel>> AllAsync();

      Task<ComponentAddModel> ComponentById(int id);

      void DeleteComponent(int id);
   }
}
