using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CryptaId { get; set; }
        public double Count { get; set; }

        public double Money { get; set; }

        public DateTime OrderTime { get; set; }
        public User User { get; set; }
        public Crypta Crypta { get; set; }
    }
}
