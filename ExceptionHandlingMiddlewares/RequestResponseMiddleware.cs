using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;
        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //Request
            logger.LogInformation($"Query Keys: {httpContext.Request.QueryString}");
            var tempStream = new MemoryStream();
            httpContext.Response.Body = tempStream;

            await next.Invoke(httpContext); //Response

            tempStream.Seek(0, SeekOrigin.Begin);
            string responseText = await new StreamReader(tempStream, Encoding.UTF8).ReadToEndAsync();
            //Response
        }
    }
}
