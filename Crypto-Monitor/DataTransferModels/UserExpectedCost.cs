using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels

{
    public class UserExpectedCost
    {
        public int UserId { get; set; }
        public string CryptaName { get; set; }
        public double ExpCost { get; set; }
    }
}
