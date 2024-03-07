using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudApiProject.Models
{
  public class Report
  {
    
    public int order_id { get; set; } 
    public String name { get; set; }
    public int product_quantity{ get; set; }
    public string first_name { get; set; }
    public string last_name { get; set;}

  }
}
