using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;

namespace Сrypto_Monitor.Mapper
{
    public class ExpectedCostDataExpectedCost : Profile
    {
        public ExpectedCostDataExpectedCost()
        {
            CreateMap<ExpectedCost, DataExpectedCost>()
                .ForMember(c => c.CryptaName, d => d.MapFrom(src => src.Crypta.Name)).ReverseMap();
        }
    }
}
