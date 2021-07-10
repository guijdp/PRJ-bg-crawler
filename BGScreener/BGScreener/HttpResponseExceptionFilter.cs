using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BGScreener
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is null)
                return;

            var statusCode = HttpStatusCode.InternalServerError;
            var data = new ErrorData
            {
                Message = context.Exception.Message,
                Stack = context.Exception.StackTrace
            };

            if (context.Exception is ArgumentNullException)
                statusCode = HttpStatusCode.NotFound;

            data.Name = statusCode.ToString();
            context.Result = new ObjectResult(data)
            {
                StatusCode = (int)(statusCode)
            };

            context.ExceptionHandled = true;
        }
    }
}
