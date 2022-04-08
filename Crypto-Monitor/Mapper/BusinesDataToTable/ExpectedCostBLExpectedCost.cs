using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;
using System;

namespace Сrypto_Monitor.Mapper
{
    public class ExpectedCostBLExpectedCost : Profile
    {
        public ExpectedCostBLExpectedCost() 
        {
            CreateMap<ExpectedCostBL, ExpectedCost>()
                .ForMember(c => c.CryptaId, d => d.MapFrom(src => src.CryptaId))
                .ForMember(c => c.Cost, d => d.MapFrom(src => src.Cost))
                .ForMember(c => c.Date, d => d.MapFrom(src => DateTime.Now))
                .ForMember(c => c.UserId, d => d.MapFrom(src => src.UserId));
        }
    }
}
