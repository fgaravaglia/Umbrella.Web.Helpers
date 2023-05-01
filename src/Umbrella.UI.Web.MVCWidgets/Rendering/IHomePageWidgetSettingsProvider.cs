namespace Umbrella.UI.Web.MVCWidgets.Rendering
{
    /// <summary>
    /// Provider for settings for UI, to be applied to home page widgets
    /// </summary>
    public interface IHomePageWidgetSettingsProvider
    {
        /// <summary>
        /// GEts the Layout Settings for WIdget on Home Page
        /// </summary>
        /// <returns></returns>
        HomePageWidgetSettings Get();
    }
}