using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudApiProject.Models
{
 
  public class order_products
  {
   
    [ForeignKey( "Orders" )]
    public int order_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    public virtual Orders? order { get; set; }
    [ForeignKey( "Products" )]
  
    public int product_id  { get; set; }
    [System.Text.Json.Serialization.JsonIgnore( Condition = JsonIgnoreCondition.Always )]
    public virtual Products? product { get; set; }
    public int product_quantity { get; set; }
  }
}
