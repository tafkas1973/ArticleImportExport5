using System.Linq;
using AutoMapper;
using Office4U.Articles.ImportExport.Api.DTOs;
using Office4U.Articles.ImportExport.Api.Entities;

namespace Office4U.Articles.ImportExport.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, AppUserDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<AppUserPhoto, UserPhotoDto>();

            CreateMap<Article, ArticleDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<ArticlePhoto, ArticlePhotoDto>();
        }
    }
}