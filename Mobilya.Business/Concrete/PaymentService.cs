using Mobilya.Business.Abstract;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            var newpayment = await _unitOfWork.payment.AddAsync(payment);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return newpayment;
        }

        public void DeletePayment(Payment payment)
        {
            _unitOfWork.payment.RemoveAsync(payment);
        }

        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            return await _unitOfWork.payment.GetAllAsync();
        }

        public async Task<Payment> GetPaymentById(int id)
        {
            return await _unitOfWork.payment.GetById(id);
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _unitOfWork.payment.Update(payment);
            await _unitOfWork.CommitAsync();
            return payment;
        }
    }
}
