using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hastane_Randevu.Models
{
    public class User
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Lutfen Emailinz Giriniz ")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lutfen Password Giriniz ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    
    }
}
