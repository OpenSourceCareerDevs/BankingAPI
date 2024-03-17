using BankingAPIs.ModelClass;

namespace BankingAPIs.Interface
{
    public interface ILogin
    {
        Login Authenticate(string Email, string password);
    }
}
