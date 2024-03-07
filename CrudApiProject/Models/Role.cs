using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
  public class Role
  {
    [Key]
    [Column( name: "role_id" )]
    public int id { get; set; }
    public String name { get; set; }
    public string description { get; set; }
  }
}
