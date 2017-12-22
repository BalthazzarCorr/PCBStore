namespace PCBStore.Test
{
   using System;
   using Data;
   using FluentAssertions;
   using Microsoft.EntityFrameworkCore;
   using Xunit;

  
   public class ArticleServiceTest
   {
      [Fact]
      public void SomeTest()
      {

      }


      private PcbStoreDbContext GetDatabase()
      {
         var dbOptions = new DbContextOptionsBuilder<PcbStoreDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

         return new PcbStoreDbContext(dbOptions);
      }
   }
}
