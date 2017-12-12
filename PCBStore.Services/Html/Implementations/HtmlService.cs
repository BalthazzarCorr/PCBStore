namespace PCBStore.Services.Html.Implementations
{
   using Ganss.XSS;

   public class HtmlService : IHtmlService
   {
      private readonly HtmlSanitizer _htmlSanitizer;

      public HtmlService()
      {
         this._htmlSanitizer = new HtmlSanitizer();
         this._htmlSanitizer.AllowedAttributes.Add("class");
      }

      public string Sanitize(string htmlContent)
         => this._htmlSanitizer.Sanitize(htmlContent);
   }
}
