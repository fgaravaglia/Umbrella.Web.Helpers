namespace Umbrella.UI.Web.MVCWidgets
{
    /// <summary>
    /// base class to build a Model for a given widget
    /// </summary>
    public abstract class WidgetModel
    {
        /// <summary>
        /// Description of current widget
        /// </summary>
        /// <value></value>
        public IWidgetDescriptor Descriptor {get; private set;}

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="description"></param>
        protected WidgetModel(IWidgetDescriptor description)
        {
            this.Descriptor = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}