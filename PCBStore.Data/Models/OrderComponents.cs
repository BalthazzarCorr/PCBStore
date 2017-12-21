namespace PCBStore.Data.Models
{
   public class OrderComponents
   {
      public int Id { get; set; }

      public int OrderId { get; set; }

      public Order Order { get; set; }

      public int ComponentId { get; set; }

      public Component Component { get; set; }

      public decimal ComponentPrice { get; set; }

      public int Quantity { get; set; }

   }
}
