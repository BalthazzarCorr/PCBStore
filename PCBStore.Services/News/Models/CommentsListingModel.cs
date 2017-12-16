namespace PCBStore.Services.News.Models
{
   using System;
   using AutoMapper;
   using Common.Mapping;
   using Data.Models;
    public class CommentsListingModel : IMapFrom<Comment>,IHaveCustomMapping
    {
       public int Id { get; set; }

       public string Author { get; set; }

       public string Content { get; set;}

       public DateTime PublishDate { get; set; }

      public void ConfigureMapping(Profile mapper)
          => mapper.CreateMap<Comment, CommentsListingModel>()
             .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
