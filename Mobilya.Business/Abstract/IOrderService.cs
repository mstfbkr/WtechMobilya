using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);

        Task<IEnumerable<Order>> GetAllOrder();

        Task<Order> GetOrderById(int id);

        void DeleteOrder(Order order);

        Task<Order> UpdateOrder(Order order);
    }
}
