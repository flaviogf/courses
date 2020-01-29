using System.Web.Mvc;
using System.Xml.Serialization;

namespace Paladin.Web.Infra
{
    public class XMLResult : ActionResult
    {
        private readonly object _data;

        public XMLResult(object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var serializer = new XmlSerializer(_data.GetType());

            var response = context.HttpContext.Response;

            response.ContentType = "application/xml";

            serializer.Serialize(response.Output, _data);
        }
    }
}