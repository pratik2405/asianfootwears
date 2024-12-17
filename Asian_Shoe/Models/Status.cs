using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int status_id { get; set; }

        [Required]
        public string ?status_name { get; set; }
    }
}
