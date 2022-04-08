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
    public class OrderCryptaApi : IModiferDataAsynk<OrderCryptaBL>
    {
        private OrderRepo Order;
        private UserRepo us;
        private CryptaRepo cry;

        public OrderCryptaApi(OrderRepo OrderRepo, UserRepo userRepo, CryptaRepo cryrepo) 
        {
            Order = OrderRepo;
            us = userRepo;
            cry = cryrepo;
        }

        public async Task Create(OrderCryptaBL item)
        {
            var user = await us.FindById(item.UserId);
            if (user == null) 
            {
                throw new ValidationException("not found user", "not found user");
            }
            var crypta = await cry.FindById(item.CryptaId);
            if (crypta == null) 
            {
                throw new ValidationException("not found Crypta by Id", "not found Crypta by Id");
            }
            Order order = new Order { UserId = user.Id, Count = item.Money / crypta.Cost, Crypta = crypta, CryptaId = crypta.Id, User = user };
            await Order.Create(order);
        }

        public async Task Delete(OrderCryptaBL item)
        {
            var user = await us.FindById(item.UserId);
            if (user == null)
            {
                throw new ValidationException("not found user", "not found user");
            }
            var crypta = await cry.FindById(item.CryptaId);
            if (crypta == null)
            {
                throw new ValidationException("not found Crypta by Id", "not found Crypta by Id");
            }
            Order order = new Order { UserId = user.Id, Count = item.Money / crypta.Cost, Crypta = crypta, CryptaId = crypta.Id, User = user };
            await Order.Delete(order);
        }

        public async Task Dispose()
        {
            await Order.Dispose();
            await us.Dispose();
            await cry.Dispose();
        }

        public async Task<OrderCryptaBL> FindById(int id)
        {
            var order = await Order.FindById(id);
            if (order == null) 
            {
                throw new ValidationException("not found order by id"," not found order by id");
            }
            var crypta = await cry.FindById(order.CryptaId);
            OrderCryptaBL ord = new OrderCryptaBL() { Count = order.Count, UserName = order.User.Name };
            return ord;
        }

        public async Task<IEnumerable<OrderCryptaBL>> GetAll()
        {
            var list = (await Order.GetAll()).ToList();
            var orderList = new List<OrderCryptaBL>();
            foreach (var c in list) 
            {
                var crypta = await cry.FindById(c.CryptaId);
                orderList.Add(new OrderCryptaBL { Count = c.Count, UserName = c.User.Name });
            }
            return orderList;
        }

        public async Task Save()
        {
            await Order.Save();
        }

        public async Task Update(int id, OrderCryptaBL item)
        {
            var order = await Order.FindById(id);
            if (order == null) 
            {
                throw new ValidationException("not found order by id", "not found order by id");
            }
            order = new Order { Count = order.Count, CryptaId = order.CryptaId, UserId = order.UserId };
        }
    }
}
