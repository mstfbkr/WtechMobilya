using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Api.Helpers;
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
            return Ok(categorys);
        }
        
        [HttpPost("GetAlldt")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAlldt()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var categorydata = from tempcustomer in await _categoryService.GetAllCategory() select tempcustomer;
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    categorydata = categorydata.OrderBy(s => s.CategoryName == (sortColumn + " " + sortColumnDirection));
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    categorydata = categorydata.Where(m => m.CategoryName.Contains(searchValue)
                                                          || m.CategoryId.ToString().Contains(searchValue));
                }
                recordsTotal = categorydata.Count();
                var data = categorydata.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //[HttpGet("GetAll")]
        //public async Task<Response<IEnumerable<Category>>> GetAll()
        //{​​​​​​
        //    var categorys = await _categoryService.GetAllCategory();
        //    if (!categorys.Any())
        //    {​​​​​​
        //        return new Response<IEnumerable<Category>>().NoContent();
        //    }​​​​​​
        //    //List olsaydı .count parantez yazmamız doğru değil.
        //    return new Response<IEnumerable<Product>>().Ok(categorys.Count(), categorys);
        //}​​​​​​


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            try
            {
                if (category.CategoryId== 0)
                    await _categoryService.CreateCategory(category);
                else await _categoryService.UpdateCategory(category);
                return Ok(category);
            }
            catch (Exception)
            {
                throw;
            }



            var createCategory = await _categoryService.CreateCategory(category);
            return Ok(createCategory);
        }


        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category= await  _categoryService.GetCategoryById(id);
            await _categoryService.DeleteCategoryAsync(category);
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
