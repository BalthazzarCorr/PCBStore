namespace PCBStore.Services.News.Models
{
   using System;
   using System.Collections.Generic;
   using AutoMapper;
   using Common.Mapping;
   using Data.Models;

   public class ArticleDetailsModel : IMapFrom<NewsArticle>, IHaveCustomMapping
   {
      public int Id { get; set; }

      public string Title { get; set; }

      public string Content { get; set; }

      public DateTime PublishDate { get; set; }

      public string Author { get; set; }

      public string AuthorId { get; set; }

      public void ConfigureMapping(Profile mapper)
         => mapper.CreateMap<NewsArticle, ArticleDetailsModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
   }
}
