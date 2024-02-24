using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApiProject.Models
{
  public class Products
  {
    [Key]
    public int id { get; set; }

    [Required]
    [StringLength( 50 )]
    public string name { get; set; }
    [StringLength( 400 )]
    public string description {  get; set; }
    public int actual_price { get; set; }
    public int selling_price { get; set; }
    [Required]
    [Range( 1, int.MaxValue)]
    public int available_quantity { get; set; }
   
    

  }
}
