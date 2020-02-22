using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkPatelNet.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Web.Framework.UI
{
    public static class LayoutExtensions
    {
        public static void AddTitleParts(this IHtmlHelper html, string title)
        {
            var pageHeader = "This is the page header";
            html.Encode(title);

        }

        public static void AppendTitleParts(this IHtmlHelper html, string part)
        {
            //
        }

        public static IHtmlContent SKPatelTitle(this IHtmlHelper html, bool addDefaultTitle = true, string part = "")
        {
            var pageHeadBuilder = EngineContext.Current.Resolve<IPageHeadBuilder>();
            html.AppendTitleParts(part);
            html.AppendTitleParts("no data");
            return new HtmlString(html.Encode(pageHeadBuilder.GenerateTitle(addDefaultTitle)));
        }
    }
}
