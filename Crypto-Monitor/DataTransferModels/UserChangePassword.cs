using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels
{
    public class UserChangePassword
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }

    }
}
