using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }

        [Required]
        public string Role_Name { get; set; }
    }
}
