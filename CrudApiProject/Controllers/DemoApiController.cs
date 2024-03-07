using Azure;
using CrudApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;


namespace CrudApiProject.Controllers
{
  [Route( "api/demo" )]
  [ApiController]
  [Authorize]
  public class DemoApiController : ControllerBase
  {
    private readonly APIDemoDbClass _apiDemoDbClass;

   
    public readonly IConfiguration _configuration;
 

    public DemoApiController( APIDemoDbClass apiDemoDbClass , IConfiguration configuration )
    {
      _apiDemoDbClass = apiDemoDbClass;
      _configuration = configuration;
    }
    [HttpGet]
   
    [Route( "get-users-list" )]
    public async Task<IActionResult> GetAsync()
    {
      var users = await _apiDemoDbClass.Users.ToListAsync();
      return Ok( users );
    }
    [HttpGet]
    
    [Route( "get-users-by-id/{UserId}" )]
    public async Task<IActionResult> GetUserByIdAsync( int UserId )
    {
      var user = await _apiDemoDbClass.Users.FindAsync( UserId );
      return Ok( user );
    }


    [HttpPost]
    
    [Route( "create-user" )]
    [Authorize( Roles = "Admin" )]
    public  Users PostAsync( Users user )
    {
      var u = _apiDemoDbClass.Users.Add( user );
      _apiDemoDbClass.SaveChanges();
      return u.Entity;
      //_apiDemoDbClass.Users.Add( user );
      //await _apiDemoDbClass.SaveChangesAsync();
      //return Created( $"/get-user-by-id/{user.Id}", user );

    }
    [HttpPut]
    
    [Route( "update-user" )]
    [Authorize( Roles = "Admin" )]
    public async Task<IActionResult> PutAsync( Users userToUpdate )
    {
      _apiDemoDbClass.Users.Update( userToUpdate );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();
    }
    [HttpDelete]
    [Route( "delete-user" )]
    public async Task<IActionResult> DeleteAsync( int UserId )
    {
      var userToDelete = await _apiDemoDbClass.Users.FindAsync( UserId );
      if( userToDelete == null ) { return NotFound(); }
      _apiDemoDbClass.Remove( userToDelete );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();

    }
    [HttpGet]
    [Route( "get-products-list" )]
    public async Task<IActionResult> GetProductsAsync()
    {
      var product = await _apiDemoDbClass.products.ToListAsync();
      return Ok( product );
    }

    [HttpGet]
    [Route( "get-product-by-id/{ProductId}" )]
    public async Task<IActionResult> GetProductsByIdAsync(int ProductId)
    {
      var product = await _apiDemoDbClass.products.FindAsync( ProductId );
      return Ok( product );
    
    }
    [HttpPost]
    [Authorize( Roles = "Admin" )]
    [Route( "create-product" )]
    public async Task<IActionResult> PostProductAsync( Products product )
    {
      _apiDemoDbClass.products.Add( product );
      await _apiDemoDbClass.SaveChangesAsync();
      return Created( $"/get-product-by-id/{product.id}", product );
    }

    [HttpPut]
    [Authorize( Roles = "Admin" )]
    [Route( "update-product" )]
    public async Task<IActionResult> PutProductAsync( Products productToUpdate )
    {
      _apiDemoDbClass.products.Update( productToUpdate );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();
    }
    [HttpDelete]
    [Route( "delete-product" )]
    public async Task<IActionResult> DeleteProductAsync( int ProductId )
    {
      var productToDelete = await _apiDemoDbClass.products.FindAsync( ProductId );
      if ( productToDelete == null ) { return NotFound(); }
      _apiDemoDbClass.Remove( productToDelete );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();

    }


    [HttpGet]
    [Route( "get-orders-list" )]
    public async Task<IActionResult> GetOrdersAsync()
    {
      var orders = await _apiDemoDbClass.Orders.ToListAsync();
      return Ok( orders );
    }

    [HttpGet]
    [Route( "get-order-by-id/{OrderId}" )]
    public async Task<IActionResult> GetOrdersByIdAsync( int OrderId )
    {
      var order = await _apiDemoDbClass.products.FindAsync( OrderId );
      return Ok( order );

    }
    /// validate 
    [HttpPost]
    [Authorize( Roles = "Admin" )]
    [Route( "create-order" )]
    public async Task<IActionResult> PostOrderAsync( Orders order )
      
    {

      var blog1 = _apiDemoDbClass.Users
                      .Where( b => b.Id == order.user_id )
                      
                      .FirstOrDefault();

      //_apiDemoDbClass.Orders.Include( h => h.user);
      //var b = _apiDemoDbClass.Orders.Include( a => a.user ).FirstOrDefault( a => a.user_id == order.user_id );
      order.user = blog1; // Access the related book

      _apiDemoDbClass.Orders.Add( order );
      await _apiDemoDbClass.SaveChangesAsync();
          return Created( $"/order/{order.id}", order );
        
      
    }

