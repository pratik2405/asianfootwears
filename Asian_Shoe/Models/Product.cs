using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Product_id { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string? Product_name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int Category_id { get; set;}

        [Required]
        public string? Image_Url { get; set; }

        [NotMapped]
        [Required]
        [Display(Name ="Category")]
        public string? Category_name { get;set; }

        

    }
}
