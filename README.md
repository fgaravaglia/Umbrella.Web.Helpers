# Repository Content
This library contains common helpers and component for Web, such MVC, WebAPi, etc.

[![Build Status](https://garaproject.visualstudio.com/UmbrellaFramework/_apis/build/status%2FUmbrella.Web.Helpers?repoName=fgaravaglia%2FUmbrella.Web.Helpers&branchName=main)](https://garaproject.visualstudio.com/UmbrellaFramework/_build/latest?definitionId=90&repoName=fgaravaglia%2FUmbrella.Web.Helpers&branchName=main)

To install it, use proper command:

```bat
dotnet add package Umbrella.UI.Web.MVCWidgets
dotnet add package Umbrella.WebApi.Commons
```

# Widgets

## How to inject widgets for a specific module
to inject new widgets from a given application module, it is necessary to define a provider:

```c#
    /// <summary>
    /// Widget provider for AdminTools module
    /// </summary>
    public class MyModuleWidgetDescriptorProvider : ModuleWidgetDescriptorProvider, IModuleWidgetDescriptorProvider
    {
        /// <summary>
        /// Default Constr
        /// </summary>
        /// <returns></returns>
        public MyModuleWidgetDescriptorProvider() : base(Module.MVC_AREA)
        {
        }

        protected override void InitializeWidgets()
        {
            // FIll the header row of widget
            var widgetMyGlobalPosition = new WidgetDescriptor("NEXT_RELEASES", "Next Application Releases")
                      .FromModule(this.ModuleName)
                      .UsingMvcComponent("WidgetNextReleases", "UI.Web.MVCPortal.Areas.AdminTools.Widgets")
                      .DisplayedIntoHomePageHeaderArea();
            this._WidgetRegistry.Add(widgetMyGlobalPosition.ID, widgetMyGlobalPosition);
        }
    }
```

Then, register the manager into DI:

```c#
services.AddSingleton<IWidgetDescriptorManager>(x => new WidgetDescriptorComposer());
services.AddTransient<IModuleWidgetDescriptorProvider, MyModuleWidgetDescriptorProvider>();
```

Finally, register your widgets before startup:

```c#
// use Widgets
var widgetManager = app.Services.GetRequiredService<IWidgetDescriptorManager>();
var widgetProviders = app.Services.GetServices<IModuleWidgetDescriptorProvider>() ?? new List<IModuleWidgetDescriptorProvider>();
foreach(var provider in widgetProviders)
{
    widgetManager.AddModule(provider.ModuleName, provider);
}
```
