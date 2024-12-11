using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Category")]
    public class Category
    {
        [Key] 
        public int Category_id { get; set; }

        [Required]
        public string? Category_name { get; set; }
    }
}
