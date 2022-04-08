using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class AbstractClass<T, D> : IModiferDataAsynk<T>
        where T : class
        where D : DbContext
    {
        D context;

        public AbstractClass(D _context) 
        {
            context = _context;
        } 

        public async Task Create(T item)
        {
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await context.DisposeAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, T item)
        {
            var unit = await context.Set<T>().FindAsync(id);
            unit = item;
            await context.SaveChangesAsync();
        }
    }
}
