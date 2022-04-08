using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels
{
    public class CryptaOrder
    {
        public string CryptaId { get; set; }
        public string CryptaName {get ;set;}
        public string CryptaCost { get; set; }
        public double Money { get; set; }
    }
}
