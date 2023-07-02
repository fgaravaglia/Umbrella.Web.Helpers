using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public class BoxHelper : IBootstrapHtmlHelper
    {
        #region Fields
        bool _IsSmall = false;
        string _CssClass;

        string _Title;
        string _TitleInnerHtml;
        string _TitleCaption;

        string _IconClass;

        string _NavigateToUrl;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public BoxHelper()
        {
            this._CssClass = "";
            SetCssClass(new BootstrapBackground().AsSuccess());
            this._IconClass = "ion ion-stats-bars";
            this._Title = "";
            this._TitleInnerHtml = "";
            this._TitleCaption  ="";
            this._NavigateToUrl= "";
        }

        public void Small()
        {
            this._IsSmall = true;
        }
        /// <summary>
        /// Sets the class of Box
        /// </summary>
        /// <param name="cssClass"></param>
        public void SetCssClass(string cssClass)
        {
            if (String.IsNullOrEmpty(cssClass))
                throw new ArgumentNullException(nameof(cssClass));
            this._CssClass = cssClass;
        }
        /// <summary>
        /// Sets the title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="caption"></param>
        public void SetTitle(string title, string caption)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            this._Title = title;
            this._TitleCaption = caption;
        }
        /// <summary>
        /// Sets the title as inned Html for complex header
        /// </summary>
        /// <param name="html"></param>
        /// <param name="catpion"></param>
        public void SetHtmlForTitle(string html, string catpion)
        {
            if (String.IsNullOrEmpty(html))
                throw new ArgumentNullException(nameof(html));
            this._TitleInnerHtml = html;
            this._TitleCaption = catpion;
        }
        /// <summary>
        /// Sets the class of icon
        /// </summary>
        /// <param name="cssClass"></param>
        public void SetCssIconClass(string cssClass)
        {
            if (String.IsNullOrEmpty(cssClass))
                throw new ArgumentNullException(nameof(cssClass));
            if (!cssClass.ToLowerInvariant().StartsWith("ion ion-"))
                throw new ArgumentException(nameof(cssClass) + " must to start with ion ion-");
            this._IconClass = cssClass;
        }
        /// <summary>
        /// Sets the navigate to url
        /// </summary>
        /// <param name="url"></param>
        public void LinkedTo(String url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            this._NavigateToUrl = url;
        }

        string BuildHtmlForInner(string originalTab)
        {
            string title = string.IsNullOrEmpty(this._TitleInnerHtml) ? this._Title : this._TitleInnerHtml;
            string html = originalTab + $"<div class=\"inner\">" + Environment.NewLine.ToString();
            html += ($"{originalTab}   <h3>{title}</h3><p>{this._TitleCaption}</p>" + Environment.NewLine.ToString());
            html += ($"{originalTab}</div>" + Environment.NewLine.ToString());

            return html;
        }

        /// <summary>
        /// Builds the Html part for control
        /// </summary>
        /// <param name="ctrlId">ID of control</param>
        /// <returns>the HTML to render</returns>
        public string BuildHtml(string ctrlId = "")
        {
            string tab = "   ";
            string boxClass = this._IsSmall ? "small-box" : "box";
            string html = Environment.NewLine.ToString() + $"<div class=\"{boxClass} {this._CssClass}\">" + Environment.NewLine.ToString();
            html += BuildHtmlForInner(tab);

            html += ($"{tab}<div class=\"icon\">" + Environment.NewLine.ToString());
            html += ($"{tab}{tab}<i class=\"{this._IconClass}\"></i>" + Environment.NewLine.ToString());
            html += ($"{tab}</div>" + Environment.NewLine.ToString());

            var iconElement = new FontAwsomeHelper().WithIconArrowCircleRight().BuildHtml();
            html += ($"{tab} <a href=\"{this._NavigateToUrl}\" class=\"small-box-footer\">More info {iconElement}</a>"
                    + Environment.NewLine.ToString());

            html += "</div>";

            return html + Environment.NewLine.ToString();
        }

       
    }

}