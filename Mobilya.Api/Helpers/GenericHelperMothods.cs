using Microsoft.Extensions.Configuration;
using Mobilya.DataAccess;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wtech.Api.TokenModels;

namespace Mobilya.Api.Helpers
{
    public class GenericHelperMothods
    {
        public GenericHelperMothods()
        {

        }

        public async Task<Token> CreateRefreshToken(Users users,MobilyaDBContext _context, IConfiguration _configuration)
        {

            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(users);//user için token üretiyoruz

            //refresh token kullanıcı tablosuna işleniyor
            users.RefreshToken = token.RefreshToken;
            users.RefreshTokenEndDate = token.Expration.AddMinutes(5);
            await _context.SaveChangesAsync();
            return token;

        }

    }
}
