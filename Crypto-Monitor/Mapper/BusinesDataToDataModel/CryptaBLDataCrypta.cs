using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;

namespace Сrypto_Monitor.Mapper
{
    public class CryptaBLDataCrypta : Profile
    {
        public CryptaBLDataCrypta() 
        {
            CreateMap<CryptaBL, DataCrypta>()
                .ForMember(c => c.CryptaId, d => d.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
