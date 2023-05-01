using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public static class TextBoxHelperExtensions
    {
        public static IHtmlContent RenderTextBoxFor(string id, string text)
        {
            return new TextBoxHelper(id).WithValue(text).Render(id);
        }

        public static IHtmlContent RenderReadonlyTextBoxFor(string id, string text)
        {
            return new TextBoxHelper(id).ReadOnly().WithValue(text).Render(id);
        }

        public static IHtmlContent RenderReadonlyTextAreaFor(string id, string text)
        {
            return new TextBoxHelper(id).ReadOnly().AsTextArea().WithValue(text).Render(id);
        }
    }
}