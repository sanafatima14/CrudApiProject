using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
  public class role
  {
    [Key]
    [Column( name: "id" )]
    public int id { get; set; }
    [StringLength( 10)]
    public String name { get; set; }

    [StringLength( 300)]
    public string description { get; set; }
  }
}
