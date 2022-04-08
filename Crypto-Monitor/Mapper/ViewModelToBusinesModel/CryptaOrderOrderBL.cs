using AutoMapper;
using BusinessLogicLayer.Model;
using Crypto_Monitor.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сrypto_Monitor.Mapper.ViewModelToBusinesModel
{
    public class CryptaOrderOrderBL : Profile
    {
        public CryptaOrderOrderBL()
        {
            CreateMap<CryptaOrder, OrderBL>().ReverseMap();
        }
    }
}
