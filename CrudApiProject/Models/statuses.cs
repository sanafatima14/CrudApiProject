using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
  public class statuses
  {
    [Key]
    [Column( name: "id" )]
    public  int id { get; set; }

    [StringLength( 12 )]
    public String name { get; set; }

  }
}
