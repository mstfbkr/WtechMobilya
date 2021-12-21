using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.DataAccess.Concrete
{
    public class PaymentRepository:Repository<Payment>,IPayment
    {
        private MobilyaDBContext _mobilyaDBContext;

        public PaymentRepository(MobilyaDBContext mobilyaDBContext) : base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

    }
}
