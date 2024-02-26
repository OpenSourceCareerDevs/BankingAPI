using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.DTOs
{
    public class AccountDto
    {

        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Oldpassword { get; set; }
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Mismatch of password")]
        public string? ConfirmPassword { get; set; }
        public DateTime DateUpdated { get; }
    }
}
