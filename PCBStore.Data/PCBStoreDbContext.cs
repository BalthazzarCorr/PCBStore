namespace PCBStore.Data
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

      protected override void OnModelCreating(ModelBuilder builder)
      {


         builder.Entity<NewsArticle>().HasOne(c => c.Author).WithMany(c => c.NewsArticles).HasForeignKey(c => c.AuthorId);


         base.OnModelCreating(builder);
         // Customize the ASP.NET Identity model and override the defaults if needed.
         // For example, you can rename the ASP.NET Identity table names and more.
         // Add your customizations after calling base.OnModelCreating(builder);
      }
   }
}
