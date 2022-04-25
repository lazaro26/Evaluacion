using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace tecnologia.util.lib
{
    public class StatusResponse
    {
        public bool result { get; set; }
        public List<string> messages { get; set; }
        public object data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public StatusResponse()
        {
            this.messages = new List<string>();
        }
        public StatusResponse(bool result, string message)
        {
            this.result = result;
            this.messages = new List<string>() { message };
        }
        public StatusResponse(bool result, string message, object data)
        {
            this.result = result;
            this.messages = new List<string>() { message };
            this.data = data;
        }
        public StatusResponse(object data, List<string> messages = null, bool result = true)
        {
            this.result = result;
            this.messages = messages ?? new List<string>();
            this.data = data;
        }
    }
}
