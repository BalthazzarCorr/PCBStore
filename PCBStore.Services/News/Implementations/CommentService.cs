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

   public class CommentService : ICommentService
   {
      private readonly PcbStoreDbContext _db;

      public CommentService(PcbStoreDbContext db)
      {
         this._db = db;
      }


      public void CreateAsync(string content, string authorId,int articleId)
      {
         var comment = new Comment
         {
            AuthorId = authorId,
            ArticleId = articleId,
            Content = content,
            PublishDate = DateTime.UtcNow

         };

         this._db.Add(comment);

         this._db.SaveChanges();
      }

      public async Task<IEnumerable<CommentsListingModel>> AllAsync(int articleId)
         => await this._db.Comments
            .OrderByDescending(d => d.PublishDate)
            .Where(c => c.ArticleId == articleId)
            .ProjectTo<CommentsListingModel>().ToListAsync();
   }
}
