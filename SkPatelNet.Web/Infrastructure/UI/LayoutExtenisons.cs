using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkPatelNet.Web.Infrastructure.UI
{
    public static class LayoutExtenisons
    {

        public static void AddTitleParts(this IHtmlHelper html, string title )
        {
            var pageHeader = "This is the page header";
            html.Encode(title);
           
        }

        public static void AppendTitleParts(this IHtmlHelper html, string part)
        {
            //
        }

        public static IHtmlContent SKPatelTitle(this IHtmlHelper html, bool addDefaultTitle=true, string part="")
        {
            html.AppendTitleParts("no data");
            return new HtmlString(html.Encode("SK Patel Home page"));
        }
    }
}
