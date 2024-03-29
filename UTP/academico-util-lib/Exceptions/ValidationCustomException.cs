﻿using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;

namespace tecnologia.util.lib.Exceptions
{
    public class ValidationCustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public ValidationCustomException() : base() { }

        public ValidationCustomException(string message) : base(message) { }
        public ValidationCustomException(string format, params object[] args) : base(string.Format(format, args)) { }
        public ValidationCustomException(string message, Exception innerException) : base(message, innerException) { }
        public ValidationCustomException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
        protected ValidationCustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        //public ValidationCustomException(HttpStatusCode statusCode) { this.StatusCode = statusCode; }
        //public ValidationCustomException(HttpStatusCode statusCode, string message) : base(message) { this.StatusCode = statusCode; }
        //public ValidationCustomException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString()) { }
        //public ValidationCustomException(HttpStatusCode statusCode, JsonDocument errorObject) : this(statusCode, errorObject.ToString()) { this.ContentType = @"application/json"; }
    }
}
