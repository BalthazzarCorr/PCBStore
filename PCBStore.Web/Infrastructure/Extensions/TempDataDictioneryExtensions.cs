

namespace PCBStore.Web.Infrastructure.Extensions
{
   using Microsoft.AspNetCore.Mvc.ViewFeatures;

  

   public static class TempDataDictioneryExtensions
   {
      public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
      {
         tempData[TempDataSuccessMessageKey] = message;
      }
   }
}
}
