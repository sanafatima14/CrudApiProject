using CrudApiProject.Models;
using CrudApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApiProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class product_controller : ControllerBase
    {
        private readonly product_service _productService;

        public product_controller( product_service productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("get-products")]
        public async Task<ActionResult<IEnumerable<product_view_model>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("get-product/{id}")]
        public async Task<ActionResult<product_view_model>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        [Route("create-product")]
        [Authorize(Roles = "Admin")] 
        public async Task<ActionResult<product_view_model>> CreateProduct([FromBody] product_view_model productViewModel)
        {
            var createdProduct = await _productService.CreateProduct(productViewModel);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.id }, createdProduct);
        }

        [HttpPut]
        [Route("update-product/{id}")]
        [Authorize( Roles = "Admin" )]  
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] product_view_model productViewModel)
        {
            await _productService.UpdateProduct(id, productViewModel);
            return NoContent();
        }

        [HttpDelete]
        [Route("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
