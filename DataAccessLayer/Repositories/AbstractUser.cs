using AutoMapper;
using DataAccessLayer.DataModel;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;
using GeneralObjects.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class AbstractUser<T> : IModiferDataAsynk<T>
        where T : DataUser
    {
        private CryptaContext _context;
        private IMapper _mapper;

        public AbstractUser(CryptaContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(T item)
        {
            var user = _mapper.Map<User>(item);
            await _context.Users.AddAsync(user);
        }

        public async Task Delete(T item)
        {
            var user = await _context.Users.FindAsync(item.Id);
            if (user is null) 
            {
                throw new FindException("cannot find user for deleting!!!", "find error in AbstractUser.Delete(" + typeof(T).Name + ") method");
            }
            _context.Users.Remove(user);
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<T> FindById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) 
            {
                throw new FindException("cannot find you user!!!", "find error in AbstractUser.FindById(" + typeof(T).Name + ") method");
            }
            return _mapper.Map<T>(user);
        }

        public IEnumerable<T> GetAll()
        {
            var userList = _context.Users.AsEnumerable();
            if (userList.Count() == 0) 
            {
                throw new EmptyListException("not found allow users!!!","EmptyListEror in AbstractUser.GetAll() method");
            }
            return _mapper.Map<IEnumerable<T>>(userList);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, T item)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null) 
            {
                throw new FindException("not found user for updating!!!","find error in AbstractUser.Update(int," + typeof(T).Name + ") method");
            }
            user = _mapper.Map<User>(item);
        }

        public T FindByEmail(string Email) 
        {
            var user =  _context.Users.FirstOrDefault(c => c.Email == Email);
            if (user is null)
            {
                throw new FindException("cannot find you user!!!","find error in AbstractUser.FindByEmail(string) method");
            }
            var userModel = _mapper.Map<T>(user);

            return userModel;
        }
    }
}
