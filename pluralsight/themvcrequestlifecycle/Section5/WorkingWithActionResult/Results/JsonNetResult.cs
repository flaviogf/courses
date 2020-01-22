using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Mvc;

namespace WorkingWithActionResult.Results
{
    public class JsonNetResult : ActionResult
    {
        private readonly object _data;

        public JsonNetResult(object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(JsonConvert.SerializeObject(_data, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}