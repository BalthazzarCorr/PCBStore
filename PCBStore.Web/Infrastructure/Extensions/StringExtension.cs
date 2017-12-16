namespace PCBStore.Web.Infrastructure.Extensions
{
   using System.Text.RegularExpressions;

   public static class StringExtension
   {
      public static string ToFriendlyUrl(this string text)
         => Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();
   }
}
