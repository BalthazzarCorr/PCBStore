namespace PCBStore.Services.News
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Models;

   public interface ICommentService
   {
      void CreateAsync(string content, string authorId,int articleId);

      Task<IEnumerable<CommentsListingModel>> AllAsync(int articleId);
   }
}
