using System.ComponentModel.DataAnnotations;

namespace CrudApiProject.Models
{
   

    public class product_view_model
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(400)]
        public string description { get; set; }

        public float actual_price { get; set; }

        public float selling_price { get; set; }

        [Required(ErrorMessage = "Available quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Available quantity must be greater than 0")]
        public int available_quantity { get; set; }
    }



}
