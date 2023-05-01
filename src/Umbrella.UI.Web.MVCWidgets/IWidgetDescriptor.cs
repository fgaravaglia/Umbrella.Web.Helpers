namespace Umbrella.UI.Web.MVCWidgets;

/// <summary>
/// Abstraction to describe a widget
/// </summary>
public interface IWidgetDescriptor
{
    /// <summary>
    /// Widget ID
    /// </summary>
    /// <value></value>
    string ID { get; }
    /// <summary>
    /// Title of widget to display
    /// </summary>
    /// <value></value>
    string Title { get; }

    /// <summary>
    /// module that provide the widget. default CORE
    /// </summary>
    /// <value></value>
    string ModuleName { get; }
    /// <summary>
    /// Name of View Cpmponent for MVC implementation
    /// </summary>
    /// <value></value>
    string ViewComponentName { get; }
    /// <summary>
    /// list of required roles to be enabled to see current widget.
    /// AT least one of them is enough.
    /// </summary>
    /// <value></value>
    IEnumerable<string> RequiredRoles { get; }
    /// <summary>
    /// list of required claims to be enabled to see current widget.
    /// All of them are required
    /// </summary>
    /// <value></value>
    IEnumerable<KeyValuePair<string, string>> RequiredClaims { get; }
    /// <summary>
    /// The target area inside home page where to display the widget
    /// </summary>
    /// <value></value>
    string WidgetArea { get; }
    /// <summary>
    /// True if it a core widget; FALSE otherwise
    /// </summary>
    /// <value></value>
    bool IsCoreWidget { get; }
}
