
using CrudApiProject.Data;
using CrudApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace CrudApiProject.Services
{

  public class order_product_service
  {
    private readonly api_demo_db_class _dbContext;
    public readonly IConfiguration _configuration;
    public order_product_service( api_demo_db_class dbContext, IConfiguration configuration )
    {
      _dbContext = dbContext;
      _configuration = configuration;
    }

    public async Task<IEnumerable<order_product_view_model>> GetAllOrderProducts()
    {
      var order_products = await _dbContext.order_products.ToListAsync();
      var orderProductViewModels = order_products.Select( p => new order_product_view_model
      {
        order_id = p.order_id,
        product_id = p.product_id,
        product_quantity = p.product_quantity,
      } ).ToList();
      return orderProductViewModels;
    }

    public async Task<order_product_view_model> GetOrderProductById( int order_id, int product_id )
    {
      var order_product = await _dbContext.order_products.FindAsync( order_id,product_id );
      if ( order_product != null )
      {
        var orderProductViewModel = new order_product_view_model
        {
          order_id = order_product.order_id,
          product_id = order_product.product_id,
          product_quantity=order_product.product_quantity,
        };
        return orderProductViewModel;
      }
      return null;
    }

    public async Task<order_product_view_model> CreateOrderProduct( order_product_view_model orderProductViewModel )
    {

      var ord = _dbContext.orders
                      .Where( b => b.id == orderProductViewModel.order_id )
                      .FirstOrDefault();
      var pro = _dbContext.products
                      .Where( b => b.id == orderProductViewModel.product_id )
                      .FirstOrDefault();
      SqlConnection con = new SqlConnection( _configuration.GetConnectionString( "DbConnection" ).ToString() );
      SqlDataAdapter adapter = new SqlDataAdapter( "select available_quantity from products where products.id=" + orderProductViewModel.product_id, con );
      DataTable dt = new DataTable();
      adapter.Fill( dt );
      Data.responses response = new Data.responses();
      response.status_code = 200;
      
      if (( dt.Rows.Count > 0) && (dt.Rows[ 0 ].Field<int>( "available_quantity" ))> orderProductViewModel.product_quantity )
      {
       

          var order_product = new order_products
          {
            order_id = orderProductViewModel.order_id,
            product_id = orderProductViewModel.product_id,
            product_quantity = orderProductViewModel.product_quantity,
            product = pro,
            order = ord

        };
          _dbContext.order_products.Add( order_product );
          await _dbContext.SaveChangesAsync();
          return orderProductViewModel;
      }



      else { return null; }
        
        
      
    }

    public async Task UpdateOrderProduct( int order_id, int product_id , order_product_view_model orderProductViewModel )
    {
      var orderProduct = await _dbContext.order_products.FindAsync( order_id,product_id );
      if ( orderProduct != null )
      {
        orderProduct.order_id = orderProductViewModel.order_id;
        orderProduct.product_id = orderProductViewModel.product_id;
        orderProduct.product_quantity = orderProductViewModel.product_quantity;
        await _dbContext.SaveChangesAsync();
      }
    }
    public async Task DeleteOrderProduct( int order_id, int product_id )
    {
      var order_product = await _dbContext.products.FindAsync( order_id, product_id );
      if ( order_product != null )
      {
        _dbContext.products.Remove( order_product );
        await _dbContext.SaveChangesAsync();
      }
    }
  }
}



