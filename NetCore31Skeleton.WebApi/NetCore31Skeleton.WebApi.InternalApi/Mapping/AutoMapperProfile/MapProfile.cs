using AutoMapper;
using NetCore31Skeleton.WebApi.Core.Dtos;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
