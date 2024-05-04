using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.UI.Web.MVC.Helpers;
using Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap;
using Microsoft.AspNetCore.Html;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public class ButtonHelper : IBootstrapHtmlHelper
    {
        #region Fields
        string _ButtonLayoutType;
        bool _IsGridRowContext;
        bool _IsToolbarButton;
        string _GoToUrl;
        string _BtnText;
        string _ModalId;
        string _OnClick;
        string _BlazorOnCLick;

        FontAwsomeHelper _IconHelper;

        #endregion

        public ButtonHelper()
        {
            DisplayedAsInfo();
            this._ModalId = "";
            this._ButtonLayoutType = "";
            this._GoToUrl = "";
            this._BtnText = "";
            this._OnClick = "";
            this._BlazorOnCLick = "";
            this._IconHelper = new FontAwsomeHelper();
        }
        /// <summary>
        /// Sets the button layout type as info
        /// </summary>
        public ButtonHelper DisplayedAsInfo()
        {
            this._ButtonLayoutType = BootstrapNames.INFO;
            return this;
        }
        /// <summary>
        /// Sets the button layout type as Primary
        /// </summary>
        public ButtonHelper DisplayedAsPrimary()
        {
            this._ButtonLayoutType = BootstrapNames.PRIMARY;
            return this;
        }
        public ButtonHelper SetContextForGridRow()
        {
            this._IsGridRowContext = true;
            this._IsToolbarButton = false;
            return this;
        }

        public ButtonHelper SetContextForToolbar()
        {
            this._IsGridRowContext = false;
            this._IsToolbarButton = true;
            return this;
        }

        public ButtonHelper WithIcon(FontAwsomeHelper icon)
        {
            this._IconHelper = icon ?? throw new ArgumentNullException(nameof(icon));
            return this;
        }

        public ButtonHelper RequiresModalToProceed(string modalId)
        {
            if (String.IsNullOrEmpty(modalId))
                throw new ArgumentNullException(nameof(modalId));
            this._ModalId = modalId;
            return this;
        }

        public ButtonHelper RequiresClientFunctionOnClick(string function)
        {
            if (String.IsNullOrEmpty(function))
                throw new ArgumentNullException(nameof(function));
            this._ModalId = "";
            this._OnClick = function;
            return this;
        }

        public ButtonHelper RequiresBlazorFunctionOnCLick(string function)
        {
            if (String.IsNullOrEmpty(function))
                throw new ArgumentNullException(nameof(function));
            this._ModalId = "";
            this._BlazorOnCLick = function;
            return this;
        }
        public ButtonHelper RequiresDefaultModalToProceed()
        {
            return RequiresModalToProceed("modal-default");
        }

        public ButtonHelper SetGoToDetailsButton(string text, string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            this._BtnText = text;
            this._GoToUrl = url;
            return this;
        }

        public ButtonHelper WithText(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            this._BtnText = text;
            return this;
        }
        public ButtonHelper WithHyperlink(string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            this._GoToUrl = url;
            return this;
        }

        public string BuildHtml(string ctrlId = "")
        {
            string html = "";

            if (this._IsGridRowContext)
                html = BuildHtmlForGridRow(ctrlId, this._BtnText);
            else if (this._IsToolbarButton)
                html = BuildHtmlForToolbar(ctrlId, this._BtnText);

            if (string.IsNullOrEmpty(html))
                throw new NotImplementedException();

            html += Environment.NewLine.ToString();
            return html;
        }

        #region Typed Buttons
        public static IHtmlContent GridButtonView(string ctrlId, string url)
        {
            var helper = new ButtonHelper();
            helper.SetContextForGridRow()
                    .DisplayedAsPrimary()
                    .WithIcon(new FontAwsomeHelper().UsingSolidStyle().WithIconFolder())
                    .SetGoToDetailsButton("View", url);
            var innerHtml = helper.BuildHtml(ctrlId);
            return new HtmlString(innerHtml);
        }

        public static IHtmlContent GridButtonEdit(string ctrlId, string url)
        {
            var helper = new ButtonHelper();
            helper.SetContextForGridRow()
                    .DisplayedAsPrimary()
                    .WithIcon(new FontAwsomeHelper().UsingSolidStyle().WithIconPencilAlt())
                    .SetGoToDetailsButton("Edit", url);
            var innerHtml = helper.BuildHtml(ctrlId);
            return new HtmlString(innerHtml);
        }

        public static ButtonHelper GridButtonDelete(string modalName)
        {
            if (String.IsNullOrEmpty(modalName))
                throw new ArgumentNullException(nameof(modalName));

            var helper = new ButtonHelper();
            helper.SetContextForGridRow()
                    .DisplayedAsPrimary()
                    .WithIcon(new FontAwsomeHelper().UsingSolidStyle().WithIconTrash())
                    .WithText("Delete")
                    .RequiresModalToProceed(modalName);
            return helper;
        }

        public static ButtonHelper ButtonDownload(string url)
        {
            var helper = new ButtonHelper()
                                .DisplayedAsInfo()
                                .SetContextForToolbar()
                                .WithIcon(new FontAwsomeHelper().UsingSolidStyle().WithIconSave())
                                .WithText("Download")
                                .WithHyperlink(url);
            return helper;
        }

        public static ButtonHelper ButtonGoToDetails(string url)
        {
            var helper = new ButtonHelper()
                                .DisplayedAsInfo()
                                .SetContextForToolbar()
                                .WithIcon(new FontAwsomeHelper().UsingSolidStyle().WithIconCircleInfo())
                                .WithText("View Details")
                                .WithHyperlink(url);
            return helper;
        }
        #endregion

        #region Private Methods
        string BuildHtmlForGridRow(string ctrlId, string buttonText)
        {
            string id = String.IsNullOrEmpty(ctrlId) ? Guid.NewGuid().ToString() : ctrlId;
            string html = "";
            string href = String.IsNullOrEmpty(this._GoToUrl) ? "" : $"href=\"{this._GoToUrl}\"";
            string targetModal = String.IsNullOrEmpty(this._ModalId) ? "" : $"data-bs-toggle=\"modal\" data-bs-target=\"#{this._ModalId}\"";
            string clickfunction = String.IsNullOrEmpty(this._OnClick) ? "" : $"onCLick=\"{this._OnClick}\"";
            string blazorClickfunction = String.IsNullOrEmpty(this._BlazorOnCLick) ? "" : ("@" + $"onClick=\"{this._BlazorOnCLick}\"");

            html += ($"<a {href} id=\"{id}\" class=\"btn btn-{this._ButtonLayoutType}\" data-toggle=\"tooltip\" title=\"{buttonText}\" {targetModal} {clickfunction} {blazorClickfunction}>" + Environment.NewLine);
            if (this._IconHelper != null)
            {
                html += ("   " + this._IconHelper.BuildHtml() + Environment.NewLine.ToString());
            }
            html += ("   @@BTN_TEXT@@" + Environment.NewLine.ToString());
            html += ("</a>" + Environment.NewLine.ToString());

            return html.Replace("@@BTN_TEXT@@", buttonText);
        }

        string BuildHtmlForToolbar(string ctrlId, string buttonText)
        {
            string htmlTemplate = "";
            string btnClass = $"btn btn-{this._ButtonLayoutType} btn-sm";
            string targetModalId = String.IsNullOrEmpty(this._ModalId) ? "" : $"data-bs-toggle=\"modal\" data-bs-target=\"#{this._ModalId}\"";
            string clickfunction = String.IsNullOrEmpty(this._OnClick) ? "" : $"onCLick=\"{this._OnClick}\"";
            string href = String.IsNullOrEmpty(this._GoToUrl) ? "" : $"href=\"{this._GoToUrl}\"";

            htmlTemplate += "<a @@BTN_ID@@ type=\"button\" class=\"@@BTN_CLASS@@\" @@MODAL@@ @@ONCLICK@@ @@HREF@@>";
            htmlTemplate += Environment.NewLine.ToString();
            htmlTemplate += ("    " + this._IconHelper.BuildHtml());
            htmlTemplate += Environment.NewLine.ToString();
            htmlTemplate += "    @@BTN_TEXT@@";
            htmlTemplate += Environment.NewLine.ToString();
            htmlTemplate += "</a>";

            // actualize the template
            htmlTemplate = htmlTemplate.Replace("@@BTN_ID@@", String.IsNullOrEmpty(ctrlId) ? "" : $"id=\"{ctrlId}\"");
            htmlTemplate = htmlTemplate.Replace("@@BTN_CLASS@@", btnClass);
            htmlTemplate = htmlTemplate.Replace("@@HREF@@", href);
            htmlTemplate = htmlTemplate.Replace("@@MODAL@@", targetModalId);
            htmlTemplate = htmlTemplate.Replace("@@ONCLICK@@", clickfunction);
            htmlTemplate = htmlTemplate.Replace("@@BTN_TEXT@@", buttonText);

            return htmlTemplate;
        }

        #endregion
    }
}