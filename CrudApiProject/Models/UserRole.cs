using System.ComponentModel.DataAnnotations;

namespace CrudApiProject.Models
{
  public class UserRole
  {
    
    public int id { get; set; }
    public int UserId { get; set; }
    [AllowedValues( "1", "2" )]
    public int RoleId { get; set; }
  }
}
