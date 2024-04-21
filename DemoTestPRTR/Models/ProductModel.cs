using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTestPRTR.Models
{
    public class ProductVariantViewModel
    {
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double SalePrice { get; set; }
        public double DiscountPrice { get; set; }
        public string? SKU { get; set; }
        public int Stock { get; set; }
        public string? Location { get; set; }
        public int Rating { get; set; }
    
    }

    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductVariantModel> ProductVariantModel { get; set; }
    }

    public class ProductVariantModel
    {
        [Key]
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double SalePrice { get; set; }
        public double DiscountPrice { get; set; }
        public string? SKU { get; set; }
        public int Stock { get; set; }
        public string? Location { get; set; }
        public int ViewCount { get; set; }
        public ProductModel Product { get; set; }
    }

    


}
