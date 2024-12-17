using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Purchase_Details")]
    public class PurchaseDetails
    {
        [Key]
        [Display(Name = "Purchase Details Id")]
        public int Purchase_Details_id { get; set; }

        [Required]
        [Display(Name = "Purchase Id")]
        public int purchase_id { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public int user_id { get; set; }

        [Required]

        [Display(Name ="Product Name")]
        public int product_id { get; set; }

        [Required]
        public int status_id { get; set; }
     

        [Required]
        [Display(Name = "Total Bill")]
        public int TotalAmt { get; set; }

        [Display(Name = "Delivery date")]
        public DateTime ? delivery_date { get; set; }= DateTime.Now.AddDays(10);

        [NotMapped]
        [Display(Name = "Order date")]
        public DateTime? order_Date { get; set; }
  
        [NotMapped]
        [Display(Name = "Status")]
        public string? status_name { get; set; }

        [NotMapped]
        [Display(Name = "Image ")]
        public string? Image_url { get;set; }

        [NotMapped]
        [Display(Name = "Product Name")]
        public string? Product_name { get;set;}

        [NotMapped]
        public int Quantity {  get; set; }  
    }
}
