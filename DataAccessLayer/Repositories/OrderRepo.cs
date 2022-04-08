using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepo : AbstractClass<Order, CryptaContext>
    {
        public OrderRepo(CryptaContext context) : base(context) 
        {
        }
    }
}
