namespace PCBStore.Services.News.Implementations
{
   using System;
   using System.Threading.Tasks;
   using Data;
   using Data.Models;
   using Models;

   public class NewsArticleService: INewsArticleService
   {

      private readonly PcbStoreDbContext _db;

      public NewsArticleService(PcbStoreDbContext db)
      {
         this._db = db;
      }

      public async Task CreateAsync(string title, string content, string authorId)
      {

         var article = new NewsArticle
         {
            Content = content,
            Title = title,
            AuthorId = authorId,
            PublishDate = DateTime.UtcNow,
         };

         this._db.Add(article);

         await this._db.SaveChangesAsync();
      }

      public async Task<ArticleDetailsModel> ArticleDetails(int id)
         => null;/*await this._db.Articles.Where(a => a.Id == id).ProjectTo<ArticleDetailsModel>().FirstOrDefaultAsync();
*/

      public Task<int> TotalAsyncArticles()
      {
         //throw new System.NotImplementedException();
         return null;
      }
   }
}
