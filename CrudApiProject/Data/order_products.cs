using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudApiProject.Data
{

    public class order_products
    {

        [ForeignKey("orders")]
        public int order_id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual orders? order { get; set; }

        [ForeignKey("products")]
        public int product_id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual products? product { get; set; }
        public int product_quantity { get; set; }
    }
}
