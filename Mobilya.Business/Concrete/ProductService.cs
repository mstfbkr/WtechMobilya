using Mobilya.Business.Abstract;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 

namespace Mobilya.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product product)
        {
             await _unitOfWork.product.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return product;
        }

        public async Task DeleteProductAsync(Product product)
        {
            await _unitOfWork.product.RemoveAsync(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _unitOfWork.product.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.product.GetById(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _unitOfWork.product.Update(product);
            await _unitOfWork.CommitAsync();
            return product;
        }
    }
}
