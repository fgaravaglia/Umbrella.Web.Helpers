using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Umbrella.WebApi.Commons.Infrastructure
{
    /// <summary>
    /// Estensions to manage Htt request
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Gets the raw body from an HTTP request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<string> GetRawBodyAsync(this HttpRequest request, Encoding encoding)
        {
            if (!request.Body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance each time it's called
                request.EnableBuffering();
            }

            request.Body.Position = 0;

            var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8);
            var body = await reader.ReadToEndAsync().ConfigureAwait(false);
            request.Body.Position = 0;

            return body;
        }
    }
}