using CrudApiProject.Data;
using CrudApiProject.Models;
using CrudApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiProject.Controllers
{
  [Authorize]
  [ApiController]
  [Route( "api/orders" )]
  public class order_controller : ControllerBase
  {
    private readonly order_service _order_service;

    public order_controller( order_service orderService )
    {
      _order_service = orderService;
    }
    [HttpGet]
    [Route( "get-orders" )]
    public async Task<ActionResult<IEnumerable<order_view_model>>> GetAllOrders()
    {
      var products = await _order_service.GetAllOrders();
      return Ok( products );
    }


    [HttpGet]
    [Route( "get-order/{id}" )]
    public async Task<ActionResult<order_view_model>> GetOrderById( int id )
    {
      var order = await _order_service.GetOrderById( id );

      if ( order == null )
      {
        return NotFound();
      }

      return order;
    } 

    [HttpPost]
    [Route( "create-order" )]
    [Authorize( Roles = "Admin" )]
    public async Task<ActionResult<order_view_model>> CreateOrder( [FromBody] order_view_model orderViewModel )
    {
      var createdOrder = await _order_service.CreateOrder( orderViewModel );
      return CreatedAtAction( nameof( GetOrderById ), new { id = createdOrder.id }, createdOrder );
    }

    [HttpPut]
    [Route( "update-order-by-id/{id}" )]

    public async Task<IActionResult> UpdateOrder( int id, [FromBody] order_view_model orderViewModel )
    {
      await _order_service.UpdateOrder( id, orderViewModel );
      return NoContent();
    }

    [HttpDelete( "delete-order/{id}" )]
    public async Task<IActionResult> DeleteUser( int id )
    {
      await _order_service.DeleteOrder( id );
      return NoContent();
    }

    [HttpPut]
    [Authorize( Roles = "Admin" )]
    [Route( "update-orderstatus-by-id/{id}/{status}" )]
    public async Task<IActionResult> UpdateOrderStatus( int id ,String status)
    {
      await _order_service.UpdateOrderStatus( id , status );
      return NoContent();
    }
  }
}

