namespace PCBStore.Web.Areas.Admin.Models.Components
{
   using System.ComponentModel.DataAnnotations;
   using Data.Models.Enums;

   public class ComponentAddViewModel
   {

      [Required]
      [MaxLength(100)]
      public string Name { get; set; }

      [Required]
      [StringLength(6000)]
      public string Description { get; set; }

      [Required]
      public ComponentType Type { get; set; }

      [Required]
      public ManufacturersEnum Manufacturer { get; set; }

      public decimal Price { get; set; }

      public string ImgAddress { get; set; }

   }
}
