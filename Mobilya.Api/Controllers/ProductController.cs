using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Post([FromBody] Product product)
        {
            var createProduct = _productService.CreateProduct(product);
            return Ok(createProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Product product)
        {
           
                _productService.DeleteProduct(product);
                return Ok("Product Deleted");
          
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (_productService.GetProductById(product.ProductId) != null)
            {
                return Ok(_productService.UpdateProduct(product));
            }
            return NotFound();
        }


    }
}
