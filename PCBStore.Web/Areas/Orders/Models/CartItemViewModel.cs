namespace PCBStore.Web.Areas.Orders.Models
{
   public class CartItemViewModel
   {

      public int Id { get; set; }

      public string Name { get; set; }

      public decimal Price { get; set; }

      public int Quantity { get; set; }

      public string Description { get; set; }

      public string ImgAddress { get; set; }

   }
}
