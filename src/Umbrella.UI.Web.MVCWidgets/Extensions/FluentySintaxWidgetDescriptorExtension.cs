namespace Umbrella.UI.Web.MVCWidgets.Extensions
{
    public static class FluentySintaxWidgetDescriptorExtension
    {

        public static WidgetDescriptor WithRequiredRole(this WidgetDescriptor descriptor, string name)
        {
            descriptor.AddRequiredRole(name);
            return descriptor;
        }

    }
}