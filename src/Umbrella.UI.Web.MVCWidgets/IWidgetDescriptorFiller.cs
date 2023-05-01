namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Abstraction for component that fills list of widgets
    /// </summary>
    public interface IWidgetDescriptorFiller
    {
        /// <summary>
        /// Adds a module, to inject all widgets given from that specific module
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="provider"></param>
        void AddModule(string moduleName, IWidgetDescriptorProvider provider);
        /// <summary>
        /// Adds a given widgets
        /// </summary>
        /// <param name="descr"></param>
        void AddWidget(IWidgetDescriptor descr);
    }
}