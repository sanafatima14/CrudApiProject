using CrudApiProject.Data;
using CrudApiProject.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudApiProject.Services
{
  public class order_service
  {
    private readonly api_demo_db_class _dbContext;

    public order_service( api_demo_db_class dbContext )
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<order_view_model>> GetAllOrders()
    {
      var orders = await _dbContext.orders.ToListAsync();
      var orderViewModels = orders.Select( b => new order_view_model
      {
        id = b.id,
        user_id = b.user_id,
        order_date = b.order_date,
        total_cost = b.total_cost,
        status = b.status
      } ).ToList();
      return orderViewModels;
    }

    public async Task<order_view_model> GetOrderById( int id )
    {
      var order = await _dbContext.orders.FindAsync( id );
      if ( order != null )
      {
        var orderViewModel = new order_view_model
        {
          id = order.id,
          user_id = order.user_id,
          order_date = order.order_date,
          total_cost = order.total_cost,
          status = order.status
        };
        return orderViewModel;
      }
      return null;
    }

    public async Task<order_view_model> CreateOrder( order_view_model orderViewModel )
    {
      var u = _dbContext.users
                      .Where( b => b.id == orderViewModel.user_id )

                      .FirstOrDefault();
      var order = new orders
      {
        id = orderViewModel.id,
        user_id = orderViewModel.user_id,
        order_date = orderViewModel.order_date,
        total_cost = orderViewModel.total_cost,
        status = orderViewModel.status
      };
      order.user = u;
      _dbContext.orders.Add( order );
      await _dbContext.SaveChangesAsync();
      orderViewModel.id = order.id;
      return orderViewModel;
    }

    public async Task UpdateOrder( int id, order_view_model orderViewModel )
    {
      var order = await _dbContext.orders.FindAsync( id );
      if ( order != null )
      {
        
        order.user_id = orderViewModel.user_id;
        order.order_date = orderViewModel.order_date;
        order.total_cost = orderViewModel.total_cost;
        order.status = orderViewModel.status;
        await _dbContext.SaveChangesAsync();
      }
    }

    public async Task DeleteOrder( int id )
    {
      var order = await _dbContext.orders.FindAsync( id );
      if ( order != null )
      {
        _dbContext.orders.Remove( order );
        await _dbContext.SaveChangesAsync();
      }
    }


    public async Task UpdateOrderStatus( int id, String status )
    {
      var order = await _dbContext.orders.FindAsync( id );
      if ( order != null )
        order.status = status;
      await _dbContext.SaveChangesAsync();

    }
  }
}
