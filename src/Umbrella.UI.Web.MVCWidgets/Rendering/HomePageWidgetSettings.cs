namespace Umbrella.UI.Web.MVCWidgets.Rendering
{
    /// <summary>
    /// Settings for Home Page widgets disply areas
    /// </summary>
    public class HomePageWidgetSettings
    {
        /// <summary>
        /// List of widgets ids to display into header section of homepage
        /// </summary>
        /// <value></value>
        public List<KeyValuePair<int, string>> HeaderArea { get; set; }
        /// <summary>
        /// List of widgets ids to display into Main section of homepage
        /// </summary>
        /// <value></value>
        public List<KeyValuePair<int, string>> MainArea { get; set; }
        /// <summary>
        /// List of widgets ids to display into right section of homepage
        /// </summary>
        /// <value></value>
        public List<KeyValuePair<int, string>> RightArea { get; set; }

        /// <summary>
        /// Default Constr
        /// </summary>
        public HomePageWidgetSettings()
        {
            this.HeaderArea = new List<KeyValuePair<int, string>>();
            this.MainArea = new List<KeyValuePair<int, string>>();
            this.RightArea = new List<KeyValuePair<int, string>>();
        }


    }
}