using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface ICategory : IRepository<Category>
    {
       Task<IEnumerable<Product>> GetProductWithCategory(Category category);
    }
}
