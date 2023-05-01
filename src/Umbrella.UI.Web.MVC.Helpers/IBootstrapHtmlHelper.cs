using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    /// <summary>
    /// Abstraction of Bootstrp component helper
    /// </summary>
    public interface IBootstrapHtmlHelper
    {
        /// <summary>
        /// BUdile the HTML for the specific control
        /// </summary>
        /// <param name="ctrlId"></param>
        /// <returns></returns>
        string BuildHtml(string ctrlId = "");
    }
}