using CrudApiProject.Models;
using CrudApiProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiProject.Controllers
{
  [Authorize]
  [ApiController]
  [Route( "api/users" )]
  public class user_controller : ControllerBase
  {
    private readonly user_service _userService;

    public user_controller( user_service userService )
    {
      _userService = userService;
    }
    [HttpGet]
    [Route( "get-users" )]
    public async Task<ActionResult<IEnumerable<user_view_model>>> GetAllUsers()
    {
      var users = await _userService.GetAllUsers();
      return Ok( users );
    }

    [HttpGet]
    [Route( "get-user/{id}" )]
    public async Task<ActionResult<user_view_model>> GetUserById( int id )
    {
      var user = await _userService.GetUserById( id );

      if ( user == null )
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    [Route( "create-user" )]
    [Authorize( Roles = "Admin" )]
    public async Task<ActionResult<user_view_model>> CreateUser( [FromBody] user_view_model userViewModel )
    {
      var createdUser = await _userService.CreateUser( userViewModel );
      return CreatedAtAction( nameof( GetUserById ), new { id = createdUser.id }, createdUser );
    }

    [HttpPut]
    [Route( "update-user/{id}" )]
    [Authorize( Roles = "Admin" )]
    public async Task<IActionResult> UpdateUser( int id, [FromBody] user_view_model userViewModel )
    {
      await _userService.UpdateUser( id, userViewModel );
      return NoContent();
    }

    [HttpDelete]
    [Route( "delete-user/{id}" )]
    public async Task<IActionResult> DeleteUser( int id )
    {
      await _userService.DeleteUser( id );
      return NoContent();
    }

  }
}
