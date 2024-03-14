using CrudApiProject.Interfaces;
using CrudApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudApiProject.Services
{
  public class AuthService : IAuthService
  {
    private readonly api_demo_db_class _context;
    private readonly IConfiguration _configuration;
    public AuthService( api_demo_db_class context, IConfiguration configuration )
    {
      _context = context;
      _configuration = configuration;
    }

    public role AddRole( role role )
    {
      var addedRole = _context.roles.Add( role );
      _context.SaveChanges();
      return addedRole.Entity;
    }

    public users AddUser( users user )
    {
      var addedUser = _context.users.Add( user );
       _context.SaveChanges();
      return addedUser.Entity;
    }

    public bool AssignRoleToUser( add_user_role obj )
    {
      try
      {
        var addRoles = new List<user_role>();
        var user = _context.users.SingleOrDefault( s => s.id == obj.UserId );
        if ( user == null )
          throw new Exception( "user is not valid" );

        foreach ( int role in obj.RoleIds )
        {
          var userRole = new user_role();
          userRole.role_id = role;
          userRole.user_id = user.id; 
          addRoles.Add( userRole );
        }
        _context.user_roles.AddRange( addRoles );
        _context.SaveChanges();
        return true;
      }
      catch ( Exception ex )
      {
        return false;
      }

    }

    public string Login( login_request loginRequest )
    {
      
      if ( loginRequest.username != null && loginRequest.password != null )
      {
        var user = _context.users.SingleOrDefault( s => s.username == loginRequest.username && s.password == loginRequest.password );
        if ( user != null )
        {
          var claims = new List<Claim> {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.id.ToString()),
                        new Claim("UserName", user.first_name)
          };


          var userRoles = _context.user_roles.Where( u => u.user_id == user.id );
          var roleIds = userRoles.Select( s => s.role_id ).ToList();
          var roles = _context.roles.Where( r => roleIds.Contains( r.id ) ).ToList();
          foreach ( var role in roles )
          {
            claims.Add( new Claim( ClaimTypes.Role, role.name ) );
          }
          var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration[ "Jwt:Key" ] ) );
          var signIn = new SigningCredentials( key, SecurityAlgorithms.HmacSha256 );
          var token = new JwtSecurityToken(
              _configuration[ "Jwt:Issuer" ],
              _configuration[ "Jwt:Audience" ],
              claims,
              expires: DateTime.UtcNow.AddMinutes( 10 ),
              signingCredentials: signIn );

          var jwtToken = new JwtSecurityTokenHandler().WriteToken( token );
          return jwtToken;
        }
        else
        {
          throw new Exception( "user is not valid" );
        }
      }
      else
      {
        throw new Exception( "credentials are not valid" );
      }
    }
  }
}
