using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Models
{
    public class Finish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Finish")]
        public string Name { get; set; }
    }
}
