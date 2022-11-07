using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HardwareStore.Models;

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }

