# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# How to inject widgets for a specific module
to inject new widgets from a given application module, it is necessary to define a provider:

```c#
    /// <summary>
    /// Widget provider for AdminTools module
    /// </summary>
    public class ModuleWidgetDescriptorProvider : IModuleWidgetDescriptorProvider
    {
        /// <summary>
        /// Default Constr
        /// </summary>
        /// <returns></returns>
        public ModuleWidgetDescriptorProvider() : base(Module.MVC_AREA)
        {
        }

        protected override void InitializeWidgets()
        {
            // FIll the header row of widget
            var widgetMyGlobalPosition = new WidgetDescriptor("NEXT_RELEASES2", "Next Application Releases")
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
                bootstrapLogger.Information("[Startup] Registering widgets for module {moduleName}", provider.ModuleName);
                widgetManager.AddModule(provider.ModuleName, provider);
            }
```
