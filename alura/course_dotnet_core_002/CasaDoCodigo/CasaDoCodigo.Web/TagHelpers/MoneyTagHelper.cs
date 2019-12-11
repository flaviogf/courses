using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace CasaDoCodigo.Web.TagHelpers
{
    public class MoneyTagHelper : TagHelper
    {
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            var child = await output.GetChildContentAsync();

            int.TryParse(child.GetContent(), out var value);

            var formatted = (value / 100).ToString("C");

            output.Content.SetContent(formatted);
        }
    }
}
