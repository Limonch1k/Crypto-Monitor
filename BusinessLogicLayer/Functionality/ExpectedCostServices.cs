using BusinessLogicLayer.Model;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using DataAccessLayer.Model;
using DataAccessLayer.DataModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using AutoMapper;
using System.IO;
using GeneralObjects.Exceptions;

namespace BusinessLogicLayer.Functionality
{
    public class ExpectedCostApi : IModiferDataAsynk<ExpectedCostBL>
    {
        private ExpectedCostRepo _costRepo;
        private IMapper _mapper;
        public ExpectedCostApi(ExpectedCostRepo costRepo, IMapper mapper) 
        {
            _costRepo = costRepo;
            _mapper = mapper;
        }

        public async Task Create(ExpectedCostBL item)
        {
            DataExpectedCost expectedCost = _mapper.Map<DataExpectedCost>(item);
            await _costRepo.Create(expectedCost);            
            await _costRepo.Save();
        }

        public async Task Delete(ExpectedCostBL item)
        {           
            try
            {
                var expectedCost = await _costRepo.FindById(item.Id);
                await _costRepo.Delete(expectedCost);
            }
            catch (FindException e) 
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }           
        }

        public async Task Dispose()
        {
            await _costRepo.Dispose();
        }

        public async Task<ExpectedCostBL> FindById(int id)
        {
            DataExpectedCost dataExpCost;
            try
            {
                dataExpCost = await _costRepo.FindById(id);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
            return _mapper.Map<ExpectedCostBL>(dataExpCost);
        }

        public IEnumerable<ExpectedCostBL> GetAll()
        {
            IEnumerable<DataExpectedCost> expectedCostList;
            try
            {
                expectedCostList = _costRepo.GetAll();
            }
            catch (EmptyListException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Property);
            }
            
            return _mapper.Map<IEnumerable<ExpectedCostBL>>(expectedCostList);
        }

        public async Task Save()
        {
            await _costRepo.Save();
        }

        public async Task Update(int id, ExpectedCostBL item)
        {
            var expCost = _mapper.Map<DataExpectedCost>(item);
            try
            {
                await _costRepo.Update(id, expCost);
            }
            catch(FindException e) 
            {
                System.Console.WriteLine(e.property);
                throw new Exception("cannot update you expected cost data");
            }
            
        }
    }
}
