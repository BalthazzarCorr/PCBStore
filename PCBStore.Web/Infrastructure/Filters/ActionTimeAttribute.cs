namespace PCBStore.Web.Infrastructure.Filters
{
   using System;
   using System.Diagnostics;
   using System.IO;
   using Microsoft.AspNetCore.Mvc.Filters;

   public class ActionTimeAttribute : IActionFilter
    {
        private const string LoggingFilePath = "action-times.txt";
        private Stopwatch stopwatch;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();

            using (var sr = new StreamWriter(LoggingFilePath, true))
            {
                var date = DateTime.UtcNow;
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"];

                var log = $"{date} – {controller}.{action} – {stopwatch.Elapsed}";

                sr.WriteLine(log);
            }
        }
    }
}