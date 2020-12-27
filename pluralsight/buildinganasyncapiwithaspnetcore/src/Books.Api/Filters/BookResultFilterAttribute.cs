using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Api.Filters
{
    public class BookResultFilterAttribute : ResultFilterAttribute
    {
        public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result == null || result.StatusCode < 200 || result.StatusCode >= 300)
            {
                await next.Invoke();

                return;
            }

            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();

            result.Value = mapper.Map<BookDto>(result.Value);

            await next.Invoke();
        }
    }
}
