namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Abstraction by composition for the component tha has the scope to resolve all widgets and gets them to application
    /// </summary>
    public interface IWidgetDescriptorManager : IWidgetDescriptorFiller, IWidgetDescriptorProvider
    {
         
    }
}