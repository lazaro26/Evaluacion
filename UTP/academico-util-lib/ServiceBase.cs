using System;
using System.Collections.Generic;
using System.Text;

namespace tecnologia.util.lib
{
    public class ServiceBase
    {
        private string m_txtConnectionString;
        public string txtConnectionString
        {
            get { return m_txtConnectionString; }
            set { m_txtConnectionString = value; }
        }
    }
}
