using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.DataAccess.Concrete
{
    public class UsersRepository : Repository<Users>, IUsers
    {
        private MobilyaDBContext _mobilyaDBContext;


        public UsersRepository(MobilyaDBContext mobilyaDBContext) : base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

    }
}
