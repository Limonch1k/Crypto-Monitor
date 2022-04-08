using AutoMapper;
using BusinessLogicLayer.Model;
using Crypto_Monitor.DataTransferModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;

namespace Сrypto_Monitor.Mapper.ViewModelToBusinesModel
{
    public class CryptaPLToCryptaBL : Profile
    {
        public CryptaPLToCryptaBL() 
        {
            CreateMap<CryptaPL, CryptaBL>().ReverseMap();
        }
    }
}
