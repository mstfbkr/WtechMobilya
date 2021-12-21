using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.DataAccess.Concrete
{
    public class AdminRepository:Repository<Admin>,IAdmin
    {
        private MobilyaDBContext _mobilyaDBContext;

        public AdminRepository(MobilyaDBContext mobilyaDBContext) : base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }
    }
}
