using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    /// <summary>
    /// Claa to help for rendering HTML
    /// </summary>
    public class CheckBoxHelper : IBootstrapHtmlHelper
    {
        #region Fields
        bool _IsReadOnly;
        bool _IsChecked;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public CheckBoxHelper()
        {
            this._IsReadOnly = false;
            this._IsChecked = false;
        }

        public CheckBoxHelper ReadOnly()
        {
            this._IsReadOnly = true;
            return this;
        }

        public CheckBoxHelper Checked()
        {
            this._IsChecked = true;
            return this;
        }
        /// <summary>
        /// Builds the Html part for control
        /// </summary>
        /// <param name="ctrlId">id of control</param>
        /// <returns>the HTML to render</returns>
        public string BuildHtml(string ctrlId = "")
        {
            string disabledAttribute = " ";
            if (this._IsReadOnly)
                disabledAttribute = "disabled";
            string checkedAttribute = "";
            if (this._IsChecked)
                checkedAttribute = "checked";
            string id = "";
            if (!string.IsNullOrEmpty(ctrlId))
                id = "id=\"{ctrlId}\"";

            return $"<input class=\"form-check-input\" type=\"checkbox\" value=\"\" {id} {checkedAttribute} {disabledAttribute}>";
        }
    }
}