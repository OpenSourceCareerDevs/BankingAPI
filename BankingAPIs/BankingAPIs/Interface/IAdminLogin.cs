using BankingAPIs.ModelClass;

namespace BankingAPIs.Interface
{
    public interface IAdminLogin
    {
        AdminLogin Login(string Email, string password);
        // Method that the repo will create

    }
}
