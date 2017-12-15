namespace PCBStore.Web.Infrastructure.Extensions
{
   using Microsoft.AspNetCore.Mvc.ViewFeatures;
   using static  WebConstants;
  

   public static class TempDataDictioneryExtensions
   {
      public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
      {
         tempData[TempDataSuccessMessageKey] = message;
      }


      public static void ErrorMessage(this ITempDataDictionary tempData, string message)
      {
         tempData[TempDataErrorMessageKey] = message;
      }
   }
}

