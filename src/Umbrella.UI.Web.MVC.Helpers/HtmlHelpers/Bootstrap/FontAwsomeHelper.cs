using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.UI.Web.MVC.Helpers.HtmlHelpers.Bootstrap
{
    /// <summary>
    /// Helper to create a dictinry of used icons
    /// </summary>
    public class FontAwsomeHelper
    {
        #region Fields
        bool _Solid;
        bool _Regular;
        string _IconClass;
        #endregion

        /// <summary>
        /// FullName of Bootstrap Class based on FontAwsome classes
        /// </summary>
        /// <returns></returns>
        public string ClassFullName { get { return GetClass(this._IconClass); } }
        /// <summary>
        /// Trhow if icon is already set
        /// </summary>
        /// <returns></returns>
        public bool IsIconSet { get { return !String.IsNullOrEmpty(_IconClass); } }

        public FontAwsomeHelper()
        {
            this._IconClass = "";
        }

        public void Solid()
        {
            this._Solid = true;
            this._Regular = false;
        }

        public void SetRegular()
        {
            this._Solid = false;
            this._Regular = true;
        }
        /// <summary>
        /// Build Html for tag i
        /// </summary>
        /// <returns></returns>
        public string BuildHtml()
        {
            return $"<i class=\"{this.ClassFullName}\"></i>";
        }

        #region Private Methods

        private string GetClass(string iconClass)
        {
            string solidClass = "";
            if (this._Solid)
                solidClass = "fa-solid";

            string reguarClass = "";
            if (_Regular)
                reguarClass = "fa-regular";
            return $"fa {reguarClass} {solidClass} {iconClass}";
        }

        #endregion;

        #region Set Icon Name

        public FontAwsomeHelper WithCubesStacked()
        {
            this._IconClass = "fa-cubes-stacked";
            return this;
        }

        public FontAwsomeHelper WithIconAsStart()
        {
            this._IconClass = "fa-star";
            return this;
        }

        public FontAwsomeHelper WithIconAsEye()
        {
            this._IconClass = "fa-eye";
            return this;
        }

        public FontAwsomeHelper WithIconArrowCircleRight()
        {
            this._IconClass = "fa-arrow-circle-right";
            return this;
        }

        public FontAwsomeHelper WithIconBell()
        {
            this._IconClass = "fa-bell";
            return this;
        }

        public FontAwsomeHelper WithIconBuildingCircleCheck()
        {
            this._IconClass = "fa-building-circle-check";
            return this;
        }

        public FontAwsomeHelper WithIconCircle()
        {
            this._IconClass = "fa-circle";
            return this;
        }

        public FontAwsomeHelper WithIconCircleInfo()
        {
            this._IconClass = "fa-circle-info";
            return this;
        }

        public FontAwsomeHelper WithIconCircleUser()
        {
            this._IconClass = "fa-circle-user";
            return this;
        }

        public FontAwsomeHelper WithIconClock()
        {
            this._IconClass = "fa-clock";
            return this;
        }

        public FontAwsomeHelper WithIconCube()
        {
            this._IconClass = "fa-cube";
            return this;
        }

        public FontAwsomeHelper WithIconDownload()
        {
            this._IconClass = "fa-download";
            return this;
        }

        public FontAwsomeHelper WithIconEllipsisVertical()
        {
            this._IconClass = "fa-ellipsis-vertical";
            return this;
        }

        public FontAwsomeHelper WithIconEnvelope()
        {
            this._IconClass = "fa-envelope";
            return this;
        }

        public FontAwsomeHelper WithIconFolder()
        {
            this._IconClass = "fa-folder";
            return this;
        }

        public FontAwsomeHelper WithIconFutbol()
        {
            this._IconClass = "fa-futbol";
            return this;
        }

        public FontAwsomeHelper WithIconRankingStar()
        {
            this._IconClass = "fa-ranking-star";
            return this;
        }

        public FontAwsomeHelper WithIconPencilAlt()
        {
            this._IconClass = "fa-pencil-alt";
            return this;
        }

        public FontAwsomeHelper WithIconRightFromBracket()
        {
            this._IconClass = "fa-right-from-bracket";
            return this;
        }


        public FontAwsomeHelper WithIconHome()
        {
            this._IconClass = "fa-home";
            return this;
        }

        public FontAwsomeHelper WithIconScrewdriverWrench()
        {
            this._IconClass = "fa-screwdriver-wrench";
            return this;
        }

        public FontAwsomeHelper WithIconStar()
        {
            this._IconClass = "fa-star";
            return this;
        }

        public FontAwsomeHelper WithIconSave()
        {
            this._IconClass = "fa-save";
            return this;
        }

        public FontAwsomeHelper WithIconToggleOn()
        {
            this._IconClass = "fa-toggle-on";
            return this;
        }

        public FontAwsomeHelper WithIconTrash()
        {
            this._IconClass = "fa-trash";
            return this;
        }

        public FontAwsomeHelper WithIconUsers()
        {
            this._IconClass = "fa-users";
            return this;
        }

        #endregion

    }
}