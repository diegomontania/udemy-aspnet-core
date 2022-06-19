using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LojaWeb.Helpers.TagHelpers
{
	//a tag precisa ser adiciona a referencia no arquivo '_ViewImports.cshtml'

	//aqui a classe não precisa ser 'static', porem precisa extender 'TagHelper'
	[HtmlTargetElement("nome-pessoa")] /*nome da tag utilizada no HTML*/
	public class DisplayVerdadeiroFalsoTagHelper : TagHelper
    {
		//a tag helper tambem pode ter propriedades, mas nao obrigatorio
		public string Nome { get; set; }

		//Metodo que retorna um conteudo html, provavelmente um elemento
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var span = new TagBuilder("span");
			span.AddCssClass("badge badge-info");
			span.InnerHtml.Append($"{Nome} vindo do tag helper!");

			output.Content.AppendHtml(span);
		}
	}
}
