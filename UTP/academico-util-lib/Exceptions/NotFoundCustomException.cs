using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;

namespace tecnologia.util.lib.Exceptions
{
    public class NotFoundCustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public NotFoundCustomException() : base() { }

        public NotFoundCustomException(string message) : base(message) { }
        public NotFoundCustomException(string format, params object[] args) : base(string.Format(format, args)) { }
        public NotFoundCustomException(string message, Exception innerException) : base(message, innerException) { }
        public NotFoundCustomException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        protected NotFoundCustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        //public NotFoundCustomException(HttpStatusCode statusCode) { this.StatusCode = statusCode; }
        //public NotFoundCustomException(HttpStatusCode statusCode, string message) : base(message) { this.StatusCode = statusCode; }
        //public NotFoundCustomException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }
        //public NotFoundCustomException(HttpStatusCode statusCode, JsonDocument errorObject) : this(statusCode, errorObject.ToString()) { this.ContentType = @"application/json"; }
    }
}
