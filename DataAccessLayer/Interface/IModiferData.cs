using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IModiferData<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Update(int id, T item);
        void Create(T item);
        void Delete(T item);
        void Dispose();
        void Save();
    }

    public interface IModiferDataAsynk<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task Update(int id, T item);
        Task Create(T item);
        Task Delete(T item);
        Task Dispose();
        Task Save();
    }
}
