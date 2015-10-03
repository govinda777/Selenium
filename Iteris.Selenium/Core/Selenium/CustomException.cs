using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Iteris.Selenium.Core.Selemiun
{
    [Serializable]
    public class IterisSelemiunException : Exception
    {
        public IterisSelemiunException()
            : base() { }

        public IterisSelemiunException(string message)
            : base(message) { }

        public IterisSelemiunException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public IterisSelemiunException(Exception innerException)
            : base(innerException.Message, innerException) { }

        public IterisSelemiunException(string message, Exception innerException)
            : base(message, innerException) { }

        public IterisSelemiunException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected IterisSelemiunException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