    [HttpPut]
    [Route( "update-order" )]
    public async Task<IActionResult> PutOrderAsync( Orders orderToUpdate )
    {
      _apiDemoDbClass.Orders.Update( orderToUpdate );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();
    }

    /// <summary>
    [HttpPut]
    [Authorize( Roles = "Admin" )]
    [Route( "update-order/{orderid}/{status}" )]
    public async Task<IActionResult> PutOrderstatusAsync( int orderid, String status )
    {
      Orders order = await _apiDemoDbClass.Orders.FindAsync( orderid );
      
      order.status = status;

      _apiDemoDbClass.Orders.Update( order );
      await _apiDemoDbClass.SaveChangesAsync();
      return Ok(  order );
    }
    /// </summary>
    /// 
    /// <returns></returns>

    [HttpDelete]
    [Route( "delete-order" )]
    public async Task<IActionResult> DeleteOrderAsync( int OrderId )
    {
      var orderToDelete = await _apiDemoDbClass.Orders.FindAsync( OrderId );
      if ( orderToDelete == null ) { return NotFound(); }
      _apiDemoDbClass.Remove( orderToDelete );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();

    }


    /// <summary>
    /// ///////////////////////
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route( "get-order_products-list" )]
    public async Task<IActionResult> GetOrderProductsAsync()
    {
      var orderproducts = await _apiDemoDbClass.orderProducts.ToListAsync();
      return Ok( orderproducts );
    }

    [HttpGet]
    [Route( "get-order_products-by-id/{Order_id}/{Product_id}" )]
    public async Task<IActionResult> GetOrderProductsByIdAsync( int Order_id, int Product_id )
    {
      if ( !ModelState.IsValid )
      {
        return BadRequest( ModelState );
      }
      var orderproducts = await _apiDemoDbClass.orderProducts.FindAsync( Order_id, Product_id );
      return Ok( orderproducts );

      }
    [HttpPost]
    [Route( "create-order_products" )]
    [Authorize(Roles ="User")]
    public async Task<IActionResult> PostOrderProductsAsync( order_products orderproducts )

    {


      var ord = _apiDemoDbClass.Orders
                      .Where( b => b.id == orderproducts.order_id )

                      .FirstOrDefault();
      var pro = _apiDemoDbClass.products
                      .Where( b => b.id == orderproducts.product_id )

                      .FirstOrDefault();

      //_apiDemoDbClass.Orders.Include( h => h.user);
      //var b = _apiDemoDbClass.Orders.Include( a => a.user ).FirstOrDefault( a => a.user_id == order.user_id );
      orderproducts.order = ord; 
      orderproducts.product = pro;

      _apiDemoDbClass.orderProducts.Add( orderproducts );

      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "select available_quantity from products where products.id=" + orderproducts.product_id, con );
      DataTable dt = new DataTable();
      adapter.Fill( dt );
      Models.Response response = new Models.Response();
      if ( dt.Rows.Count > 0 )


      {
        var x = dt.Rows[ 0 ].Field<int>( "available_quantity" );


        if ( dt.Rows[0].Field<int >("available_quantity")>orderproducts.product_quantity )
        {
          _apiDemoDbClass.orderProducts.Add( orderproducts );
          await _apiDemoDbClass.SaveChangesAsync();
          return Created( $"/orderProduct-by-id/{orderproducts.order_id}", orderproducts );
        }
      }
      else
      {
        response.StatusCode = 100;
        response.ErrorMessage = "No data found";

      }
      return BadRequest( response );








      //_apiDemoDbClass.orderProducts.Add( order_products );
      //await _apiDemoDbClass.SaveChangesAsync();
      //return Created( $"/get-order_products-by-id/{order_products.Order_id} {order_products.Product_id}", order_products );
    }

    [HttpPut]
    [Route( "update-order_products" )]
    public async Task<IActionResult> PutOrderProductsAsync( order_products orderProductsToUpdate )
    {
      _apiDemoDbClass.orderProducts.Update( orderProductsToUpdate );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();
    }
    [HttpDelete]
    [Route( "delete-order_products/{Order_id}/{Product_id}" )]
    public async Task<IActionResult> DeleteOrderProductsAsync( int Order_id, int Product_id )
    {
      var orderProductsToDelete = await _apiDemoDbClass.orderProducts.FindAsync( Order_id, Product_id );
      if ( orderProductsToDelete == null ) { return NotFound(); }
      _apiDemoDbClass.Remove( orderProductsToDelete );
      await _apiDemoDbClass.SaveChangesAsync();
      return NoContent();

    }
  }
}
