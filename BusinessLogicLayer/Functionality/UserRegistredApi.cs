using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Functionality
{
    public class UserRegistredApi : IModiferDataAsynk<UserRegistred>
    {
        private UserRepo UserRepo;
        public UserRegistredApi(UserRepo userRepo)
        {
            UserRepo = userRepo;
        }

        public async Task Create(UserRegistred item)
        {
            if (item == null)
            {
                throw new ValidationException("item is null", "item is null");
            }
            var user = new User() { Age = item.Age, ExpectedCosts = null, Id = item.Id, Name = item.Name, Orders = null, Password = item.Password };
            await UserRepo.Create(user);
        }

        public async Task Delete(UserRegistred item)
        {
            if (item == null)
            {
                throw new ValidationException("item is null", "item is null");
            }
            var user = new User() { Age = item.Age, ExpectedCosts = null, Id = item.Id, Name = item.Name, Orders = null, Password = item.Password };
            if (user == null)
            {
                throw new ValidationException("not found user by id", "not found user by id");
            }
            await UserRepo.Delete(user);
        }

        public async Task Dispose()
        {
            await UserRepo.Dispose();
        }

        public async Task<UserRegistred> FindById(int id)
        {
            var user = await UserRepo.FindById(id);
            if (user == null)
            {
                throw new ValidationException("not found user by id", "not found user by id");
            }
            return new UserRegistred() { Age = user.Age, Email = user.Email, Id = user.Id, Name = user.Name, Password = user.Password };
        }

        public async Task<IEnumerable<UserRegistred>> GetAll()
        {
            var list = await UserRepo.GetAll();
            var registredList = new List<UserRegistred>();
            foreach (var c in list)
            {
                registredList.Add(new UserRegistred() { Age = c.Age, Email = c.Email, Id = c.Id, Name = c.Name, Password = c.Password });
            }

            return registredList;
        }

        public async Task Save()
        {
            await UserRepo.Save();
        }

        public async Task Update(int id, UserRegistred item)
        {
            if (item == null)
            {
                throw new ValidationException("item is null", "item is null");
            }
            var user = await UserRepo.FindById(id);
            user.Password = item.Password;
            user.Name = item.Name;
            user.Id = item.Id;
            await UserRepo.Update(id, user);
        }
    }
}
