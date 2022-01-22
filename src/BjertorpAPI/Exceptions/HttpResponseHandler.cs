namespace BjertorpAPI.Exceptions
{
    public static class HttpResponseHandler
    {
        public static ExceptionResponse Respond(HttpExceptionResponse e)
        {
            return new ExceptionResponse(e.StatusCode, e.Message, "HttpResponseException");
        }
    }
}