using BusinessLogicLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crypto_Monitor.DataTransferModels
{
    public class UserOrderList
    {
        public int UserId { get; set;}
        public List<OrderBL> CryptaName { get; set; }
        public List<DateTime> DataOrder { get; set; }
    }
}
