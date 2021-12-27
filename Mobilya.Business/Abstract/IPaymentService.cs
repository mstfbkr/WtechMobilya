using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IPaymentService
    {
        Task<Payment> CreatePayment(Payment payment);

        Task<IEnumerable<Payment>> GetAllPayment();

        Task<Payment> GetPaymentById(int id);

        void DeletePayment(Payment payment);

        Task<Payment> UpdatePayment(Payment payment);

    }
}
