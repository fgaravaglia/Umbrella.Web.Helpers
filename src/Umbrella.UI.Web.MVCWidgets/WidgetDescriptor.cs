using System.Collections.Generic;

namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Model to describe a widget
    /// </summary>
    public class WidgetDescriptor : IWidgetDescriptor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Title { get; internal set; }
        /// <summary>
        /// Name of Module that provides current widget
        /// </summary>
        /// <value></value>
        public string ModuleName { get; internal set; }
        /// <summary>
        /// TRUE if Widget belongs to CORE area
        /// </summary>
        /// <returns></returns>
        public bool IsCoreWidget { get { return !String.IsNullOrEmpty(this.ModuleName) && this.ModuleName == "CORE"; } }
        /// <summary>
        /// Area of widget
        /// </summary>
        /// <value></value>
        public string WidgetArea { get; internal set; }
        /// <summary>
        /// Name of ViewCOmponent
        /// </summary>
        /// <value></value>
        public string ViewComponentName { get; internal set; }
        /// <summary>
        /// Url to component
        /// </summary>
        /// <value></value>
        public string ViewComponentPath { get; internal set; }
        /// <summary>
        /// List of roles required to see the widget. If empty, no specific role is required
        /// </summary>
        /// <value></value>
        public IEnumerable<string> RequiredRoles { get; internal set; }
        /// <summary>
        /// List of claims required to see the widget. If empty, no specific claim is required
        /// </summary>
        /// <value></value>
        public IEnumerable<KeyValuePair<string, string>> RequiredClaims { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public WidgetDescriptor(string id, string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            this.ID = id;
            this.Title = title;
            this.ModuleName = "CORE";
            this.ViewComponentName = "";
            this.ViewComponentPath = "";
            this.RequiredClaims = new List<KeyValuePair<string, string>>();
            this.RequiredRoles = new List<string>();
            this.WidgetArea = "MAIN";
        }
        /// <summary>
        /// Sets the required role
        /// </summary>
        /// <param name="name"></param>
        public void AddRequiredRole(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (this.RequiredRoles.Contains(name))
                throw new ApplicationException($"Unable to add role {name} to required list: item already added");
            var list = this.RequiredRoles.ToList();
            list.Add(name);
            this.RequiredRoles = list;
        }
        /// <summary>
        /// Sets the module name that provides the widget
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WidgetDescriptor FromModule(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            this.ModuleName = name;
            return this;
        }
        /// <summary>
        /// Specifies the MVC ViewComponent that implement the current widget
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public WidgetDescriptor UsingMvcComponent(string name, string path)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            this.ViewComponentName = name;
            this.ViewComponentPath = path;
            return this;
        }

        public WidgetDescriptor DisplayedIntoHomePageArea(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            this.WidgetArea = name;
            return this;
        }

        public WidgetDescriptor DisplayedIntoHomePageRightArea()
        {
            return DisplayedIntoHomePageArea("RIGHT");
        }

        public WidgetDescriptor DisplayedIntoHomePageHeaderArea()
        {
            return DisplayedIntoHomePageArea("HEADER");
        }
    }
}