using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;

namespace tecnologia.util.lib.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }
        public CustomException(string format, params object[] args) : base(string.Format(format, args)) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) { }
        public CustomException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CustomException(HttpStatusCode statusCode) { this.StatusCode = statusCode; }
        public CustomException(HttpStatusCode statusCode, string message) : base(message) { this.StatusCode = statusCode; }
        public CustomException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }
        public CustomException(HttpStatusCode statusCode, JsonDocument errorObject) : this(statusCode, errorObject.ToString()) { this.ContentType = @"application/json"; }
    }
}
