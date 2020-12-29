using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Entities;
using Books.Api.ExternalModels;
using Books.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Api.Filters
{
    public class BookWithCoversResultFilterAttribute : ResultFilterAttribute
    {
        public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result == null || result.StatusCode < 200 || result.StatusCode >= 300)
            {
                await next();

                return;
            }

            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();

            var (book, bookCovers) = ((Book, IEnumerable<BookCover>))result.Value;

            var bookWithCover = mapper.Map<BookWithCoverDto>(book);

            result.Value = mapper.Map(bookCovers, bookWithCover);

            await next();
        }
    }
}
