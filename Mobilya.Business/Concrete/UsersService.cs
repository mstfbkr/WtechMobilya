using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mobilya.Business.Abstract;
using Mobilya.Api.Helpers;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Mobilya.Business.Concrete
{
    public class UsersService : IUserService
    {
        private IUnitOfWork _unitOfWork;


        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Users> CreateUser(Users user)
        {
            return await _unitOfWork.users.AddAsync(user);
        }

        public void DeleteUser(Users user)
        {
            _unitOfWork.users.RemoveAsync(user);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUser()
        {
            return await _unitOfWork.users.GetAllAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _unitOfWork.users.GetById(id);
        }
        public async Task<Users> UpdateUser(Users user)
        {
            _unitOfWork.users.Update(user);
            await _unitOfWork.CommitAsync();
            return user;
        }
    }
}
