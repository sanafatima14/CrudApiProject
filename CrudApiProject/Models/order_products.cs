using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
 
  public class order_products
  {
    [Key]
    [ForeignKey( "Orders" )]
    public int order_id  { get; set; }
  
    public virtual Orders order { get; set; }
    [ForeignKey( "Products" )]
    [Key]
    public int product_id  { get; set; }
    public virtual Products product { get; set; }
    public int product_quantity { get; set; }
  }
}
