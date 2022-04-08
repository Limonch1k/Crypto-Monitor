using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels
{
    public class UserRegistred
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}

        public string PasswordConfirm { get; set; }
    }
}
