using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Models;
using CourseLibrary.Api.ResourceParameters;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CourseLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorResourceParameter authorResourceParameter)
        {
            var authors = _courseLibraryRepository.GetAuthors(authorResourceParameter);

            var result = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            var pagination = new
            {
                authors.TotalCount,
                authors.PageSize,
                authors.CurrentPage,
                authors.TotalPages
            };

            var metadata = JsonConvert.SerializeObject(pagination, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            Response.Headers.Add("X-Pagination", metadata);

            return Ok(result);
        }
    }
}
