using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wtech.Api.TokenModels
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expration { get; set; }//Tokenın başlangıç tarihini tutar
        public string RefreshToken { get; set; }
    }
}
