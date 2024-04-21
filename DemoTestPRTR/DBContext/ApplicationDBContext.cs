using DemoTestPRTR.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTestPRTR.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ProductVariantModel> ProductVariant { get; set; }
    }

}
