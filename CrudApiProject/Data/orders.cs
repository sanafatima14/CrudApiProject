using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CrudApiProject.Data
{
    public class orders
    {

        
        public int id { get; set; }

        public int user_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("id")]
        public virtual users? user { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime order_date { get; set; }

        public float total_cost { get; set; }


        [RegularExpression( "Pending|Done|InProgress", ErrorMessage = "Role must be either 'Admin' or 'user'." )]  
        public String status { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        //[ForeignKey("id")]
        //public virtual statuses? status { get; set; }

    }
}
