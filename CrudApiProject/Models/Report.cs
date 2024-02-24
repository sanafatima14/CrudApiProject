using System.ComponentModel.DataAnnotations;

namespace CrudApiProject.Models
{
  public class Report
  {
    [Key]
    public int OrderId { get; set; } 
    public String name { get; set; }
    public string product_quantity{ get; set; }
    public string first_name { get; set; }
    public string last_name { get; set;}

  }
}
