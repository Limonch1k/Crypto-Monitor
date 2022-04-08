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

namespace BusinessLogicLayer.Functionality
{
    public class newExpectedCostApi : IModiferDataAsynk<newExpectedCost>
    {
        private ExpectedCostRepo costRepo;
        private CryptaRepo cry;
        private UserRepo us;
        public newExpectedCostApi(ExpectedCostRepo costRepo, CryptaRepo crypto, UserRepo user) 
        {
            this.costRepo = costRepo;
            cry = crypto;
            us = user;
        }

        public async Task Create(newExpectedCost item)
        {
            var crypta = await cry.FindById(item.CryptaId);
            if (crypta == null) 
            {
                throw new ValidationException("not found crypta by CryptaId", "not found crypta by CryptaId");
            }
            var user = await us.FindById(item.UserId);
            if (user == null) 
            {
                throw new ValidationException("not found user", "not found user");
            }
            await costRepo.Create(new ExpectedCost() { Cost = item.Cost, UserId = item.UserId, CryptaId = item.CryptaId, Crypta = crypta, User = user });
        }

        public async Task Delete(newExpectedCost item)
        {
            var user = await us.FindById(item.UserId);
            if (user == null) 
            {
                throw new ValidationException("not found user", "not found user");
            }
            var exp = await costRepo.FindById(user.ExpectedCosts.Find(c => c.CryptaId == item.CryptaId).Id);
            if (exp == null) 
            {
                throw new ValidationException("Expected cost not found", "Expected cost not found");
            }
            await costRepo.Delete(exp);
        }

        public async Task Dispose()
        {
            await costRepo.Dispose();
            await us.Dispose();
            await cry.Dispose();
        }

        public async Task<newExpectedCost> FindById(int id)
        {
            var exp = await costRepo.FindById(id);
            if (exp == null)
            {
                throw new ValidationException("Expected cost not found", "Expected cost not found");
            }
            newExpectedCost cost = new newExpectedCost() { CryptaId = exp.CryptaId, Cost = exp.Cost, UserId = exp.UserId };
            return cost;
        }

        public async Task<IEnumerable<newExpectedCost>> GetAll()
        {
            var list = (await costRepo.GetAll()).ToList();
            var ExpectedList = new List<newExpectedCost>();
            foreach (var c in list)
            {
                ExpectedList.Add(new newExpectedCost { CryptaId = c.CryptaId, Cost = c.Cost, UserId = c.UserId });
            }
            return ExpectedList;
        }

        public async Task Save()
        {
            await costRepo.Save();
        }

        public async Task Update(int id, newExpectedCost item)
        {
            var user = await us.FindById(item.UserId);
            if (user == null)
            {
                throw new ValidationException("not found user", "not found user");
            }
            var exp = await costRepo.FindById(id);
            if (exp == null)
            {
                throw new ValidationException("Expected cost not found", "Expected cost not found");
            }
            exp = new ExpectedCost() { UserId = item.UserId, Cost = item.Cost, Crypta = user.ExpectedCosts.Find(c => c.CryptaId == item.CryptaId).Crypta, CryptaId = item.CryptaId, Id = id, User = user };
            return;
        }
    }
}
