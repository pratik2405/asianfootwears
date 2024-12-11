using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int User_id {  get; set; }

        
        public string ? First_name { get; set; }

        
        public string? Last_name { get; set; }

        
        public string? Address { get; set; }

        
        [Display(Name ="Phone Number")]
        public long PhoneNumber { get; set; }

        [Required]
        public string ?Email { get; set; }

         [Required]
        public string? Password { get; set; }

        public int role_id { get; set; }

        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password can't be match !")]
        public string? ConfirmPassword { get; set; }

        [NotMapped]
        [Display(Name = "Role")]
        public string? Role_Name { get; set; }




    }
}
