using CrudApiProject.Models;
using CrudApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiProject.Controllers

{
  [Authorize]
  [ApiController]
  [Route( "api/order_products" )]
  public class order_product_controller : ControllerBase
  {
    private readonly order_product_service _orderProductService;
    public order_product_controller( order_product_service orderProductService )
    {
      _orderProductService = orderProductService;
    }

    [HttpGet]
    [Route( "get-order_products" )]
    public async Task<ActionResult<IEnumerable<order_product_view_model>>> GetAllOrderProducts()
    {
      var order_products = await _orderProductService.GetAllOrderProducts();
      return Ok( order_products );
    }

    [HttpGet]
    [Route( "get-order_products/{order_id}/{product_id}" )]
    public async Task<ActionResult<order_product_view_model>> GetOrderProductById( int order_id,int product_id )
    {
      var order_products = await _orderProductService.GetOrderProductById( order_id,product_id );

      if ( order_products == null )
      {
        return NotFound();
      }

      return order_products;
    }

    [HttpPost]
    [Route( "create-order_products" )]
    [Authorize( Roles = "user" )]
    public async Task<ActionResult<order_product_view_model>> CreateOrderProduct( [FromBody] order_product_view_model orderProductViewModel )
    {
      var createdOrderProduct = await _orderProductService.CreateOrderProduct( orderProductViewModel );
      if( createdOrderProduct !=null)
      
        return CreatedAtAction( nameof( GetOrderProductById ), new { product_id = createdOrderProduct.product_id,order_id = createdOrderProduct.product_id}, createdOrderProduct );
   else 
        return BadRequest("avilable quantity is less");
    }

    [HttpPut]
    [Route( "update-order_products/{product_id}/{order_id}" )]
    public async Task<IActionResult> UpdateOrderProduct( int order_id, int product_id, [FromBody] order_product_view_model orderProductViewModel )
    {
      await _orderProductService.UpdateOrderProduct( order_id,product_id, orderProductViewModel );
      return NoContent();
    }

    [HttpDelete]
    [Route( "delete-product/{product_id}/{order_id}" )]
    public async Task<IActionResult> DeleteProduct( int order_id, int product_id )
    {
      await _orderProductService.DeleteOrderProduct( order_id,product_id );
      return NoContent();
    }
  }
}
