namespace PCBStore.Services.Admin.Implementations
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Microsoft.EntityFrameworkCore;
   using Model;

   public class AdminUserService : IAdminUserService
    {
       private readonly PcbStoreDbContext _db;

       public AdminUserService(PcbStoreDbContext db)
       {
          this._db = db;
       }

       public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
          => await this._db.Users.ProjectTo<AdminUserListingModel>().ToListAsync();
   }
}
