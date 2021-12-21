using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wtech.Api.TokenModels
{
    public class UserLogin//Db tarafında işlem olmayacak javascriptten gelen giriş modeli olacak 
    {
        public string Email { get; set; }
        public int Password { get; set; }
    }
}
