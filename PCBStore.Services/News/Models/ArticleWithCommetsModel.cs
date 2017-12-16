namespace PCBStore.Services.News.Models
{
   using System.Collections.Generic;

   public class ArticleWithCommetsModel
    {
       public ArticleDetailsModel ArticleDetails { get; set; }

       public IEnumerable<CommentsListingModel> Comments { get; set; }
    }
}
