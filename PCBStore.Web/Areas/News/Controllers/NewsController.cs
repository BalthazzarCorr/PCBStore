namespace PCBStore.Web.Areas.News.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Infrastructure.Filters;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using Services.Html;
   using Services.News;
   using Services.News.Models;
   using static WebConstants;

   
   [Area(NewsArea)]
   [Authorize(Roles = ModeratorRole + "," + AdministratorRole)]
   public class NewsController : Controller
   {
      private readonly IHtmlService _html;

      private readonly UserManager<Customer> _customers;

      private readonly INewsArticleService _newsArticles;

      private readonly ICommentService _comments;


      public NewsController(IHtmlService html, UserManager<Customer> customers, INewsArticleService newsArticles,
         ICommentService comments)
      {
         this._html = html;
         this._newsArticles = newsArticles;
         this._customers = customers;
         this._comments = comments;
      }

      [ValidateModelState]
      [Route("[controller]/[action]")]
      public IActionResult Create() => View();

      [AllowAnonymous]
      public async Task<IActionResult> Index(int page = 1)
      {
         return View(new NewsListingModel()
         {
            Articles = await this._newsArticles.AllAsync(page),
            TotalArticles = await this._newsArticles.TotalAsyncArticles(),
            CurrentPage = page
         });

      }


      [HttpPost]
      [ValidateModelState]
      public async Task<IActionResult> Create(NewsArticleCreatingModel model)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         model.Content = this._html.Sanitize(model.Content);

         var userId = _customers.GetUserId(User);

         await this._newsArticles.CreateAsync(model.Title, model.Content, userId);

         return RedirectToAction(nameof(Index));

      }

      [AllowAnonymous]
      public async Task<IActionResult> Details(int id)
      {
         var article = await this._newsArticles.ArticleDetails(id);
         var commets = await this._comments.AllAsync(id);

         return View(new ArticleWithCommetsModel
         {
            ArticleDetails = article,
            Comments = commets
         });
      }


      [HttpPost]
      [AllowAnonymous]
      public IActionResult Details([FromForm]string content, int articleId)
      {

         var authorId = _customers.GetUserId(User);

         var contentSanitaizet = this._html.Sanitize(content);


         if (authorId == null)
         {
            TempData.ErrorMessage($"You must be a registered customer to comment on articles");

            return RedirectToAction(nameof(Details), new { id = articleId });

         }

         if (string.IsNullOrEmpty(contentSanitaizet))
         {
            TempData.ErrorMessage($"Can`t write html or Js scripts here buddy");
            return RedirectToAction(nameof(Details), new { id = articleId });
         }

         this._comments.CreateAsync(contentSanitaizet, authorId, articleId);

         return RedirectToAction(nameof(Details), new { id = articleId });
      }

      
      [Route("[action]/{commentId}/{articleId}")]
      public IActionResult DeleteComment(int commentId,int articleId)
      {
        this._comments.DeleteAsync(commentId);

         return RedirectToAction(nameof(Details), new {id = articleId});
      }
   }
}
