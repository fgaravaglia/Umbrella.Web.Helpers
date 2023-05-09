using System.Diagnostics.CodeAnalysis;

namespace Umbrella.WebApi.Commons.SwaggerManagement
{
    /// <summary>
    /// Attribute to add header param called channel
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwaggerChannelHeaderRequiredAttribute : SwaggerHeaderAttribute
    {
        public const string ParameterName = "channel";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SwaggerChannelHeaderRequiredAttribute() 
            : base(ParameterName, description: "Set the channel that is consuming the endpoint", isRequired: true)
        {
        }
    }
}
