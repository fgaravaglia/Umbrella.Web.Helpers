using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public class CardHelper : IBootstrapHtmlHelper
    {
        #region Fields
        readonly string _Title;
        string _BadgeText;
        string _BadgeCssClass;

        bool _Collapsible;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public CardHelper(string title)
        {
            this._Title = title;
            this._BadgeCssClass = "bg-info";
            this._Collapsible = true;
            this._BadgeText  ="";
        }

        public CardHelper NotCollapsible()
        {
            this._Collapsible = false;
            return this;
        }

        /// <summary>
        /// Sets the badge in the header title.
        /// </summary>
        /// <param name="text">text of the badge</param>
        /// <param name="cssClass">bootsrap class to apply for style</param>
        public CardHelper SetBadge(string text, string cssClass)
        {
            this._BadgeCssClass = cssClass;
            this._BadgeText = text;
            return this;
        }

        string BuildHtmlForHeader()
        {
            string tab = "   ";
            string htmlHeader = "<div class=\"card-header\">" + Environment.NewLine.ToString();

            if (!String.IsNullOrEmpty(this._BadgeText))
            {
                htmlHeader += ($"{tab}<h3 class=\"card-title\">{this._Title} <span class=\"badge {this._BadgeCssClass}\">{this._BadgeText}</span></h3>" + Environment.NewLine.ToString());
            }
            else
                htmlHeader += ($"{tab}<h3 class=\"card-title\">{this._Title}</h3>" + Environment.NewLine.ToString());

            htmlHeader += ($"{tab}<div class=\"card-tools\">" + Environment.NewLine.ToString());
            if (this._Collapsible)
                htmlHeader += ($"{tab}{tab}<button type=\"button\" class=\"btn btn-tool\" data-card-widget=\"collapse\"><i class=\"fas fa-minus\"></i></button>" + Environment.NewLine.ToString());
            htmlHeader += ($"{tab}</div>" + Environment.NewLine.ToString());
            htmlHeader += ($"</div>" + Environment.NewLine.ToString());

            return htmlHeader;
        }

        /// <summary>
        /// Builds the Html part for control
        /// </summary>
        /// <param name="ctrlId">id of control</param>
        /// <returns>the HTML to render</returns>
        public string BuildHtml(string ctrlId = "")
        {
            string htmlHeader = BuildHtmlForHeader();
            string htmlBody = "";
            string htmlFooter = "";
            return htmlHeader + htmlBody + htmlFooter;
        }
    }
}