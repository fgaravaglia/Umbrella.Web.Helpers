using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.UI.Web.MVC.Helpers;
using Umbrella.UI.Web.MVC.Helpers.HtmlHelpers;
using Microsoft.AspNetCore.Html;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap
{
    public static class BootstrapHelperExtensions
    {
        #region Background
        public static string AsSuccess(this BootstrapBackground bkg)
        {
            bkg.Success();
            return bkg.BuildClassName();
        }

        public static string AsInfo(this BootstrapBackground bkg)
        {
            bkg.Info();
            return bkg.BuildClassName();
        }

        public static string AsWarning(this BootstrapBackground bkg)
        {
            bkg.Warning();
            return bkg.BuildClassName();
        }

        #endregion

        #region FontAwsome

        public static FontAwsomeHelper UsingSolidStyle(this FontAwsomeHelper helper)
        {
            helper.Solid();
            return helper;
        }

        public static FontAwsomeHelper AsIcon(this FontAwsomeHelper helper, Action<FontAwsomeHelper> action)
        {
            action.Invoke(helper);

            if (!helper.IsIconSet)
                throw new ApplicationException($"Icon type has not been set!");

            return helper;
        }

        public static IHtmlContent ToHtmlSpan(this FontAwsomeHelper helper)
        {
            return new HtmlString($"<span class=\"info-box-icon\">{helper.BuildHtml()}</i></span>");
        }

        #endregion

        #region Badge
        public static IHtmlContent RenderInfoBadge(string text)
        {
            return new HtmlString($"<span class=\"badge bg-{BootstrapNames.INFO}\">{text}</span>");
        }

        public static IHtmlContent RenderSuccessBadge(string text)
        {
            return new HtmlString($"<span class=\"badge bg-{BootstrapNames.SUCCESS}\">{text}</span>");
        }

        public static IHtmlContent RenderWarningBadge(string text)
        {
            return new HtmlString($"<span class=\"badge bg-{BootstrapNames.WARNING}\">{text}</span>");
        }

        public static IHtmlContent RenderPrimaryBadge(string text)
        {
            return new HtmlString($"<span class=\"badge bg-{BootstrapNames.PRIMARY}\">{text}</span>");
        }
        #endregion
    }

    public static class BootstrapNames
    {
        public const string INFO = "info";
        public const string SUCCESS = "success";
        public const string WARNING = "warning";
        public const string PRIMARY = "primary";
    }

}