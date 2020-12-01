using System;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpResponseException() { }

        public CustomHttpResponseException(string message, Exception exception) : base(message, exception) { }

        public CustomHttpResponseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
