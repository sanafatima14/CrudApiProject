using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CrudApiProject.Models
{
  public class Orders
  {
    
    [Key]
    public int id { get; set; }
 
    public int user_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    [ForeignKey( "user_id" )]
    public virtual Users? user { get; set; } 
    
    [DisplayFormat( DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime order_date { get; set; }
    public float total_cost { get; set; }
    [AllowedValues( "Pending", "InProgress","Done" )]
    public String status { get; set; }
  }
}
