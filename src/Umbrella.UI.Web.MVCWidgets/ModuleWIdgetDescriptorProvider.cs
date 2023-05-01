namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// Base implementation of provider for given applciation module
    /// </summary>
    public abstract class ModuleWidgetDescriptorProvider : IModuleWidgetDescriptorProvider
    {
        /// <summary>
        /// Registry of widgets
        /// </summary>
        protected readonly Dictionary<string, IWidgetDescriptor> _WidgetRegistry;
        readonly string _ModuleName;
        /// <summary>
        /// Name of Module
        /// </summary>
        /// <value></value>
        public string ModuleName { get { return _ModuleName; } }

        /// <summary>
        /// Default constr
        /// </summary>
        /// <param name="name"></param>
        protected ModuleWidgetDescriptorProvider(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            this._ModuleName = name;
            this._WidgetRegistry = new Dictionary<string, IWidgetDescriptor>();
            InitializeWidgets();
        }
        /// <summary>
        /// initiliaze the list of widgets from scratch
        /// </summary>
        protected abstract void InitializeWidgets();
        /// <summary>
        /// Gets the list of widgets
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IWidgetDescriptor> GetAll()
        {
            var widgets = new List<IWidgetDescriptor>();
            // first of all, get items from registry
            foreach (var item in this._WidgetRegistry)
                widgets.Add(item.Value);

            return widgets;
        }
    }
}