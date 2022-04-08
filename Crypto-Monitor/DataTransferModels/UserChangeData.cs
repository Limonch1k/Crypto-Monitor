using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels
{
    public class UserChangeData
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public string PasswwordConfirm { get; set; }
    }
}
