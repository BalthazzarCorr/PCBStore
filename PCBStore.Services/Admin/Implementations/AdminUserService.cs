namespace PCBStore.Services.Admin.Implementations
{
   using System.Collections.Generic;
   using System.IO;
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
      
      private readonly UserManager<Customer> _userManager;
      private readonly PcbStoreDbContext _db;

      public AdminUserService( UserManager<Customer> userManager,PcbStoreDbContext db)
      {
         
         this._userManager = userManager;
         this._db = db;
      }

      public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
      {
         List<AdminUserListingModel> list = new List<AdminUserListingModel>();

         foreach (var user in _userManager.Users.ToList())
         {
            list.Add(new AdminUserListingModel()
            {
               Id = user.Id,
               FirstName = user.FirstName,
               LastName = user.LastName,
               Username = user.UserName,
               Email = user.Email,
               CurrentRole = await _userManager.GetRolesAsync(user)
            });
         }

         return list;
         
      }




      public async Task<CustomerEditModel> Edit(string email)
         => await this._db.Users.Where(s => s.Email == email).ProjectTo<CustomerEditModel>().FirstOrDefaultAsync();


      public   List<LogModel> AllLogs()
      {
         var filePath = @"C:\Users\Balth\source\repos\PCBStore\PCBStore.Web\log.txt";

         var text = File.ReadAllLines(filePath);

         List<LogModel>Logs = new List<LogModel>();
         
         for (int i = 0; i < text.Length; i++)
         {
            var line = text[i];


            var log = new LogModel
            {
               Info = line
            };

            Logs.Add(log);

         }

         return Logs;

      }
   }
}
