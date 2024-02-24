using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
 
  public class orderProducts
  {
    
    [ForeignKey( "Orders" )]
    public int Order_id  { get; set; }
    public virtual Orders order { get; set; }
    [ForeignKey( "Products" )]
    public int Product_id  { get; set; }
    public virtual Products product { get; set; }
    public int Product_quantity { get; set; }
  }
}
