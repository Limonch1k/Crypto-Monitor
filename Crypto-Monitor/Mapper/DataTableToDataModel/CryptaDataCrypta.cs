using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сrypto_Monitor.Mapper
{
    public class CryptaDataCrypta : Profile
    {
        public CryptaDataCrypta() 
        {
            CreateMap<Crypta, DataCrypta>()
                .ForMember(c => c.CryptaId, d => d.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
