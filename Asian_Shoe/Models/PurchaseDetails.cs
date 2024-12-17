using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Purchase_Details")]
    public class PurchaseDetails
    {
        [Key]
        public int Purchase_Details_id { get; set; }

        [Required]
        public int purchase_id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        [Display(Name ="Product id")]
        public int product_id { get; set; }

        [Required]
        public int status_id { get; set; }
     

        [Required]
        [Display(Name = "Total Bill")]
        public int TotalAmt { get; set; }

       
        public DateTime ? delivery_date { get; set; }

        [NotMapped]
        public DateTime? order_Date { get; set; } 

        [NotMapped]
        public string? status_name { get; set; }

        [NotMapped]
        public string? Image_url { get;set; }

        [NotMapped]
        public string? Product_name { get;set;}

        [NotMapped]
        public int Quantity {  get; set; }  
    }
}
