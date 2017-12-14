

namespace PCBStore.Services.News.Models
{
   using System;
   using AutoMapper;
   using Common.Mapping;
   using Data.Models;

   public class ArticleDetailsModel : IMapFrom<NewsArticle>, IHaveCustomMapping
   {
      public string Title { get; set; }


      public string Content { get; set; }

      public DateTime PublishDate { get; set; }

      public string Author { get; set; }


      public void ConfigureMapping(Profile mapper)
         => mapper.CreateMap<NewsArticle, ArticleDetailsModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
   }
}
