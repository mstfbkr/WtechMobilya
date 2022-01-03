using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IUserService
    {
        Task<Users> CreateUser(Users user);

        Task<IEnumerable<Users>> GetAllUser();

        Task<Users> GetUserById(int id);

        void DeleteUser(Users user);

        Task<Users> UpdateUser(Users user);

    }
}
