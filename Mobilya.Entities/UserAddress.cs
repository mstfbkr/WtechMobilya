using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mobilya.Entities
{
   public class UserAddress
    {

        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostCode { get; set; }
        [Required]
        public string AddressLine { get; set; }

        public Users User { get; set; }
    }
}
