using Microsoft.EntityFrameworkCore;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private MobilyaDBContext _mobilyaDBContext;

        public CategoryRepository(MobilyaDBContext mobilyaDBContext):base(mobilyaDBContext)
        {
            _mobilyaDBContext = mobilyaDBContext;
        }

        public async Task<IEnumerable<Product>> GetProductWithCategory(Category category)
        {
            return (IEnumerable<Product>)await _mobilyaDBContext.Products.Include(a => a.category.CategoryId == category.CategoryId).ToListAsync();
        }
    }
}
