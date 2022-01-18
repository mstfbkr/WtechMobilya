using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);

        Task<IEnumerable<Product>> GetAllProduct();

        Task DeleteProductAsync(Product product);

        Task<Product> GetProductById(int id);

        Task<Product> UpdateProduct(Product product);

    }
}
