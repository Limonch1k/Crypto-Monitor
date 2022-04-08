using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralObjects.Exceptions
{
    public class FindException : Exception
    {
        public string property { get; set; }

        public FindException(string property, string message) : base(message)
        {
            this.property = property;
        }
    }
}
