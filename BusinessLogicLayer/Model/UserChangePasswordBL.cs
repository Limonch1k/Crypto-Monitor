using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Model
{
    public class UserChangePasswordBL
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
