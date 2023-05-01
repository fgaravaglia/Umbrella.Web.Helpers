using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    /// <summary>
    /// Helper to build and render a breadcrumb
    /// </summary>

    public class BreadcrumbHelper : IBootstrapHtmlHelper
    {
        readonly List<string> _Lines;

        /// <summary>
        /// Default Constr
        /// </summary>
        public BreadcrumbHelper()
        {
            this._Lines = new List<string>();
        }

        /// <summary>
        /// Adds a page to navigator
        /// </summary>
        /// <param name="displayTitle"></param>
        /// <param name="isActive"></param>
        /// <param name="url"></param>
        public void AddPage(string displayTitle, bool isActive = false, string url = "")
        {
            if (string.IsNullOrEmpty(displayTitle))
                throw new ArgumentNullException(nameof(displayTitle));

            var active = isActive ? "active" : "";
            var href = string.IsNullOrEmpty(url) ? "" : $"href=\"{url}\"";
            var html = $"<li class=\"breadcrumb-item {active}\"><a {href}>{displayTitle}</a></li>";
            this._Lines.Add(html);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="ctrlId"></param>
        /// <returns></returns>
        public string BuildHtml(string ctrlId = "")
        {
            //  <ol class="breadcrumb float-sm-right">
            //             <li class="breadcrumb-item"><a href="#">Admin Tool</a></li>
            //             <li class="breadcrumb-item"><a>Security</a></li>
            //             <li class="breadcrumb-item active">@Model.CurrentNavigatorPageTitle</li>
            //  </ol>
            var html = new StringBuilder();
            html.AppendLine("<ol class=\"breadcrumb float-sm-right\">");
            this._Lines.ForEach(l => html.AppendLine("  " + l));
            html.AppendLine("</ol>");
            return html.ToString();
        }
    }
}