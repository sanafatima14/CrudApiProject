using CrudApiProject.Interfaces;
using CrudApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiProject.Controllers
{
  
  [Route( "api/[controller]" )]
  [ApiController]
  public class auth_controller : ControllerBase
  {
    private readonly IAuthService _auth;
    public auth_controller( IAuthService auth )
    {
      _auth = auth;
    }
    [HttpPost( "login" )]
    public string Login( [FromBody] login_request obj )
    {
      var token = _auth.Login( obj );
      return token;
    }

    [HttpPost( "assignRole" )]
    public bool AssignRoleToUser( [FromBody] add_user_role userRole )
    {
      var addedUserRole = _auth.AssignRoleToUser( userRole );
      return addedUserRole;
    }

    [HttpPost( "addUser" )]
    public users AddUser( [FromBody] users user )
    {
      var addeduser = _auth.AddUser( user );
      return addeduser;
    }

    [HttpPost( "addRole" )]
    public role AddRole( [FromBody] role role )
    {
      var addedRole = _auth.AddRole( role );
      return addedRole;
    }

  }
}
