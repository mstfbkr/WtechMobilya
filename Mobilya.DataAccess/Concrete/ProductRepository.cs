using Microsoft.EntityFrameworkCore;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private MobilyaDBContext _mobilyaDBContext;

        public ProductRepository(MobilyaDBContext mobilyaDBContext) : base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

        public async Task<Category> GetCategoryWithProductAsync(Product product)
        {
            return await _mobilyaDBContext.Categories.Include(w => w.Products ==product).FirstOrDefaultAsync();
        }
    }

}