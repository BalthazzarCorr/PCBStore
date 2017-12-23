namespace PCBStore.Test.Web.Controllers
{
   using System.Linq;
   using Microsoft.AspNetCore.Authorization;
   using PCBStore.Web.Areas.Orders.Controllers;
   using Xunit;
   using FluentAssertions;

   public class OrderControllerTest
   {
      [Fact]
      public void FinishOrderShouldBeForAuthorizedUsers()
      {
         //Arrange
         var method = typeof(OrdersController).GetMethod(nameof(OrdersController.FinishOrder));
         //Act
         var attribute = method.GetCustomAttributes(true);
         //Assert
         attribute.Should().Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));

      }


      [Fact]
      public void UploadingOfFilesShouldBeForAuthorizedUsers()
      {
         //Arrange
         var method = typeof(OrdersController).GetMethod(nameof(OrdersController.UploadSchematics));
         //Act
         var attribute = method.GetCustomAttributes(true);
         //Assert
         attribute.Should().Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));

      }

   }
}
