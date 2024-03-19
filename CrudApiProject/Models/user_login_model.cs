using System.ComponentModel.DataAnnotations;

namespace CrudApiProject.Models
{
    public class user_login_model
    {

        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

    }
}
