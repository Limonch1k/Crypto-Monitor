using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;

namespace Сrypto_Monitor.Mapper
{
    public class OrderBLDataOrder : Profile
    {
        public OrderBLDataOrder() 
        {
            CreateMap<OrderBL, DataOrder>()
                .ForMember(c => c.UserName, d => d.MapFrom(src => src.UserId)).ReverseMap();
        }
    }
}
