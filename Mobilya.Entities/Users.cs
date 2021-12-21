

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mobilya.Entities
{
    public class Users : IdentityUser<int>
    {
       
        [Required]
        public string UserSurname { get; set; }
        [Required]
        public int PassWord { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenEndDate { get; set; }

        public UserAddress UserAddress { get; set; }//1-1

        public ICollection<Order> Orders { get; set; }//1-n
    }
}
