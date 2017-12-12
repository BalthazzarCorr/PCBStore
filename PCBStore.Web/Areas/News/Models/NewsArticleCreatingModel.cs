namespace PCBStore.Web.Areas.News.Models
{
   using System;
   using System.ComponentModel.DataAnnotations;
   using static Data.DataConstants;

   public class NewsArticleCreatingModel
    {
      [Required]
       [MinLength(ArticleTitleMinLenght)]
       [MaxLength(ArticleTileMaxLenght)]
       public string Title { get; set; }

       [Required]
       public string Content { get; set; }

       [DataType(DataType.Date)]
       public DateTime PublishDate { get; set; }
   }
}
