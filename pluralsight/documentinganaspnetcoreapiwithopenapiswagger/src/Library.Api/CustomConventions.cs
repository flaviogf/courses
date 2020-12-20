using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Library.Api
{
    public static class CustomConventions
    {
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public static void Insert([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any), ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)] object value)
        {
        }
    }
}
