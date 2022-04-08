using AutoMapper;
using BusinessLogicLayer.Model;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using GeneralObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Functionality
{
    public class UserRegistredServices : IModiferDataAsynk<UserRegistredBL>
    {
        private UserRepo _userRepo;
        private IMapper _mapper;
        public UserRegistredServices(UserRepo userRepo, IMapper mapper )
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task Create(UserRegistredBL item)
        {
            var user = _mapper.Map<DataUser>(item);
            await _userRepo.Create(user);
            await _userRepo.Save();
        }

        public async Task Delete(UserRegistredBL item)
        {           
            try
            {
                var user = await _userRepo.FindById(item.Id);
                await _userRepo.Delete(user);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
            await _userRepo.Save();
        }

        public async Task Dispose()
        {
            await _userRepo.Dispose();
        }

        public async Task<UserRegistredBL> FindById(int id)
        {
            DataUser user;
            try
            {
                user = await _userRepo.FindById(id);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
            return _mapper.Map<UserRegistredBL>(user);
        }

        public IEnumerable<UserRegistredBL> GetAll()
        {
            IEnumerable<DataUser> userList;
            try
            {
                userList = _userRepo.GetAll();
            }
            catch (EmptyListException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Property);
            }

            return _mapper.Map<IEnumerable<UserRegistredBL>>(userList);
        }

        public async Task Save()
        {
            await _userRepo.Save();
        }

        public async Task Update(int id, UserRegistredBL item)
        {
            var user = _mapper.Map<DataUser>(item);
            try
            {
                await _userRepo.Update(id, user);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
        }

        public UserRegistredBL FindByEmail(string Email) 
        {
            DataUser user;
            try
            {
                user = _userRepo.FindByEmail(Email);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }

            return _mapper.Map<UserRegistredBL>(user);
        }
    }
}
