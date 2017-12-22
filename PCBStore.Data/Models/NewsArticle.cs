namespace PCBStore.Data.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using static DataConstants;

   public class NewsArticle
    {
      public int Id { get; set; }

       [Required]
       [MinLength(ArticleTitleMinLenght)]
       [MaxLength(ArticleTileMaxLenght)]
       public string Title { get; set; }

       [Required]
       [MaxLength(10000)]
       public string Content { get; set; }

       public DateTime PublishDate { get; set; }

       public string AuthorId { get; set; }

       public Customer Author { get; set; }

       public ICollection<Comment> Comments { get; set;} = new List<Comment>();


    }
}
