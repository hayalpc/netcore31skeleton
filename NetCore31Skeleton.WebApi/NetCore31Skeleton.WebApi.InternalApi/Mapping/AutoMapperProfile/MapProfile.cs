using AutoMapper;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.InternalApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<NoteDto, Note>();
            CreateMap<Note, NoteDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto, AppUser>();
        }
    }
}
