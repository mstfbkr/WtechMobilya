using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mobilya.Entities
{
    public class Category:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public int CategoryMain { get; set; }
        [Required]
       

       public  ICollection<Product> Products { get; set; }
    }
}
