using System.Collections.Generic;
using System.Text.Json;

namespace tecnologia.util.lib
{
    public class ResponseRepresentation<T>
    {
        public bool result { get; set; }
        public List<string> messages { get; set; }
        public T data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public ResponseRepresentation()
        {
            this.messages = new List<string>();
        }

        public ResponseRepresentation(bool result, string message)
        {
            this.result = result;
            this.messages = new List<string>() {message};
        }

        public ResponseRepresentation(bool result, string message, T data)
        {
            this.result = result;
            this.messages = new List<string>() {message};
            this.data = data;
        }

        public ResponseRepresentation(T data, List<string> messages = null, bool result = true)
        {
            this.result = result;
            this.messages = messages ?? new List<string>();
            this.data = data;
        }
    }

    public class ResponseRepresentation
    {
        public bool result { get; set; } = false;
        public List<string> messages { get; set; }
    }
}