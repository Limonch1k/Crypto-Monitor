using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;

namespace Сrypto_Monitor.Mapper
{
    public class CryptaBLCrypta : Profile
    {
        public CryptaBLCrypta() 
        {
            CreateMap<CryptaBL, Crypta>()
                .ForMember(c => c.Cost, d => d.MapFrom(src => src.Cost))
                .ForMember(c => c.Name, d => d.MapFrom(src => src.Name))
                .ForMember(c => c.Id, d => d.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
