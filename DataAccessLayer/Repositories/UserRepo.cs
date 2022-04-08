using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepo : AbstractUser<DataUser>
    {
        public UserRepo(CryptaContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
