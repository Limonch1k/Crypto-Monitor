using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сrypto_Monitor.Mapper
{
    public class ExpectedCostBLDataExpectedCost : Profile
    {
        public ExpectedCostBLDataExpectedCost() 
        {
            CreateMap<DataExpectedCost, ExpectedCostBL>()
                .ForMember(c => c.CryptaName, d => d.MapFrom(src => src.CryptaName))
                .ForMember(c => c.Cost, d => d.MapFrom(src => src.Cost)).ReverseMap();
        }
    }
}
