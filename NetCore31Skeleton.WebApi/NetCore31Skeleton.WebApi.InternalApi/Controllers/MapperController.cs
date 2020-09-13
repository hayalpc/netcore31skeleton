using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.WebApi.Core.Dtos;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly IMapper mapper;

        public MapperController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }

        [Route("/mapper")]
        [HttpPost]
        public IActionResult Get(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);

            return Ok(mapper.Map<CategoryDto>(category));
        }
    }
}
