using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Entities
{
    public class BaseEntity
    {
        public DateTime CreatingDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActived { get; set; }

    }
}
