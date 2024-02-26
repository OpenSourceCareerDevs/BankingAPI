using BankingAPIs.DATA;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPIs.Repos
{
    public class AccountRepo : ICustomerAccount
    {
        private readonly DataBank _dbcontext;


        public AccountRepo(DataBank Bankdata)
        {
            _dbcontext = Bankdata;

        }


        public CustomerAccount Create(CustomerAccount newacc, string Password)
        {
            _dbcontext.CustomerAccounts.Add(newacc);


            _dbcontext.SaveChanges();

            return newacc;
        }

        public void DeleteCustomer(int Id)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.Id == Id).FirstOrDefault();

            if (account == null || account.Active != "True")
            {
                throw (new ApplicationException("Account Not Found"));
            }

            account.Active = "false";

            _dbcontext.CustomerAccounts.Update(account);

            _dbcontext.SaveChanges();

           // return true;
        }


        public CustomerAccount GetAccount(string Name)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.LastName == Name).FirstOrDefault();

            if (account != null)
            {
                if (account.Active != "True")
                {
                    throw (new ApplicationException("Account Deleted"));
                }
                return account;
            }
            throw (new ApplicationException("Account Not Found"));
        }

        public CustomerAccount GetAccountByAccountNumber(string AccountNumber)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.AccountGenerated == AccountNumber).FirstOrDefault();

            if (account == null || account.Active != "True")
            {
                throw (new ApplicationException("Account Not Found"));
            }
            return account;
        }



        public CustomerAccount GetAccountById(int Id)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.Id == Id).FirstOrDefault();

            if (account == null || account.Active != "True")
            {
                throw (new ApplicationException("Account Not Found"));
            }
            return account;
        }

        public CustomerAccount GetAccountByName(string Name)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.FirstName == Name).FirstOrDefault();

            if (account == null  || account.Active != "True")
            {
                throw (new ApplicationException("Account Not Found"));
            }
            return account;
        }

        public IEnumerable<CustomerAccount> GetAccounts()
        {
            var accounts = _dbcontext.CustomerAccounts.ToArray().Where(a => a.Active.Equals("True"));

            return accounts;

        }

        public IEnumerable<CustomerAccount> SearchAccounts(string SearchQuery)
        {
            IQueryable<CustomerAccount> customerAccounts1 = _dbcontext.CustomerAccounts;

            if (string.IsNullOrEmpty(SearchQuery))
            {
                return GetAccounts();
            }


            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchQuery = SearchQuery.Trim();
                customerAccounts1 = customerAccounts1.Where(a => a.Email.Contains(SearchQuery) || a.AccountGenerated == SearchQuery);
            }

            return customerAccounts1.ToList().Where(a => a.Active.Equals("True"));
        }

        public CustomerAccount Login(string Email, string password)
        {
            var user = _dbcontext.CustomerAccounts.Where(x => x.Email == Email).FirstOrDefault();

            if (user == null || user.Active !="True")
            {
                throw (new ApplicationException("Invalid Email or Password"));
            }

            bool ValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!ValidPassword)
            {
                throw (new ApplicationException("Invalid Email or Password"));
            }


            return user;
        }

        public CustomerAccount UpdateCustomer(string AccountNumber, AccountDto NewUpdate)
        {
            var accountToBeUpdated = _dbcontext.CustomerAccounts.Where(x => x.AccountGenerated == AccountNumber).FirstOrDefault();

            if (accountToBeUpdated == null || accountToBeUpdated.Active != "True") throw (new ApplicationException("Account not found"));

            bool ValidPassword = BCrypt.Net.BCrypt.Verify(NewUpdate.Oldpassword, accountToBeUpdated.Password);

            //throw error because email passeed doesn't matc wiith

            if (!ValidPassword) throw (new ApplicationException("Wrong Old password"));
            //so we have a match

            if (!string.IsNullOrWhiteSpace(NewUpdate.Email) && NewUpdate.Email != accountToBeUpdated.Email)
            {
                //throw error because email exist in db
                if (_dbcontext.CustomerAccounts.Any(x => x.Email == NewUpdate.Email))
                    throw (new ApplicationException("Email " + NewUpdate.Email + " has been taken"));


                accountToBeUpdated.Email = NewUpdate.Email;
            }
            else
            {
                accountToBeUpdated.Email = accountToBeUpdated.Email;
            }

            if (!string.IsNullOrWhiteSpace(NewUpdate.PhoneNumber) && NewUpdate.PhoneNumber != accountToBeUpdated.PhoneNumber)
            {
                //throw error because Number exist in db
                if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == NewUpdate.PhoneNumber))
                    throw (new ApplicationException("PhoneNumber " + NewUpdate.PhoneNumber + " has been taken"));

                accountToBeUpdated.PhoneNumber = NewUpdate.PhoneNumber;

            }
            else
            {
                accountToBeUpdated.PhoneNumber= accountToBeUpdated.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(NewUpdate.Password))
            {
                accountToBeUpdated.Password = BCrypt.Net.BCrypt.HashPassword(NewUpdate.Password);

            }


            accountToBeUpdated.DateUpdated = DateTime.Now;
            _dbcontext.CustomerAccounts.Update(accountToBeUpdated);
            _dbcontext.SaveChanges();

            return accountToBeUpdated;


        }


    }
}
