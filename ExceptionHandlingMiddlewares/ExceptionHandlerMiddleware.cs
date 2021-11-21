using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandlingMiddlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await requestDelegate.Invoke(httpContext);
            }
            catch (Exception e)
            {
                //Logger...
            }
        }
    }
}
