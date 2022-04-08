using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepo : AbstractClass<User, CryptaContext>
    {
        public UserRepo(CryptaContext context) : base(context) 
        {
        }
    }
}
