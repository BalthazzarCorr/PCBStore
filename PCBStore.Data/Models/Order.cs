namespace PCBStore.Data.Models
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using static  DataConstants;

   public class Order
   {
      public int Id { get; set; }

      public string CustomerId { get; set; }

      public decimal TotalPrice { get; set; }

      public Customer Customer { get; set; }

      public ICollection<OrderComponents> Components { get; set; } = new List<OrderComponents>();

      [MaxLength(SchematicAndPcbFileLength)]
      public byte[] Schematic { get; set; }


   }
}
