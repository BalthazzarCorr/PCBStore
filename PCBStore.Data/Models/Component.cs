namespace PCBStore.Data.Models
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Common.Validation;
   using Enums;


   public class Component
   {
      public int Id { get; set; }

      public string Name { get; set; }

      [Description(ErrorMessage = "The description must be no more than 6000 symbols")]
      public string Description { get; set; }

      [Required]
      public ComponentType Type { get; set; }
      
      [Required]
      public ManufacturersEnum Manufacturer { get; set; }

      [Required]
      [Price(ErrorMessage = "Price is required and must be a positive number.")]
      public decimal Price { get; set; }

      public string UserId { get; set; }

      public Customer User { get; set; }

      public string ImgAddress { get; set; }
      
   }
}
