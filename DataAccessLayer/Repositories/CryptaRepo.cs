using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralObjects.Exceptions;

namespace DataAccessLayer.Repositories
{
    public class CryptaRepo : IModiferDataAsynk<DataCrypta>
    {
        private CryptaContext _context;
        private IMapper _mapper;
        public CryptaRepo(CryptaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(DataCrypta item)
        {
            var crypta = _mapper.Map<Crypta>(item);
            await _context.Cryptas.AddAsync(crypta);
            return;
        }

        public async Task Delete(DataCrypta item)
        {
            var crypta = await _context.Cryptas.FindAsync(item.CryptaId);
            if (crypta is null)
            {
                throw new FindException("cannot find crypta for deleeting!!!", "find error in CryptaRepo.Delete(DataCrypta) method");
            }
            _context.Remove(crypta);
            return;
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();           
        }

        public async Task<DataCrypta> FindById(int id)
        {
            var crypta = await _context.Cryptas.FindAsync(id);
            if (crypta is null)
            {
                throw new FindException("cannot this crypta!!!", "find error in CryptaRepo.FindById(int) method");
            }
            return _mapper.Map<DataCrypta>(crypta);
        }

        public IEnumerable<DataCrypta> GetAll()
        {
            var cryptaList = _context.Cryptas.AsEnumerable();
            if (cryptaList.Count() == 0) 
            {
                throw new EmptyListException("not enable crypta for trading!!!", "find error in CryptaRepo.GetAll() method");
            }
            return _mapper.Map<IEnumerable<DataCrypta>>(cryptaList);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, DataCrypta item)
        {
            var crypta = await _context.Cryptas.FindAsync(id);
            if (crypta == null) 
            {
                throw new FindException("cannot find this crypta for update", "await _context.Cryptas.FindAsync(id) return null value");
            }
            crypta = _mapper.Map<Crypta>(item);
        }
    }
}
