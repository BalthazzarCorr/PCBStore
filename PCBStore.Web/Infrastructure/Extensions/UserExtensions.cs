namespace PCBStore.Web.Infrastructure.Extensions
{
   using System.Security.Claims;

   public static class UserExtensions
   {
      public static string GetUserId(this ClaimsPrincipal user)
      {
         if (!user.Identity.IsAuthenticated)
            return null;

         ClaimsPrincipal currentUser = user;
         return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
      }
   }
}
