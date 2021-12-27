using Mobilya.Business.Abstract;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Order> CreateOrder(Order order)
        {
            var neworder = await _unitOfWork.order.AddAsync(order);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {                
                throw;
            }
            return neworder;
        }

        public void DeleteOrder(Order order)
        {
            _unitOfWork.order.RemoveAsync(order);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _unitOfWork.order.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.order.GetById(id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _unitOfWork.order.Update(order);
            await _unitOfWork.CommitAsync();
            return order;
        }
    }
}
