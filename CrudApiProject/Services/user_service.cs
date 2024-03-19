using CrudApiProject.Data;
using CrudApiProject.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CrudApiProject.Services
{
  public class user_service
  {
    private readonly api_demo_db_class _dbContext;
    public user_service( api_demo_db_class dbContext )
    {
      _dbContext = dbContext;
    }
    public async Task<IEnumerable<user_view_model>> GetAllUsers()
    {
      var users = await _dbContext.users.ToListAsync();
      var userViewModels = users.Select( p => new user_view_model
      {
        id = p.id,
        first_name = p.first_name,
        last_name = p.last_name,
        email = p.email,
        password = p.password,
        role = p.role
      } ).ToList();
      return userViewModels;
    }
    public async Task<user_view_model> GetUserById( int id )
    {
      var user = await _dbContext.users.FindAsync( id );
      if ( user != null )
      {
        var userViewModel = new user_view_model
        {
          id = user.id,
          first_name = user.first_name,
          last_name = user.last_name,
          email = user.email,
          password = user.password,
          role = user.role
        };
        return userViewModel;
      }
      return null;
    }
    public async Task<user_view_model> CreateUser( user_view_model userViewModel )
    {
      var user = new users
      {
        username = userViewModel.username,
        first_name = userViewModel.first_name,
        last_name = userViewModel.last_name,
        email = userViewModel.email,
        password =  HashPassword( userViewModel.password ),
        role = userViewModel.role
      };
      _dbContext.users.Add( user );
      await _dbContext.SaveChangesAsync();
      userViewModel.id = user.id;
      return userViewModel;
    }
    public async Task UpdateUser( int id, user_view_model userViewModel )
    {
      var user = await _dbContext.users.FindAsync( id );
      if ( user != null )
      {
        user.first_name = userViewModel.first_name;
        user.last_name = userViewModel.last_name;
        user.username = userViewModel.username;
        user.email = userViewModel.email;
        user.password = HashPassword( userViewModel.password );
        user.role = userViewModel.role;
        await _dbContext.SaveChangesAsync();
      }
    }
    public async Task DeleteUser( int id )
    {
      var user = await _dbContext.users.FindAsync( id );
      if ( user != null )
      {
        _dbContext.users.Remove( user );
        await _dbContext.SaveChangesAsync();
      }
    }
    private string HashPassword( string password )
    {
      return BCrypt.Net.BCrypt.HashPassword( password );
    }
  }
}
