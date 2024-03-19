using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudApiProject.Data
{
    public class users

    {

        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [MaxLength(30)]
        public string first_name { get; set; }

        [MaxLength(30)]
        public string last_name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength( 100 )]
        [RegularExpression( "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Password must meet requirements" )]
        public string password { get; set; }

        [Required]
        [RegularExpression("Admin|user", ErrorMessage = "Role must be either 'Admin' or 'user'.")]
        public string role { get; set; }

    }
}
