﻿namespace PCBStore.Services.Admin.Implementations
{
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Data.Models.Enums;
   using Microsoft.EntityFrameworkCore;
   using Model;

   public class ComponentService : IComponentService
   {
      private readonly PcbStoreDbContext _db;
      

      public ComponentService(PcbStoreDbContext db)
      {
         this._db = db;
      }


      public async Task Create(string name, string description, ComponentType type, ManufacturersEnum manufacturer, decimal price,
         string imgAddress, string userId)
      {
         

         var component = new Component
         {
            Name = name,
            Description = description,
            Type = type,
            Manufacturer = manufacturer,
            Price = price,
            UserId = userId,
            ImgAddress = imgAddress
         };

         this._db.Add(component);
         await this._db.SaveChangesAsync();
      }

      public async Task<IEnumerable<ComponetListingModel>> AllAsync()
            => await this._db.Components.ProjectTo<ComponetListingModel>().ToListAsync();

      public async Task<ComponentAddModel> ComponentById(int id)
               => await this._db.Components.Where(s=>s.Id == id ).ProjectTo<ComponentAddModel>().FirstOrDefaultAsync();

      public void DeleteComponent(int id)
      {
         if (id !=0)
         {
            var component = this._db.Components.Find(id);

            this._db.Components.Remove(component);
            this._db.SaveChanges();
         }
      }
   }
}
