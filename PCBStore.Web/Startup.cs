﻿namespace PCBStore.Web
{
   using AutoMapper;
   using Data;
   using Data.Models;
   using Infrastructure.Extensions;
   using Infrastructure.Filters;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Hosting;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   using Services.Order;
   using Services.Order.Implementations;

   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddDbContext<PcbStoreDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

         services.AddIdentity<Customer, IdentityRole>(options =>
            {
               options.Password.RequireDigit = false;
               options.Password.RequiredLength = 3;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
            })
             .AddEntityFrameworkStores<PcbStoreDbContext>()
             .AddDefaultTokenProviders();



         services.AddMvc(options =>
         {
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            options.Filters.Add(new SimpleLogAttribute());
            options.Filters.Add(new ActionTimeAttribute());
         });
         services.AddRouting(routing => routing.LowercaseUrls = true);
         services.AddAntiforgery();
         services.AddSingleton<IShoppingCartService, ShoppingCartServices>();
         services.AddSession();
         services.AddDomainServices();
         services.AddAutoMapper();


      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseDatabaseErrorPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseStaticFiles();

         app.UseDatabaseMigration();

         app.UseAuthentication();

         app.UseSession();

         app.UseMvc(routes =>
         {
          

            routes.MapRoute(
               name: "news",
               template: "news/details/{id}/{title}",
               defaults: new { area = "News", controller = "News", action = "Details" }
            );
            
            routes.MapRoute(
               name: "areas",
               template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=Index}/{id?}");

         });
      }
   }
}
