namespace PCBStore.Services.Admin.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.EntityFrameworkCore;
   using Model;

   public class AdminUserService : IAdminUserService
    {
       private readonly PcbStoreDbContext _db;
       private readonly UserManager<Customer> _userManager;

       public AdminUserService(PcbStoreDbContext db, UserManager<Customer> userManager)
       {
          this._db = db;
          this._userManager = userManager;
       }

       public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
       {
          List<AdminUserListingModel> list = new List<AdminUserListingModel>();

          foreach (var user in _userManager.Users.ToList())
          {
             list.Add(new AdminUserListingModel()
             {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                CurrentRole = await _userManager.GetRolesAsync(user)
             });
          }

          return  list;
         //return await this._db.Users.ProjectTo<AdminUserListingModel>().ToListAsync();
       }

   }
}
