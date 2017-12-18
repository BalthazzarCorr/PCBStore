﻿namespace PCBStore.Data
{
   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class PcbStoreDbContext : IdentityDbContext<Customer>
   {
      public PcbStoreDbContext(DbContextOptions<PcbStoreDbContext> options)
          : base(options)
      {
      }

      public DbSet<NewsArticle> NewsArticles { get; set; }
      public DbSet<Comment> Comments { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<Component> Components { get; set; }


      protected override void OnModelCreating(ModelBuilder builder)
      {


         builder
            .Entity<NewsArticle>()
            .HasOne(c => c.Author)
            .WithMany(c => c.NewsArticles)
            .HasForeignKey(c => c.AuthorId);

         builder
            .Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.AuthorId);

         builder.Entity<Order>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(c => c.CustomerId);

         builder.Entity<OrderComponents>()
            .HasKey(st => new {st.OrderId, st.ComponentId});

         builder.Entity<OrderComponents>()
            .HasOne(o => o.Order)
            .WithMany(c => c.Components)
            .HasForeignKey(c => c.ComponentId);

         builder.Entity<OrderComponents>()
            .HasOne(c => c.Component)
            .WithMany(o => o.Orders)
            .HasForeignKey(c => c.ComponentId);
         

         base.OnModelCreating(builder);
         // Customize the ASP.NET Identity model and override the defaults if needed.
         // For example, you can rename the ASP.NET Identity table names and more.
         // Add your customizations after calling base.OnModelCreating(builder);
      }
   }
}
