using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace tecnologia.util.lib.Exceptions
{
    public class NotModifiedCustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public NotModifiedCustomException() : base() { }

        public NotModifiedCustomException(string message) : base(message) { }
        public NotModifiedCustomException(string format, params object[] args) : base(string.Format(format, args)) { }
        public NotModifiedCustomException(string message, Exception innerException) : base(message, innerException) { }
        public NotModifiedCustomException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        protected NotModifiedCustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
      
    }
}
