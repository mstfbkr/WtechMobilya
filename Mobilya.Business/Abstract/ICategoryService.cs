using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);

        Task<IEnumerable<Category>> GetAllCategory();

        Task<Category> GetCategoryById(int id);

        Task DeleteCategoryAsync(Category category);

        Task<Category> UpdateCategory(Category category);

    }
}
