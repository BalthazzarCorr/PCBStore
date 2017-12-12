namespace PCBStore.Web.Areas.News.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Filters;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using Services.Html;
   using Services.News;
   using static WebConstants;

   public class NewsController : Controller
   {
      [Area(BlogArea)]
      [Authorize(Roles = BlogAuthorRole)]
      public class ArticlesController : Controller
      {
         public readonly IHtmlService _html;

         public readonly UserManager<Customer> _customers;

         public readonly INewsArticleService _newsArticles;

         public ArticlesController(IHtmlService html, UserManager<Customer> customers, INewsArticleService newsArticles)
         {
            this._html = html;
            this._newsArticles = newsArticles;
            this._customers = customers;
         }

         [ValidateModelState]
         public IActionResult Create() => View();

         [AllowAnonymous]
         public async Task<IActionResult> Index(int page = 1)
         {
            //return View(new NewsListingModel()
            //{
            //   Articles = await this._articles.AllAsync(page),
            //   TotalArticles = await this._articles.TotalAsyncArticles(),
            //   CurrentPage = page
            //});
            return View();
         }

         //[HttpPost]
         //[ValidateModelState]
         //public async Task<IActionResult> Create(PublishArticleFormModel model)
         //{
         //   model.Content = this._html.Sanitize(model.Content);

         //   var userId = _users.GetUserId(User);

         //   await this._articles.CreateAsync(model.Title, model.Content, userId);

         //   return RedirectToAction(nameof(Index));

         //}

         //[AllowAnonymous]
         //public async Task<IActionResult> Details(int id)
         //   => this.ViewOrNotFound(await this._articles.ArticleDetails(id));


      }
   }
}