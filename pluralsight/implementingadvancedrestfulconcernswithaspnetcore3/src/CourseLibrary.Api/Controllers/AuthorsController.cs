using System;
using System.Collections.Generic;
using AutoMapper;
using CourseLibrary.Api.Entities;
using CourseLibrary.Api.Helpers;
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

        private readonly IPropertyMappingService _propertyMappingService;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper, IPropertyMappingService propertyMappingService)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
            _propertyMappingService = propertyMappingService;
        }

        [HttpGet(Name = "GetAuthors")]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors([FromQuery] AuthorResourceParameter authorResourceParameter)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<AuthorDto, Author>(authorResourceParameter.OrderBy))
            {
                return BadRequest();
            }

            var authors = _courseLibraryRepository.GetAuthors(authorResourceParameter);

            var result = _mapper.Map<IEnumerable<AuthorDto>>(authors).ShapeData(authorResourceParameter.Fields);

            var previousPageLink = authors.HasPrevious ? CreateAuthorsResourceUri(authorResourceParameter, ResourceUriType.PreviousPage) : null;

            var nextPageLink = authors.HasNext ? CreateAuthorsResourceUri(authorResourceParameter, ResourceUriType.NextPage) : null;

            var pagination = new
            {
                authors.TotalCount,
                authors.PageSize,
                authors.CurrentPage,
                authors.TotalPages,
                previousPageLink,
                nextPageLink,
            };

            var metadata = JsonConvert.SerializeObject(pagination, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            Response.Headers.Add("X-Pagination", metadata);

            return Ok(result);
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId, string fields)
        {
            var author = _courseLibraryRepository.GetAuthor(authorId);

            if (author == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<AuthorDto>(author).ShapeData(fields);

            return Ok(result);
        }

        private string CreateAuthorsResourceUri(AuthorResourceParameter authorResourceParameter, ResourceUriType resourceUriType) => resourceUriType switch
        {
            ResourceUriType.PreviousPage => Url.Link("GetAuthors", new
            {
                authorResourceParameter.MainCategory,
                authorResourceParameter.SearchQuery,
                PageNumber = authorResourceParameter.PageNumber - 1,
                authorResourceParameter.PageSize
            }),
            ResourceUriType.NextPage => Url.Link("GetAuthors", new
            {
                authorResourceParameter.MainCategory,
                authorResourceParameter.SearchQuery,
                PageNumber = authorResourceParameter.PageNumber + 1,
                authorResourceParameter.PageSize
            }),
            _ => Url.Link("GetAuthors", new
            {
                authorResourceParameter.MainCategory,
                authorResourceParameter.SearchQuery,
                authorResourceParameter.PageNumber,
                authorResourceParameter.PageSize
            })
        };

    }
}
