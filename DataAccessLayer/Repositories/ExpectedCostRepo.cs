using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExpectedCostRepo : AbstractClass<ExpectedCost, CryptaContext>
    {
        public ExpectedCostRepo(CryptaContext context) : base(context) 
        {
        }
    }
}
