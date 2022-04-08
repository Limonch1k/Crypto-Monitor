using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralObjects.Exceptions
{
    public class CreateException : Exception
    {
        public string Property { get; protected set; }
        public CreateException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
