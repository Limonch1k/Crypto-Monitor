using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Model
{
    public class OrderBL
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CryptaId { get; set; }
        public double Count { get; set; }

        public double Money { get; set; }
    }
}
