using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI_LAB3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        [ForeignKey("Catalog")]
        public int catid { get; set; }
        public virtual Catalog Catalog { get; set; }
    }
}
