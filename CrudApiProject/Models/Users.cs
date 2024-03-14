using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudApiProject.Models
{
  public class users
  {

    [Key]
    [Column( name: "id" )]
    public int id { get; set; }
    [StringLength(50)]
    public string username { get; set; }
    [StringLength( 30, ErrorMessage = "First name cannot be longer than 30 characters." )]
    public string first_name { get; set; }
    [StringLength( 30, ErrorMessage = "First name cannot be longer than 30 characters." )]
    public string? last_name { get; set; }

    [Required( ErrorMessage = "email is required" )]
    [StringLength( 100 )]
    [RegularExpression( @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid." )]
    public string email { get; set; }

    [Required( ErrorMessage = "Password is required" )]
    [RegularExpression( "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Password must meet requirements" )]
    [StringLength( 50 )]
    public string password { get; set; }

    //[Required]
    
    //[AllowedValues( "User", "Admin","user","admin" )]
    //public string role { get; set; }
    
  }
}
