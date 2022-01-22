using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BjertorpAPI.Exceptions
{
    public class ExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            ExceptionResponse response;
            switch (exception)
            {
                case HttpExceptionResponse e:
                    response = HttpResponseHandler.Respond(e);
                    break;

                default:
                    Console.WriteLine($"[{exception.GetType().FullName}] {exception.Message}");
                    Console.WriteLine(exception.StackTrace);
                    Console.WriteLine(exception.InnerException?.StackTrace);
                    response = DefaultExceptionResponse();
                    break;
            }
            context.ExceptionHandled = true;
            context.Result = response.CreateObjectResult();
        }

        private static ExceptionResponse DefaultExceptionResponse()
        {
            return new(
                    StatusCodes.Status500InternalServerError,
                    "Unspecified Error",
                    ExceptionTypes.DatabaseError
                );
        }
    }
}