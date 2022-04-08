using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ExpectedCost
    {
        [Required]
        public int Id { get; set; }
        public double Cost { get; set; }
        [Required]
        public int CryptaId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CryptaId")]
        public Crypta Crypta { get; set; }
    }
}
