using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using NetCore31Skeleton.WebApi.Core.Dtos;
using NetCore31Skeleton.WebApi.InternalApi.Filters;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomException]
    [CustomValidate]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache cache;
        private readonly IMapper mapper;

        public ValuesController(IMemoryCache cache, IMapper mapper)
        {
            this.cache = cache;
            this.mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Test")]
        public TestDto Test(TestDto testDto)
        {
            return testDto;
        }

        [HttpGet("Mapper")]
        public CategoryDto Mapper()
        {
            var category = new Category
            {
                Title = "Test"
            };
            var categoryDto = mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        [HttpGet("Mappers")]
        public List<CategoryDto> Mappers()
        {
            var categories = new List<Category>();
            categories.Add(new Category{Title = "Test"});
            categories.Add(new Category{Title = "Test2"});
            categories.Add(new Category{Title = "Test3"});

            var categoryDtos = mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            //var bytes = await System.IO.File.ReadAllBytesAsync(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();
            var byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            var formData = new MultipartFormDataContent();
            formData.Add(byteArrayContent, "file", file.FileName);


            var newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "www/documents/" + newFileName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return Ok();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
