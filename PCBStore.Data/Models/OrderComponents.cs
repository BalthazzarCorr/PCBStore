namespace PCBStore.Data.Models
{
   using System.ComponentModel.DataAnnotations;
   using static DataConstants;

   public class OrderComponents
    {
       public  int OrderId { get; set; }

       public Order Order { get; set; }


       public int ComponentId { get; set; }

       public Component Component { get; set; }

       [MaxLength(SchematicAndPcbFileLength)]
       public byte[] Schematic { get; set; }
   }
}
