namespace PCBStore.Data.Models
{
   using System;
   using System.ComponentModel.DataAnnotations;

   public class Comment
   {
      public int Id { get; set; }

      public string AuthorId { get; set; }

      public Customer Author { get; set; }

      public int ArticleId { get; set; }
      
      [Required]
      [MaxLength(10000)]
      public string Content { get; set; }

      public DateTime PublishDate { get; set; }
   }
}
