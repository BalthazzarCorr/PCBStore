namespace PCBStore.Services.Admin

{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Model;
  

   public interface IAdminUserService
   {
      Task<IEnumerable<AdminUserListingModel>> AllAsync();
   }
}
