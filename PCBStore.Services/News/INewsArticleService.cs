using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBStore.Services.News
{
   using Models;

   public interface INewsArticleService
    {
      Task CreateAsync(string title, string content, string authorId);

       Task<ArticleDetailsModel> ArticleDetails(int id);

       Task<int> TotalAsyncArticles();

       Task<IEnumerable<ArticleListingModel>> AllAsync(int page = 1);
   }
}
