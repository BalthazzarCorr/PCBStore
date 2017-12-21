namespace PCBStore.Services.News.Implementations
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Microsoft.EntityFrameworkCore;
   using Models;
   using static ServicesConstants;

   public class NewsArticleService : INewsArticleService
   {

      private readonly PcbStoreDbContext _db;

      public NewsArticleService(PcbStoreDbContext db)
      {
         this._db = db;
      }


      public async Task<IEnumerable<ArticleListingModel>> AllAsync(int page = 1) => await this._db
         .NewsArticles
         .OrderByDescending(a => a.PublishDate)
         .Skip((page - 1) * NewssArticlesPageSize)
         .Take(NewssArticlesPageSize)
         .ProjectTo<ArticleListingModel>()
         .ToListAsync();


      public void UpdateArticle(ArticleDetailsModel model)
      {
         var article = this._db.NewsArticles.Find(model.Id);
         article.Id = model.Id;
         article.AuthorId = model.AuthorId;
         article.Content = model.Content;
         article.PublishDate = DateTime.UtcNow;
         article.Title = model.Title;


         this._db.NewsArticles.Update(article);
         this._db.SaveChanges();
      }

      public void DeleteArticle(int id)
      {
         var article = this._db.NewsArticles.Find(id);

         if (article != null)
         {
            this._db.NewsArticles.Remove(article);
            this._db.SaveChanges();
         }
      }

      public async Task<IEnumerable<CommentsListingModel>> AllCommentsForArticle(int articleId)=> await this._db.Comments
         .Where(c => c.ArticleId == articleId)
         .OrderByDescending(a => a.PublishDate)
         .Take(ComentsPageSize)
         .ProjectTo<CommentsListingModel>()
         .ToListAsync();

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
         => await this._db.NewsArticles.Where(a => a.Id == id).ProjectTo<ArticleDetailsModel>().FirstOrDefaultAsync();


      public async Task<int> TotalAsyncArticles()
               => await this._db.NewsArticles.CountAsync();


   }
}
