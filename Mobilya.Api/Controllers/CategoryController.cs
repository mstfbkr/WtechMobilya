using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {            
            var categorys = await _categoryService.GetAllCategory();
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(categorys);
            
            return Ok(JSONString);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var createCategory = await _categoryService.CreateCategory(category);
            return Ok(createCategory);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Category category)
        {
                _categoryService.DeleteCategory(category);
                return Ok("Category Deleted");
            
        }

        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            if (_categoryService.GetCategoryById(category.CategoryId) != null)
            {
                return Ok(_categoryService.UpdateCategory(category));
            }
            return NotFound();
        }

    }
}
