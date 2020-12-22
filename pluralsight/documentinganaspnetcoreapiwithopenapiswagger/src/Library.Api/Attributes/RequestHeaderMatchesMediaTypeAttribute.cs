using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Library.Api.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequestHeaderMatchesMediaTypeAttribute : Attribute, IActionConstraint
    {
        private readonly MediaTypeCollection _mediaTypeCollection;

        private readonly string _requestHeaderToMatch;

        public RequestHeaderMatchesMediaTypeAttribute(string requestHeaderToMatch, string mediaType, params string[] otherMediaTypes)
        {
            _mediaTypeCollection = new MediaTypeCollection();

            _requestHeaderToMatch = requestHeaderToMatch;

            if (MediaTypeHeaderValue.TryParse(mediaType, out var parsedMediaType)) _mediaTypeCollection.Add(parsedMediaType);

            foreach (var it in otherMediaTypes)
            {
                if (MediaTypeHeaderValue.TryParse(mediaType, out var otherParsedMediaType)) _mediaTypeCollection.Add(otherParsedMediaType);
            }
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestHeaders = context.RouteContext.HttpContext.Request.Headers;

            if (!requestHeaders.ContainsKey(_requestHeaderToMatch))
            {
                return false;
            }

            var mediaType = new MediaType(requestHeaders[_requestHeaderToMatch]);

            return _mediaTypeCollection.Any(it => new MediaType(it).Equals(mediaType));
        }
    }
}
