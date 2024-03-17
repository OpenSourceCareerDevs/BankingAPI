using BankingAPIs.ModelClass;

namespace BankingAPIs.Interface
{
    public interface ISignUp
    {
        SignUp Create(SignUp newaccount, string Password, string ConfirmPassword);
    }
}
