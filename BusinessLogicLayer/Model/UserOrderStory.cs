using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Model
{
    public class UserOrderStory
    {
        public string UserName { get; set; }
        public List<OrderCryptaBL> OrderList { get; set; }
    }
}
