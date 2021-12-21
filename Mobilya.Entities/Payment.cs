using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mobilya.Entities
{
   public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public bool Allowed { get; set; }

        
       public Order Order { get; set; }

    }
}
