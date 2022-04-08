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
    public class OrderRepo : IModiferDataAsynk<DataOrder>
    {
        private CryptaContext _context;
        private IMapper _mapper;
        public OrderRepo(CryptaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;       
        }

        public async Task Create(DataOrder item)
        {
            var order = _mapper.Map<Order>(item);
            await _context.Orders.AddAsync(order);
        }

        public async Task Delete(DataOrder item)
        {
            var order = await _context.Orders.FindAsync(item.Id);
            if (order is null)
            {
                throw new FindException("cannot find you order for deleting!!!","find error in OrderRepo.Delete(DataOrder) method");
            }
            _context.Orders.Remove(order);
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }

        public async Task<DataOrder> FindById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null) 
            {
                throw new FindException("cannot find you order!!!","find error in OderedRepo.FindById(int) method");
            }
            return _mapper.Map<DataOrder>(order);
        }

        public IEnumerable<DataOrder> GetAll()
        {
            var order = _context.Orders.AsEnumerable();
            if (order.Count() == 0) 
            {
                throw new EmptyListException("you not make any orders yet", "empty list in OrderRepo.GetAll() method");
            }
            return _mapper.Map<IEnumerable<DataOrder>>(order);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, DataOrder item)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order is null) 
            {
                throw new FindException("cannot find orders for updating!!!","find error in OrderRepo.Update(int,DataOrder)");
            }
            order = _mapper.Map<Order>(item);
        }
    }
}
