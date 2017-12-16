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
   using static WebConstants;


   [Area(NewsArea)]
   [Authorize(Roles = ModeratorRole)]
   public class NewsController : Controller
   {
      private readonly IHtmlService _html;

      private readonly UserManager<Customer> _customers;

      private readonly INewsArticleService _newsArticles;

      public NewsController(IHtmlService html, UserManager<Customer> customers, INewsArticleService newsArticles)
      {
         this._html = html;
         this._newsArticles = newsArticles;
         this._customers = customers;
      }

      [ValidateModelState]
      [Route("[action]")]
      public IActionResult Create() => View();

      [AllowAnonymous]
      [Route("[action]")]
      public async Task<IActionResult> Index(int page = 1)
      {
         return View(new NewsListingModel()
         {
            Articles = await this._newsArticles.AllAsync(page),
            TotalArticles = await this._newsArticles.TotalAsyncArticles(),
            CurrentPage = page
         });
         //return View();
      }

      [Route("[action]")]
      [HttpPost]
      [ValidateModelState]
      public async Task<IActionResult> Create(NewsArticleCreatingModel model)
      {
         model.Content = this._html.Sanitize(model.Content);

         var userId = _customers.GetUserId(User);

         await this._newsArticles.CreateAsync(model.Title, model.Content, userId);

         return RedirectToAction(nameof(Index));

      }

      [AllowAnonymous]
      public async Task<IActionResult> Details(int id)
         => this.ViewOrNotFound(await this._newsArticles.ArticleDetails(id));


   }
}
