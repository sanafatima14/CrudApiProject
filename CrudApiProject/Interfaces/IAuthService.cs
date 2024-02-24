using CrudApiProject.Models;


namespace CrudApiProject.Interfaces
{
  public interface IAuthService
  {
    Users AddUser( Users user );
    string Login( Models.LoginRequest loginRequest );
    Role AddRole( Role role );
    bool AssignRoleToUser( AddUserRole obj );

  }
}
