using System.Diagnostics.CodeAnalysis;

namespace Umbrella.WebApi.Commons.SwaggerManagement
{
    /// <summary>
    /// Attribute to add header param called trxId
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerTrxIdHeaderRequiredAttribute : SwaggerHeaderAttribute
    {
        public const string ParameterName = "trxId";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SwaggerTrxIdHeaderRequiredAttribute() 
            : base(ParameterName, description: "Set the Transaction Id for the call",  isRequired: true)
        {
        }
    }
}
