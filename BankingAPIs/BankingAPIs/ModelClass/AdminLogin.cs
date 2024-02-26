using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.ModelClass
{
    public class AdminLogin
    {

        [Key]
        public int BankId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

    }

}
