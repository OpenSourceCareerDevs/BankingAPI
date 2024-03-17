using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Repos
{
    public class Signup : ISignUp
    {
        private readonly DataBank _dbcontext;
        private readonly IMapper _mapper;


        public Signup(DataBank dataBank, IMapper mapper)
        {
            _dbcontext = dataBank;
            _mapper = mapper;
        }



        public SignUp Create(SignUp newaccount, string Password, string ConfirmPassword)
        {
            if (string.IsNullOrWhiteSpace(Password) && string.IsNullOrWhiteSpace(ConfirmPassword))
                throw (new ApplicationException("Password cannot be empty"));

            if (_dbcontext.CustomerAccounts.Any(x => x.Email == newaccount.Email))
                throw (new ApplicationException("A user with this email exists"));

            if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == newaccount.PhoneNumber))
                throw (new ApplicationException("A user with this phoneNumber exists"));

            if (_dbcontext.CustomerAccounts.Any(x => x.BVN == newaccount.BVN))
                throw (new ApplicationException("A user with this BVN exists"));

            newaccount.Password = BCrypt.Net.BCrypt.HashPassword(newaccount.Password);

            newaccount.ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(newaccount.ConfirmPassword);

            _dbcontext.SignUps.Add(newaccount);

            _dbcontext.SaveChanges();

            var d = _mapper.Map<CustomerAccount>(newaccount);

            var accountNumber = new AccountNumber();

            d.AccountGenerated = accountNumber.AccountGenerated;

            d.DateCreated = DateTime.Now;
            d.DateUpdated = DateTime.Now;
            //d.Active = "True";

            _dbcontext.CustomerAccounts.Add(d);

            _dbcontext.SaveChanges();
             

            return newaccount;
        }
    }
}
