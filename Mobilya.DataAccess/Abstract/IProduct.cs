using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IProduct:IRepository<Product>
    {
        Task<Category> GetCategoryWithProductAsync(Product product);
    }
}
