using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Repos
{
    public class Admin : IAdminLogin
    {
        private readonly DataBank _dbcontext;


        public Admin(DataBank Bankdata)
        {
            _dbcontext = Bankdata;

        }


        public AdminLogin Login(string Email, string password)
        {
            var user = _dbcontext.AdminLogins.Where(x => x.Email == Email).FirstOrDefault();

            if (user == null)
            {
                throw (new ApplicationException("Unauthorized Login"));
            }

            //bool ValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (user.Password == password)
            {
                return user;
            }
            throw (new ApplicationException("Wrong Email or Password"));
        }


    }
}
