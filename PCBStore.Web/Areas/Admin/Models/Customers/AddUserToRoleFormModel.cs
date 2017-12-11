namespace PCBStore.Web.Areas.Admin.Models.Customers
{
   using System.ComponentModel.DataAnnotations;

   public class AddUserToRoleFormModel
   {
      [Required]
      public string UserId { get; set; }

      [Required]
      public string Role { get; set; }
   }
}
