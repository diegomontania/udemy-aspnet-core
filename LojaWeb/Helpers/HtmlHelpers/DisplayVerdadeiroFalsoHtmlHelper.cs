using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaWeb.Helpers.HtmlHelpers
{
    public static class DisplayVerdadeiroFalsoHtmlHelper
    {
		//Metodo que retorna um conteudo html, provavelmente um elemento
		public static IHtmlContent DisplayTrueFalse(bool valueBoolean)
		{
			//cria um objeto TagBuilder de HTML
			var span = new TagBuilder("span");

			//Dependendo do valor da bolean, cria um estilo CSS deste elemento
			//e adiciona uma classe CSS.
			if (valueBoolean)
			{
				span.AddCssClass("badge badge-success");
				span.InnerHtml.Append("Verdadeiro");
			}
			else
			{
				span.AddCssClass("badge badge-danger");
				span.InnerHtml.Append("Falso");
			}

			return span;
		}
	}
}
