using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;

namespace Сrypto_Monitor.Mapper.BusinesDataToModel
{
    public class UserRegistredBLDataUser : Profile
    {
        public UserRegistredBLDataUser()
        {
            CreateMap<DataUser, UserRegistredBL>().ReverseMap() ;
        }
    }
}
