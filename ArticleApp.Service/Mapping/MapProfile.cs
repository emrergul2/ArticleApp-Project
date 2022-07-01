using ArticleApp.Core.DTOs;
using ArticleApp.Core.Models;
using AutoMapper;

namespace ArticleApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Article, ArticleInsertDto>().ReverseMap();
            CreateMap<Article, ArticleWithAuthorAndCategoryDto>().ReverseMap();
        }
    }
}