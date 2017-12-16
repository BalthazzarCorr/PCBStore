namespace PCBStore.Web.Areas.News.Models
{
   using System;
   using System.Collections.Generic;
   using Services;
   using Services.News.Models;

   public class NewsListingModel
   {
      public IEnumerable<ArticleListingModel> Articles { get; set; }

      public int TotalArticles { get; set; }

      public int TotalPages => (int)Math.Ceiling(((double) this.TotalArticles / ServicesConstants.NewssArticlesPageSize));

      public int CurrentPage { get; set; }

      public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

      public int NextPage => this.CurrentPage == this.TotalPages ? TotalPages : this.CurrentPage + 1;

   }
}
