﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using Umbrella.WebApi.Commons.Infrastructure.ErrorManagement;

namespace Umbrella.WebApi.Commons.SwaggerManagement.ControllerFilters
{
    /// <summary>
    /// Filter to apply to each Request to validate mandatory headers
    /// </summary>
    public class TransactionIdFilter : IActionFilter
    {
        readonly Serilog.ILogger _Logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public TransactionIdFilter(Serilog.ILogger logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                _Logger.Information("Start TransactionId filtering current Action of controller {ControllerType}", context.Controller.GetType());

                //check if the method is auhtenticated or not
                var actionMethod = ExtractMethodFromController(context);
                var attribute = actionMethod.GetCustomAttributes(typeof(SwaggerTrxIdHeaderRequiredAttribute), true)
                                                                              .Select(x => (SwaggerTrxIdHeaderRequiredAttribute)x).FirstOrDefault();
                if (attribute == null)
                    return;

                // read channel value from header
                string headerValue = "";
                _Logger.Debug("Current Headers {Headers}", context.HttpContext.Request.Headers);
                if (context.HttpContext.Request.Headers.Any(p => p.Key.Equals(SwaggerTrxIdHeaderRequiredAttribute.ParameterName, StringComparison.CurrentCultureIgnoreCase)))
                    headerValue = context.HttpContext.Request.Headers
                                            .Single(p => p.Key.Equals(SwaggerTrxIdHeaderRequiredAttribute.ParameterName, StringComparison.CurrentCultureIgnoreCase))
                                                .Value.ToString();
                else
                    headerValue = "";

                // verify acchannel is set
                if (string.IsNullOrEmpty(headerValue) && attribute.IsRequired)
                    throw new InvalidDataException(SwaggerChannelHeaderRequiredAttribute.ParameterName + " is null");
            }
            catch (InvalidDataException securityEx)
            {
                _Logger.Error(securityEx, "Bad request on controller {ControllerType}", context.Controller.GetType());
                context.Result = new BadRequestActionResult(securityEx.Message, "");
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Unexpected error from filtering action of controller {ControllerType}", context.Controller.GetType());
                context.Result = new InternalServerErrorActionResult(ex.Message, "");
            }
            finally
            {
                _Logger.Information("End TransactionId filtering current Action of controller {ControllerType}", context.Controller.GetType());
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
            _Logger.Information("ActionName: {ActionName}", actionName);

            var actionMethod = context.Controller.GetType().GetMethods().SingleOrDefault(x => x.Name == actionName);
            if (actionMethod is null)
                throw new InvalidOperationException($"No Action '{context.ActionDescriptor.DisplayName}' inside controller  {context.Controller.GetType()} has been found");
            return actionMethod;
        }
        #endregion
    }
}
