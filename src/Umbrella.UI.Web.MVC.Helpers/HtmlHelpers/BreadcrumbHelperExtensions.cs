using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    /// <summary>
    /// Extensions to build fluently syntax to Html component
    /// </summary>
    public static class BreadcrumbHelperExtensions
    {
        /// <summary>
        /// Adds a page but not active
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static BreadcrumbHelper AddNotActivePage(this BreadcrumbHelper helper, string title, string pageUrl = "")
        {
            helper.AddPage(title, false, pageUrl);
            return helper;
        }
        /// <summary>
        /// Adds a page as active one
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title"></param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static BreadcrumbHelper AddActivePage(this BreadcrumbHelper helper, string title, string pageUrl = "")
        {
            helper.AddPage(title, true, pageUrl);
            return helper;
        }
    }
}