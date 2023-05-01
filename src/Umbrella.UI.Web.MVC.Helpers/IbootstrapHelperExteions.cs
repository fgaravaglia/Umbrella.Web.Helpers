using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.UI.Web.MVC.Helpers
{
    public static class IBootstrapHtmlHelperExtensions
    {
        /// <summary>
        /// Renders the html on MVC Page
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlContent Render(this IBootstrapHtmlHelper helper)
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));

            var innerHtml = helper.BuildHtml(ctrlId);
            return new HtmlString(innerHtml);
        }
    }
}