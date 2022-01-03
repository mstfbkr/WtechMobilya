using Mobilya.Business.Abstract;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        public async Task<Category> CreateCategory(Category category)
        {
            var newcat = await _unitOfWork.category.AddAsync(category);
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return newcat;
        }

        public void DeleteCategory(Category category)
        {
            _unitOfWork.category.RemoveAsync(category);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _unitOfWork.category.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.category.GetById(id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _unitOfWork.category.Update(category);
            await _unitOfWork.CommitAsync();
            return category;
        }
    }
}
