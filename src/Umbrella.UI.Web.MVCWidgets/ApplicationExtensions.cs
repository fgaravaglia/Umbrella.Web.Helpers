using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Use the widgets
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Registers the widgets provided by Application modules
        /// </summary>
        /// <param name="services"></param>
        public static void UseModuleWidgets(this IServiceProvider services)
        {
            // use Widgets
            var widgetManager = services.GetRequiredService<IWidgetDescriptorManager>();
            var widgetProviders = services.GetServices<IModuleWidgetDescriptorProvider>() ?? new List<IModuleWidgetDescriptorProvider>();
            foreach (var provider in widgetProviders)
            {
                widgetManager.AddModule(provider.ModuleName, provider);
            }
        }
    }
}