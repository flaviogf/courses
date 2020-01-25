using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace TheCodeCamp.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.AddApiVersioning(it =>
            {
                it.AssumeDefaultVersionWhenUnspecified = true;
                it.DefaultApiVersion = new ApiVersion(1, 1);
                it.ReportApiVersions = true;
                it.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            });

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}