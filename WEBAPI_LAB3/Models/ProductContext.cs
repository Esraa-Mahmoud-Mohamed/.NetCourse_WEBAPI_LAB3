using Microsoft.EntityFrameworkCore;

namespace WEBAPI_LAB3.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {

        }
        public ProductContext(DbContextOptions<ProductContext> option) : base(option)
        {

        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Catalog> Catalog { get; set; }
    }
}
