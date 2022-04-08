using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CryptaRepo : AbstractClass<Crypta, CryptaContext>
    {
        public CryptaRepo(CryptaContext context) : base (context) 
        {
        }
    }
}
