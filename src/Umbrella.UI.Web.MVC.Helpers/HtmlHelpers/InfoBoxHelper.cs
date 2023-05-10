using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public class InfoBoxHelper : IBootstrapHtmlHelper
    {
        #region Fields
        string _Number;
        string _Text;
        string _IconCss;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public InfoBoxHelper()
        {
            this._Text = "";
            this._Number = "";
            this._IconCss = "fa-ranking-star";
        }

        #region Private Methods
        string BuildHtmlForIcon()
        {
            string htmlHeader = $"<span class=\"info-box-icon bg-info\"><i class=\"{this._IconCss}\"></i></span>" + Environment.NewLine.ToString();
            return htmlHeader;
        }
        string BuildHtmlForContent()
        {
            string tab = "   ";
            string html = $"<div class=\"info-box-content\">" + Environment.NewLine.ToString();
            html += ($"{tab}<span class=\"info-box-text\">{this._Text}</span>" + Environment.NewLine.ToString());
            html += ($"{tab}<span class=\"info-box-number\">{this._Number}</span>" + Environment.NewLine.ToString());
            html += ($"</div>" + Environment.NewLine.ToString());
            return html;
        }
        #endregion
        
        public InfoBoxHelper SetCssClass(string cssClass)
        {
            this._IconCss = cssClass;
            return this;
        }

        public InfoBoxHelper SetInfo(string text, string number)
        {
            this._Text = text;
            this._Number = number;
            return this;
        }
        /// <summary>
        /// Builds the Html part for control
        /// </summary>
        /// <param name="ctrlId">id of control</param>
        /// <returns>the HTML to render</returns>
        public string BuildHtml(string ctrlId = "")
        {
            return "<div class=\"info-box\">" + BuildHtmlForIcon() + BuildHtmlForContent() + "</div>";
        }

        public static IHtmlContent RenderFor(string text, string number, string cssClass)
        {
            var helper = new InfoBoxHelper();
            helper.SetInfo(text, number);
            helper.SetCssClass(cssClass);
            return new HtmlString(helper.BuildHtml(""));
        }

        public static IHtmlContent RenderFor(string id, string text, int number, string cssClass)
        {
            return new InfoBoxHelper()
                            .SetInfo(text, number.ToString())
                            .SetCssClass(cssClass)
                            .Render(id);
        }
    }

}