using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public static class BoxHelperExtensions
    {
        public static IHtmlContent RenderForSmallBox(string htmlTitle, string caption, string url, string iconCssClass, string ctrlID = "")
        {
            return RenderForSmallBox(htmlTitle, caption, url, new BootstrapBackground().AsSuccess(), iconCssClass, ctrlID);
        }

        public static IHtmlContent RenderForSmallBox(string htmlTitle, string caption, string url, string cssClass, string iconCssClass,string ctrlID = "")
        {
            var helper = new BoxHelper();
            helper.Small();
            helper.SetHtmlForTitle(htmlTitle, caption);
            helper.SetCssClass(cssClass);
            helper.SetCssIconClass(iconCssClass);
            helper.LinkedTo(url);
            return helper.Render(ctrlID);
        }
    }
}