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

namespace BusinessLogicLayer.Functionality
{
    public class newCryptaApi : IModiferDataAsynk<CryptaBL>
    {
        private CryptaRepo cryRepo;

        public newCryptaApi(CryptaRepo repo) 
        {
            cryRepo = repo;
        }
        public async Task Create(CryptaBL item)
        {
            if (item == null) 
            {
                throw new ValidationException("item is null", "item is null");
            }
            var crypta = new Crypta() { Cost = item.Cost, ExpectedCosts = null, Name = item.Name, Orders = null };
            await cryRepo.Create(crypta);
        }

        public async Task Delete(CryptaBL item)
        {
            if (item == null)
            {
                throw new ValidationException("item is null", "item is null");
            }
            var cryp = await cryRepo.FindById(item.Id);
            await cryRepo.Delete(cryp);
        }

        public async Task Dispose()
        {
            await cryRepo.Save();
        }

        public async Task<CryptaBL> FindById(int id)
        {
            var cryp = await cryRepo.FindById(id);
            if (cryp == null) 
            {
                throw new ValidationException("not fount Crypta", "not fount Crypta");
            }
            var newcryp = new CryptaBL() { Id = id, Cost = cryp.Cost, Name = cryp.Name };
            return newcryp;
        }

        public async Task<IEnumerable<CryptaBL>> GetAll()
        {
            var list = await cryRepo.GetAll();
            var newcryp = new List<CryptaBL>();
            foreach (var c in list) 
            {
                newcryp.Add(new CryptaBL { Id = c.Id, Cost = c.Cost, Name = c.Name });
            }
            return newcryp;
        }

        public async Task Save()
        {
            await cryRepo.Save();
        }

        public async Task Update(int id, CryptaBL item)
        {
            var cryp = await cryRepo.FindById(id);
            if (cryp == null) 
            {
                throw new ValidationException("not found Cryptas by id", "not found Cryptas by id");
            }
            Crypta crypta = new Crypta() { Cost = item.Cost, Name = item.Name, ExpectedCosts = cryp.ExpectedCosts, Orders = cryp.Orders, Id = cryp.Id};
            cryp = crypta;
        }
    }
}
