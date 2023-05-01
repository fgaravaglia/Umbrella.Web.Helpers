using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace Umbrella.UI.Web.MVC.Helpers
{
    public static class IBootstrapHtmlHelperExtensions
    {
        /// <summary>
        /// Renders the html on MVC Page
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="ctrlId"></param>
        /// <returns></returns>
        public static IHtmlContent Render(this IBootstrapHtmlHelper helper, string ctrlId)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));

            var innerHtml = helper.BuildHtml(ctrlId);
            return new HtmlString(innerHtml);
        }
    }
}