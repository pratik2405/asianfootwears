using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }

        public int User_id { get; set; }

        public int Product_id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public int Price { get; set; }

        [NotMapped]
        [Display(Name = "Product Name")]
        public string? Product_Name { get; set; }
        [NotMapped]
        [Display(Name = "Product")]
        public string? Image_url { get; set; }

        [NotMapped]
        public int Total { get; set; }
    }
}
