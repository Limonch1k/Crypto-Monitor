using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using GeneralObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ExpectedCostRepo : IModiferDataAsynk<DataExpectedCost>
    {
        private CryptaContext _context;
        private IMapper _mapper;
        public ExpectedCostRepo(CryptaContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(DataExpectedCost item)
        {
            var expCost = _mapper.Map<ExpectedCost>(item);
            await _context.ExpectedCosts.AddAsync(expCost);
        }

        public async Task Delete(DataExpectedCost item)
        {
            var expCost = await _context.ExpectedCosts.FindAsync(item.Id);
            if (expCost is null) 
            {
                throw new FindException("cannot find this expected cost for deleting", "find error in ExpectedCostRepo.Delete(item) method");
            }
            _context.ExpectedCosts.Remove(expCost);
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<DataExpectedCost> FindById(int id)
        {
            var expectedCost = await _context.ExpectedCosts.FindAsync(id);
            if (expectedCost is null)
            {
                throw new FindException("cannot find this expected cost", "find error in ExpectedCostRepo.FindById(item) method");
            }
            return _mapper.Map<DataExpectedCost>(expectedCost);
        }

        public IEnumerable<DataExpectedCost> GetAll()
        {
            var expectedCostList = _context.ExpectedCosts.AsEnumerable();
            if (expectedCostList.Count() == 0)
            {
                throw new EmptyListException("you are not have expected cost yet!!!", "EmptyList error in ExpectedCostRepo.GetAll() method");
            }
            return _mapper.Map<IEnumerable<DataExpectedCost>>(expectedCostList);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, DataExpectedCost item)
        {
            var expCost = await _context.ExpectedCosts.FindAsync(id);
            if (expCost == null) 
            {
                throw new FindException("cannot find you expected cost for updating!!!", "find error in ExpectedCostRepo.Update(int,DataExpectedCost) method");
            }
            expCost = _mapper.Map<ExpectedCost>(item);
        }
    }
}
