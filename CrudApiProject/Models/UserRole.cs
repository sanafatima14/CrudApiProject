using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudApiProject.Models
{
  public class UserRole
  {
    
    public int id { get; set; }
    public int user_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    [ForeignKey( "user_id" )]
    public virtual Users? user { get; set; }

    [AllowedValues( "1", "2" )]
    public int role_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    [ForeignKey( "role_id" )]
    public virtual Role? role { get; set; }

  }
}
