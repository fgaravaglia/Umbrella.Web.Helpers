using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    /// <summary>
    /// Class to render TExt Box as HTML control
    /// </summary>
    public class TextBoxHelper : IBootstrapHtmlHelper
    {
        #region Fields
        string _DisabledAttribute = "";
        string _PlaceHolderText;
        readonly string _ID;
        string _ControlType;
        int _TextAreaRows;
        string _ControlValue;
        #endregion

        /// <summary>
        /// Default Constr
        /// </summary>
        /// <param name="id"></param>
        public TextBoxHelper(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));
            this._ID = id;
            this._PlaceHolderText = "Enter the Text here...";
            this._ControlType = "text";
            this._TextAreaRows = 3;
            this._ControlValue = "";
        }

        public TextBoxHelper ReadOnly()
        {
            this._DisabledAttribute = "disabled";
            return this;
        }

        public TextBoxHelper Editable()
        {
            this._DisabledAttribute = "";
            return this;
        }

        public TextBoxHelper WithPlaceHolderText(string text)
        {
            this._PlaceHolderText = text;
            return this;
        }

        public TextBoxHelper AsTextArea(int rows = 3)
        {
            this._ControlType = "textarea";
            this._TextAreaRows = rows;
            return this;
        }

        public TextBoxHelper WithValue(string ctrlValue)
        {
            this._ControlValue = ctrlValue;
            return this;
        }

        /// <summary>
        /// Builds the Html part for control
        /// </summary>
        /// <param name="ctrlId">ID of control</param>
        /// <returns>the HTML to render</returns>
        public string BuildHtml(string ctrlId = "")
        {
            if (this._ControlType == "text")
                return $"<input class=\"form-control\" type=\"text\" value=\"{this._ControlValue}\" id=\"{this._ID}\" placeholder=\"{this._PlaceHolderText}\" {this._DisabledAttribute}>";

            return $"<textarea class=\"form-control\" rows=\"{this._TextAreaRows}\" id=\"{this._ID}\" placeholder=\"{this._PlaceHolderText}\" {this._DisabledAttribute}>{this._ControlValue}</textarea>";
        }
    }
}