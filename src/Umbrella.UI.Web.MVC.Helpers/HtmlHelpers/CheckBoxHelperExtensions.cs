using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Umbrella.UI.Web.MVC.Helpers;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers
{
    public static class CheckBoxHelperExtensions
    {
        public static IHtmlContent RenderReadonlyCheckBoxFor(string id, bool checkBoxValue)
        {
            var helper = new CheckBoxHelper().ReadOnly();
            if(checkBoxValue)
                helper.Checked();
            return helper.Render(id);
        }
    }
}