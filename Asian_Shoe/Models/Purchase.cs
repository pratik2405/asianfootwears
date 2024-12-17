using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Asian_Shoe.Models
{
    [Table("Purchase")]
    public class Purchase
    {
        [Key]
        public int Purchase_id { get; set; }

        [Required]
        public int User_id { get; set; }

        [Required]
        public int product_id { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        //[DisplayFormat(date = "{yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime ? Date_of_order { get; set; }=DateTime.Now;

      
    }
}
