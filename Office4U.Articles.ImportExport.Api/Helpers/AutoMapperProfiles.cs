using System.Linq;
using AutoMapper;
using Office4U.Articles.ImportExport.Api.Controllers.DTOs.AppUser;
using Office4U.Articles.ImportExport.Api.Controllers.DTOs.Article;
using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, AppUserDto>();

            CreateMap<Article, ArticleDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ArticlePhoto, ArticlePhotoDto>();
            CreateMap<ArticleUpdateDto, Article>();
            CreateMap<ArticleForCreationDto, Article>();
            CreateMap<Article, ArticleForReturnDto>();

            CreateMap<RegisterDto, AppUser>();
        }
    }
}