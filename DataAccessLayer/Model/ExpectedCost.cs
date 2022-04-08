using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ExpectedCost
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public int CryptaId { get; set; }

        [Required]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        //[Fori]
        public User User { get; set; }
        public Crypta Crypta { get; set; }
    }
}
