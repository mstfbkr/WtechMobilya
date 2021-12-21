using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mobilya.Entities
{
    public class Product:BaseEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public int ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        [Required]
        public bool ProductActive { get; set; }
        public int ProductCategoryId { get; set; }

        public Category category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
