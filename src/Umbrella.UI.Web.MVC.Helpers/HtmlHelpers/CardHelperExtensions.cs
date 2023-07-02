using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public static class CardHelperExtensions
    {
        public static CardHelper WithDangerBadge(this CardHelper helper, string text)
        {
            helper.SetBadge(text, "bg-danger");
            return helper;
        }

        public static IHtmlContent RenderCardHeader(this CardHelper helper)
        {
            var innerHtml = helper.BuildHtml("");
            return new HtmlString(innerHtml);
        }

        public static IHtmlContent RenderCardHeader(string title)
        {
            return new CardHelper(title).RenderCardHeader();
        }
    }
}