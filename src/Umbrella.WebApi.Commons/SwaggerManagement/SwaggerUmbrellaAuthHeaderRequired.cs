using System.Diagnostics.CodeAnalysis;

namespace Umbrella.WebApi.Commons.SwaggerManagement
{
    /// <summary>
    /// Attribute to add header param called UmbrellaAuth
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwaggerUmbrellaAuthHeaderRequiredAttribute : SwaggerHeaderAttribute
    {
        internal const string ParameterName = "UmbrellaAuth";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SwaggerUmbrellaAuthHeaderRequiredAttribute() 
            : base(ParameterName, description: "Set the Umbrella Authentication token for the call",  isRequired: true)
        {
        }
    }
}
