using System;
using System.Collections.Generic;
using System.Text;

namespace academico_model
{
    public class Response
    {
        public bool result { get; set; }
        public string messages { get; set; }
        public int id { get; set; }
        public object data { get; set; }
    }
}
