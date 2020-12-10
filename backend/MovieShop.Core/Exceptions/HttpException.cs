using System;
using System.Net;

namespace MovieShop.Core.Exceptions
{
    public class HttpException : Exception
    {
        public object Errors { get; set; }

        public HttpStatusCode Code { get; }

        public HttpException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }


    }
}