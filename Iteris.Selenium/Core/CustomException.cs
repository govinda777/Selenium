using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Facade.Selenium.Core
{
    [Serializable]
    public class FacadeSelemiunException : Exception
    {
        public FacadeSelemiunException()
            : base() { }

        public FacadeSelemiunException(string message)
            : base(message) { }

        public FacadeSelemiunException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public FacadeSelemiunException(Exception innerException)
            : base(innerException.Message, innerException) { }

        public FacadeSelemiunException(string message, Exception innerException)
            : base(message, innerException) { }

        public FacadeSelemiunException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected FacadeSelemiunException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
