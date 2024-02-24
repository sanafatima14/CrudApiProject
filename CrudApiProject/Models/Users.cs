using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CrudApiProject.Models
{
  public class Users
  {

    [Key]
    public int Id { get; set; }

    public string username { get; set; }
    [StringLength( 30, ErrorMessage = "First name cannot be longer than 30 characters." )]
    public string? first_name { get; set; }
    [StringLength( 30, ErrorMessage = "First name cannot be longer than 30 characters." )]
    public string? last_name { get; set; }

    [Required( ErrorMessage = "email is required" )]
    [RegularExpression( @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid." )]
    public string? email { get; set; }

    [Required( ErrorMessage = "Password is required" )]
    [RegularExpression( "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Password must meet requirements" )]
    public string? password { get; set; }

    [Required]
    
    [AllowedValues( "User", "Admin" )]
    public string role { get; set; }
    
  }
}
