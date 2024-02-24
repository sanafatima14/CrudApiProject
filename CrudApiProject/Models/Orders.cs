using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
  public class Orders
  {
    [Key]
    public int id { get; set; }
    [ForeignKey( "Users" )]
    public int user_id  { get; set; }
    public virtual Users user { get; set; }

    [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime order_date { get; set; }
    public int total_cost { get; set; }
    [AllowedValues( "Pending", "InProgress","Done" )]
    public String status { get; set; }
  }
}
