using System.ComponentModel.DataAnnotations;
using static BankingAPIs.ModelClass.CustomerAccount;

namespace BankingAPIs.ModelClass
{
    public class SignUp
    {

        public int Id { get; set; }
        [RegularExpression("^[A-Za-z]*$", ErrorMessage ="Invalid FirstName Type")]
        [StringLength(12, MinimumLength = 3,ErrorMessage ="Name can't be less than 3 characters or More than 12 characters")]
        public string FirstName { get; set; }
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Invalid MiddleName Type")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name can't be less than 3 characters or More than 12 characters")]
        public string MiddleName { get; set; }
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Invalid LastName Type")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name can't be less than 3 or More than 12 characters\"")]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; }
        
        [RegularExpression("[0]([7-9][0]|[8][0-1])[0-9]{8}", ErrorMessage ="Invalid Phone Format")]
        public string PhoneNumber { get; set; }
        //public Gender Genders { get; set; }
        [RegularExpression("[A-Za-z0-9]+@[a-z]+\\.[a-z]{2,3}", ErrorMessage = "Invalid Email Format")]
        [Required]
        public string Email { get; set; }
        //[RegularExpression("[0–9]{10,11}", ErrorMessage = "Invalid BVN Format")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "BVN must be Valid")]
        public long BVN { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(28, MinimumLength = 7, ErrorMessage = "Password can't be less than 7 characters or More than 15 characters")]
        [RegularExpression("^[A-Za-z0-9@#$%]*$", ErrorMessage = "Passwords must be at least 8 characters and contain " +
            "the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. @#$%)")]
        
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Mismatch of password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string AccountTypes { get; set; }
        public string Active { get; } = "True";




    }


}
