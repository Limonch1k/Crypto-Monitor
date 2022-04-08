using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [RegularExpression(@"^[0-9]{2}*\.[0-9]{2}*\.[0-9]{4}$")]
        public DateTime DayOfBirth { get; set; }
        public double Discount { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<ExpectedCost> ExpectedCosts { get; set; } = new List<ExpectedCost>();

        
    }
}
