using CursoCoreAlura.Web.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CursoCoreAlura.Web.TagHelpers
{
    public class ItemPedidoResumoTagHelper : TagHelper
    {
        public ItemPedido Item { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent($@"
                <h3>{Item.Produto.Nome}</h3>
                <p>{Item.Quantidade}x{Item.PrecoUnitario} {Item.SubTotal}</p>
                ");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
