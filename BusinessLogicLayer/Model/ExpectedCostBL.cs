using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Model
{
    public class ExpectedCostBL
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int CryptaId { get; set; }
        public double Cost { get; set; }
        public int CryptaName { get; set; }

    }
}
