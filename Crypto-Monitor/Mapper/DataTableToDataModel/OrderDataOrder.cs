using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;

namespace Сrypto_Monitor.Mapper
{
    public class OrderDataOrder : Profile
    {
        public OrderDataOrder() 
        {
            CreateMap<Order, DataOrder>()
                .ForMember(c => c.UserName, d => d.MapFrom(src => src.User.Name))
                .ForMember(c => c.CryptaName, d => d.MapFrom(src => src.Crypta.Name))
                .ForMember(c => c.CryptaId, d => d.MapFrom(src => src.CryptaId))
                .ForMember(c => c.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(c => c.Money, d => d.MapFrom(src => src.Count * src.Crypta.Cost)).ReverseMap();
        }
    }
}
