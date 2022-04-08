using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;
using System;

namespace Сrypto_Monitor.Mapper
{
    public class OrderBLOrder : Profile
    {
        public OrderBLOrder()
        {
            CreateMap<OrderBL, Order>()
                .ForMember(c => c.Money, d => d.MapFrom(src => src.Money))
                .ForMember(c => c.OrderTime, d => d.MapFrom(src => DateTime.Now))
                .ForMember(c => c.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(c => c.Count, d => d.MapFrom(src => src.Count));
        }
    }
}
