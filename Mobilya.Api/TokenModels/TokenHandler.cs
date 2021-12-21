using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Wtech.Api.TokenModels
{
    public class TokenHandler
    {

        public IConfiguration Configuration { get; set; }

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Token üretecek metod
        public Token CreateAccessToken(Users user)
        {
            Token token = new Token();

            //Security Keyin simetriğini(yansımasını) alır
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token: SecurityKey"]));
            SigningCredentials singingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//Şifreli kimlik oluşturur

            token.Expration = DateTime.Now.AddMinutes(5);//Token süresine 5 dk ekler

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:Configuration["Token:Issuer"],
                audience:Configuration["Token:Audience"],
                expires:token.Expration,
                notBefore:DateTime.Now,//Token üretildikten sonra ne zaman devreye girsin
                signingCredentials:singingCredentials
                );

            //Yeni bir access token üretir
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            token.RefreshToken = CreateRefreshToken();
            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] tokenArray = new byte[32];
            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(tokenArray);
                return Convert.ToBase64String(tokenArray);
            }
           
        }

    }
}
