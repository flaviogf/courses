using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Paladin.Web.Infra
{
    public class CSVResult : FileResult
    {
        private readonly IEnumerable<object> _data;

        public CSVResult(IEnumerable<object> data, string filename = "file.csv") : base("text/csv")
        {
            FileDownloadName = filename;
            _data = data;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var sb = new StringBuilder();

            var sw = new StringWriter(sb);

            foreach (var it in _data)
            {
                var properties = it.GetType().GetProperties();

                foreach (var property in properties)
                {
                    sw.Write(property.GetValue(it));
                    sw.Write(", ");
                }

                sw.WriteLine();
            }

            response.Write(sb);
        }
    }
}