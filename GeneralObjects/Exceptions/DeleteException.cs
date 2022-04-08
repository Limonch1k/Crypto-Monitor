using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralObjects.Exceptions
{
    public class DeleteException : Exception
    {
        public string Property { get; protected set; }
        public DeleteException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
