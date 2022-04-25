using System;

namespace tecnologia.util.lib.Exceptions
{
    public class MineduException : Exception
    {
        public MineduException()
        {
        }

        public MineduException(string message)
            : base(message)
        {
        }

        public MineduException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
