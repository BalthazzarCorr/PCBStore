namespace PCBStore.Web.Infrastructure.Extensions
{
   using System;
   using System.Threading.Tasks;
   using Data.Models;
   using Data;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.DependencyInjection;
  

   public static class ApplicationBuilderExtensions
   {
      public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
      {


         using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
         {
            serviceScope.ServiceProvider.GetService<PcbStoreDbContext>().Database.Migrate();

            var userManager = serviceScope.ServiceProvider.GetService<UserManager<Customer>>();

            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
               var adminName = WebConstants.AdministratorRole;


               var roles = new[]
               {
                  adminName,
                  WebConstants.ModeratorRole,
                  WebConstants.CustomerRole
               };


               foreach (var role in roles)
               {
                  var roleExists = await roleManager.RoleExistsAsync(role);


                  if (!roleExists)
                  {
                     await roleManager.CreateAsync(new IdentityRole
                     {
                        Name = role
                     });
                  }
               }



               var adminEmail = "admin@mysite.com";

               var adminUser = await userManager.FindByEmailAsync(adminEmail);

               if (adminUser == null)
               {
                  adminUser = new Customer
                  {
                     Email = adminEmail,
                     UserName = adminEmail
                    
                  };
                  await userManager.CreateAsync(adminUser, "admin12");
                  await userManager.AddToRoleAsync(adminUser, adminName);
               }
            }).Wait();
         }


         return app;
      }
   }
      
}
