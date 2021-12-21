using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.DataAccess.Concrete
{
    public class OrderRepository :Repository<Order>,IOrder
    {
        private MobilyaDBContext _mobilyaDBContext;

        public OrderRepository(MobilyaDBContext mobilyaDBContext) : base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }
    }
}
