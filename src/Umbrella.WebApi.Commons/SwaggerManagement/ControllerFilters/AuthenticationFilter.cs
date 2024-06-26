using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Umbrella.IdentityManagement.ClientAuthentication;
using Umbrella.WebApi.Commons.Infrastructure.ErrorManagement;
using Umbrella.WebApi.Commons.Infrastructure.ErrorManagements;

namespace Umbrella.WebApi.Commons.SwaggerManagement.ControllerFilters
{
    /// <summary>
    /// Attribute to decorate action in oder to set up authentication checks
    /// </summary>
    public class AuthenticationFilter : IActionFilter
    {
        readonly Serilog.ILogger _Logger;
        readonly IConfiguration _Config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="config"></param>
        public AuthenticationFilter(Serilog.ILogger logger, IConfiguration config)
        {
            this._Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._Config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                this._Logger.Information("Start filtering current Action of controller {ControllerType}", context.Controller.GetType());

                //check if the method is auhtenticated or not
                var actionMethod = ExtractMethodFromController(context);
                var umbrellaAuthRequiredAttributes = actionMethod.GetCustomAttributes(typeof(SwaggerUmbrellaAuthHeaderRequiredAttribute), true)
                                                                              .Select(x => (SwaggerUmbrellaAuthHeaderRequiredAttribute)x).ToList();
                var isAuthenticated = umbrellaAuthRequiredAttributes.Any();
                if (!isAuthenticated)
                    return;

                // read umbrella token from request
                string umbrellaAuthToken = ExtractUmbrellaAuthTokenFromHeader(context.HttpContext.Request);
                if (String.IsNullOrEmpty(umbrellaAuthToken))
                    throw new InvalidDataException(SwaggerUmbrellaAuthHeaderRequiredAttribute.ParameterName + " is null");

                // verify actual clients configuration
                var settings = this._Config.GetAuthenticationSettings();
                var clientID = umbrellaAuthToken.Split('|')[0];
                var secretId = umbrellaAuthToken.Split('|')[1];
                if (!settings.Clients.Exists(x => x.ClientID.Equals(clientID, StringComparison.InvariantCultureIgnoreCase)
                                            && x.SecretID.Equals(secretId, StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new UmbrellaTokenInvalidException("Client is not authorized to consume API", clientID);
                }
            }
            catch (UmbrellaTokenInvalidException securityEx)
            {
                this._Logger.Error(securityEx, "Unauthorized access on controller {ControllerType}", context.Controller.GetType());
                context.Result = new UnauthorizedActionResult(securityEx.Message, "");
            }
            catch (Exception ex)
            {
                this._Logger.Error(ex, "Unexpected error from filtering action of controller {ControllerType}", context.Controller.GetType());
                if (ex.GetType() == typeof(InvalidDataException) || ex.GetType() == typeof(ArgumentNullException))
                    context.Result = new BadRequestActionResult(ex.Message, "");
                else
                    context.Result = new InternalServerErrorActionResult(ex.Message, "");
            }
            finally
            {
                this._Logger.Information("End filtering current Action of controller {ControllerType}", context.Controller.GetType());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        #region Private methods

        private string ExtractUmbrellaAuthTokenFromHeader(HttpRequest req)
        {
            if (req == null)
                throw new ArgumentNullException(nameof(req));

            string umbrellaAuthToken = "";
            this._Logger.Debug("Current Headers {Headers}", req.Headers);
            if (req.Headers.Any(p => p.Key.Equals(SwaggerUmbrellaAuthHeaderRequiredAttribute.ParameterName, StringComparison.CurrentCultureIgnoreCase)))
                umbrellaAuthToken = req.Headers
                                        .Single(p => p.Key.Equals(SwaggerUmbrellaAuthHeaderRequiredAttribute.ParameterName, StringComparison.CurrentCultureIgnoreCase))
                                            .Value.ToString();

            return umbrellaAuthToken;
        }

        private MethodInfo ExtractMethodFromController(ActionExecutingContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.ActionDescriptor == null)
                throw new ArgumentNullException(nameof(context), "action descriptor cannot be null");
            if (context.ActionDescriptor.RouteValues == null)
                throw new ArgumentNullException(nameof(context), "ActionDescriptor.RouteValues cannot be noll");

            string actionName = "none";
            var routeValues = context.ActionDescriptor.RouteValues.ToList();
            if (routeValues.Exists(x => x.Key.ToLowerInvariant() == "action"))
                actionName = routeValues.Single(x => x.Key.ToLowerInvariant() == "action").Value ?? "";
            this._Logger.Information("ActionName: {ActionName}", actionName);

            var actionMethod = context.Controller.GetType().GetMethods().SingleOrDefault(x => x.Name == actionName);
            if (actionMethod is null)
                throw new InvalidOperationException($"No Action '{context.ActionDescriptor.DisplayName}' inside controller  {context.Controller.GetType()} has been found");
            return actionMethod;
        }
        #endregion
    }
}