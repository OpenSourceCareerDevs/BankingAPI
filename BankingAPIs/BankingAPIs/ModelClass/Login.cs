using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.ModelClass
{
    public class Login
    {
        public int Id { get; set; }
        [RegularExpression("[A-Za-z0-9]+@[a-z]+\\.[a-z]{2,3}", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
