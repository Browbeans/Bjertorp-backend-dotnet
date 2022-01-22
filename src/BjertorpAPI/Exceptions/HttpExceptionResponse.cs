using System;

namespace BjertorpAPI.Exceptions
{
    public class HttpExceptionResponse : Exception
    {
        public HttpExceptionResponse(int statusCode, string msg) : base(msg)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}