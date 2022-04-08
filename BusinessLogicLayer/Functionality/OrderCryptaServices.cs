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
using AutoMapper;
using GeneralObjects.Exceptions;

namespace BusinessLogicLayer.Functionality
{
    public class OrderCryptaServices : IModiferDataAsynk<OrderBL>
    {
        private OrderRepo _orderRepo;
        private IMapper _mapper;

        public OrderCryptaServices(OrderRepo OrderRepo, IMapper mapper) 
        {
            _orderRepo = OrderRepo;
            _mapper = mapper;
        }

        public async Task Create(OrderBL item)
        {
            var dataOrder = _mapper.Map<DataOrder>(item);
            await _orderRepo.Create(dataOrder);
            await _orderRepo.Save();
        }

        public async Task Delete(OrderBL item)
        {
            try
            {
                var order = await _orderRepo.FindById(item.Id);
                await _orderRepo.Delete(order);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }               
            await _orderRepo.Save();            
        }

        public async Task Dispose()
        {
            await _orderRepo.Dispose();
        }

        public async Task<OrderBL> FindById(int id)
        {
            DataOrder order;
            try
            {
                order = await _orderRepo.FindById(id);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }
            
            return _mapper.Map<OrderBL>(order);
        }

        public IEnumerable<OrderBL> GetAll()
        {
            IEnumerable<DataOrder> orderList;
            try
            {
                orderList = _orderRepo.GetAll();
            }
            catch (EmptyListException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Property);
            }
            
            return _mapper.Map<IEnumerable<OrderBL>>(orderList);
        }

        public async Task Save()
        {
            await _orderRepo.Save();
        }

        public async Task Update(int id, OrderBL item)
        {
            var order = _mapper.Map<DataOrder>(item);
            try
            {
                await _orderRepo.Update(id, order);
            }
            catch (FindException e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.property);
            }

            await _orderRepo.Save();
            
        }
    }
}
