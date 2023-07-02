using System.Diagnostics.CodeAnalysis;

namespace Umbrella.WebApi.Commons.SwaggerManagement
{
    /// <summary>
    /// Attribute to add header param called trxId
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerBusinessTrxIdHeaderAttribute : SwaggerHeaderAttribute
    {
        public const string ParameterName = "businessTrxId";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SwaggerBusinessTrxIdHeaderAttribute() 
            : base(ParameterName, description: "Set the Business Transaction Id for the call",  isRequired: false)
        {
        }
    }
}
