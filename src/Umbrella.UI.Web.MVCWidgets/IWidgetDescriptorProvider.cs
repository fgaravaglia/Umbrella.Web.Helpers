using System.Collections.Generic;

namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Abstraction of component that provides all widgets of the system
    /// </summary>
    public interface IWidgetDescriptorProvider
    {
        /// <summary>
        /// Gets all Widgets
        /// </summary>
        /// <returns></returns>
        IEnumerable<IWidgetDescriptor> GetAll();

    }
    /// <summary>
    /// Specific abstraction for a module provider
    /// </summary>
    public interface IModuleWidgetDescriptorProvider : IWidgetDescriptorProvider
    {
        /// <summary>
        /// Module Name
        /// </summary>
        /// <value></value>
        string ModuleName { get; }
    }
}