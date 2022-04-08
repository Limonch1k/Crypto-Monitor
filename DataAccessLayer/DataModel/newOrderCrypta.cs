using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
    public class newOrderCrypta
    {
        public double Money { get; set; }
        public int UserId { get; set; }
        public int CryptaId { get; set; }
        public string UserName { get; set; }
        public string CryptaName { get; set; }
    }
}
