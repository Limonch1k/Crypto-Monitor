using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataModel
{
    public class newExpectedCost
    {
        public int UserId { get; set; }      
        public int CryptaId { get; set; }
        public double Cost { get; set; }
        public string CryptaName { get; set; }      
    }
}
