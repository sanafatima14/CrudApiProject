using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudApiProject.Models
{
  public class user_role
  {
    
    public int id { get; set; }
    public int user_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    [ForeignKey( "user_id" )]
    public virtual users? user { get; set; }

    [AllowedValues( "1", "2" )]
    public int role_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    [ForeignKey( "id" )]
    public virtual role? role { get; set; }

  }
}
