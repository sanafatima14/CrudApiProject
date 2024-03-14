using CrudApiProject.Models;


namespace CrudApiProject.Interfaces
{
  public interface IAuthService
  {
    users AddUser( users user );
    string Login( Models.login_request loginRequest );
    role AddRole( role role );
    bool AssignRoleToUser( add_user_role obj );

  }
}
