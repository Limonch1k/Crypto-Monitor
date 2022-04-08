using BusinessLogicLayer.Model;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.IO;
using GeneralObjects.Exceptions;

namespace BusinessLogicLayer.Functionality
{
    public class CryptaServices : IModiferDataAsynk<CryptaBL>
    {
        private CryptaRepo _cryRepo;
        private readonly IMapper _mapper;

        public CryptaServices(CryptaRepo repo, IMapper mapper) 
        {
            _cryRepo = repo;
            _mapper = mapper;
        }

        public IEnumerable<CryptaBL> GetAll()
        {
            IEnumerable<DataCrypta> list;
            try
            {
                list = _cryRepo.GetAll();
            }
            catch (EmptyListException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Property);
            }
            return _mapper.Map<IEnumerable<CryptaBL>>(list);
        }

        public async Task<CryptaBL> FindById(int id)
        {
            DataCrypta dataCrypta;
            try
            {
                dataCrypta = await _cryRepo.FindById(id);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
        
            return _mapper.Map<CryptaBL>(dataCrypta);
        }

        public async Task Update(int id, CryptaBL item)
        {
            var i = 10;

            try
            {
                await _cryRepo.Update(id, _mapper.Map<DataCrypta>(item));
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }          
            await _cryRepo.Save();
        }

        public async Task Create(CryptaBL item)//если в параметре нулл.
        {
            DataCrypta dataCrypta = _mapper.Map<DataCrypta>(item);
            await _cryRepo.Create(dataCrypta);            
            await _cryRepo.Save();
        }

        public async Task Delete(CryptaBL item)
        {
            try
            {
                DataCrypta dataCrypta = _mapper.Map<DataCrypta>(item);
                await _cryRepo.Delete(dataCrypta);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
            await _cryRepo.Save();
        }

        public async Task Dispose()
        {
            await _cryRepo.Dispose();
        }

        public async Task Save()
        {
            await _cryRepo.Save();
        }
    }
}
