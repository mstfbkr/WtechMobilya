using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mobilya.Api.Helpers;
using Mobilya.DataAccess;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wtech.Api.TokenModels;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MobilyaDBContext _context;//Readonly'i herhangi bir newleme gerektirmeden çağırıp kullanılabilmek için yaptık 
                                                   //Static metottdan Static olmayan değişken çağıramazsınız
                                                   //Bir değişkenin değimesini istemiyorsak sabit kalmasını istiyorsak static yaparız
                                                   //Sadece Contractor metotlarla değişkenin değeri değiştirilebilir



        //using Microsoft.Extensions.Configuration;  ekledik
        private readonly IConfiguration _configuration;
        private readonly GenericHelperMothods _genericHelperMothods;


        public LoginController(MobilyaDBContext context, IConfiguration configuration, GenericHelperMothods genericHelperMothods)
        {
            _context = context;
            _configuration = configuration;
            _genericHelperMothods = genericHelperMothods;
        }


        [HttpPost("[action]")]//action yazınca metot ismini baz alır "Create" şeklinde baz alır ve /Create şeklinde urlde çıkar
        public async Task<bool> Create([FromBody] Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost("[action]")]
        public async Task<Token> Login([FromBody] UserLogin userLogin)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(w => w.Email == userLogin.Email && w.PassWord == userLogin.Password);//girilen kullanıcı sistemde var mı diye kontrol eder

            if (user != null)
            {
                return await _genericHelperMothods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;
        }

        [HttpPost("[action]")]
        public async Task<Token> RefreshTokenLogin([FromBody] string refreshToken)
        {
            Users user = await _context.Users.FirstOrDefaultAsync(w => w.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                return await _genericHelperMothods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;
        }
       


    }
}
