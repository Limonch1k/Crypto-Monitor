using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Model
{
    public class Crypta
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; } //$       
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<ExpectedCost> ExpectedCosts { get; set; } = new List<ExpectedCost>();
    }
}
