using Umbrella.UI.Web.MVCWidgets.Extensions;

namespace Umbrella.UI.Web.MVCWidgets
{
    public class WidgetDescriptorComposer : IWidgetDescriptorManager
    {
        readonly Dictionary<string, IWidgetDescriptorProvider> _ModuleProviders;
        readonly Dictionary<string, IWidgetDescriptor> _WidgetRegistry;

        public WidgetDescriptorComposer()
        {
            this._ModuleProviders = new Dictionary<string, IWidgetDescriptorProvider>();
            this._WidgetRegistry = new Dictionary<string, IWidgetDescriptor>();
            InitializeCoreWidgets();
        }

        public void AddModule(string moduleName, IWidgetDescriptorProvider provider)
        {
            if(string.IsNullOrEmpty(moduleName))
                throw new ArgumentNullException(nameof(moduleName));
            
            if(this._ModuleProviders.ContainsKey(moduleName))
                throw new ApplicationException($"Unable to add module {moduleName}: item already added");
            
            this._ModuleProviders.Add(moduleName, provider);
        }

        public void AddWidget(IWidgetDescriptor descr)
        {
            if (descr == null)
                throw new ArgumentNullException(nameof(descr));
            if (string.IsNullOrEmpty(descr.ID))
                throw new ArgumentNullException(nameof(descr) + ".ID");

            if (this._WidgetRegistry.ContainsKey(descr.ID))
                throw new ApplicationException($"Unable to add widget {descr.ID} - {descr.Title}: item already added");

            this._WidgetRegistry.Add(descr.ID, descr);
        }

        public IEnumerable<IWidgetDescriptor> GetAll()
        {
            var widgets = new List<IWidgetDescriptor>();
            // first of all, get items from registry
            foreach(var item in this._WidgetRegistry)
                widgets.Add(item.Value);
            
            // get widgets from module providers, but I need to avoid duplicates
            foreach(var provider in this._ModuleProviders)
            {
                var moduleWidgets = provider.Value.GetAll();
                moduleWidgets.ToList().ForEach(mw => 
                {
                    if (!widgets.Exists(x => x.ID == mw.ID))
                        widgets.Add(mw);
                });
            }

            return widgets.OrderBy(x => x.ModuleName).ThenBy(x => x.Title).ToList();
        }

        private void InitializeCoreWidgets()
        {
            AddWidget(new WidgetDescriptor("SYSSTATUS", "System Status")
                        .FromModule("CORE")
                        .UsingMvcComponent("WidgetSystemStatus", "UI.Web.MVCPortal.Areas.AdminTools.Controllers.Widgets")
                        .WithRequiredRole("ADMIN"));
        }
    }
}