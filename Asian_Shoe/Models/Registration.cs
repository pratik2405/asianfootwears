using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asian_Shoe.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int User_id {  get; set; }

        [MinLength(2)]
        public string ? First_name { get; set; }

        [MinLength(2)]
        public string? Last_name { get; set; }

        
        public string? Address { get; set; }

        
        [Display(Name ="Phone Number")]
        //[Phone]
        //[MinLength(10)]
        //[MaxLength(10)]
        public long PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string ?Email { get; set; }

         [Required]        
        public string? Password { get; set; }

        public int role_id { get; set; } = 2;
       
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password can't be match !")]
        public string? ConfirmPassword { get; set; }

        [NotMapped]
        [Display(Name = "Role")]
        public string? Role_Name { get; set; }




    }
}
