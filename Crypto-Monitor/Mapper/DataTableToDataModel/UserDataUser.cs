using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;

namespace Сrypto_Monitor.Mapper.DataTableToDataModel
{
    public class UserDataUser : Profile
    {
        public UserDataUser() 
        {
            CreateMap<User, DataUser>().ReverseMap(); ;
        }
    }
}
