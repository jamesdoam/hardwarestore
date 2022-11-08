using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardwareStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Product Price")]
        public double Price { get; set; }
        
        [DisplayName("Sale Price")]
        public double SalePrice {get; set; }

        public string Description { get; set; }

        public string Sku { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public int FinishId { get; set; }
        public Finish Finish { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}


