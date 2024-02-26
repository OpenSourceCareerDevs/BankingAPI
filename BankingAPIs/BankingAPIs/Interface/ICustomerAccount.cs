using BankingAPIs.DTOs;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Interface
{
    public interface ICustomerAccount
    {
        CustomerAccount Create(CustomerAccount newacc, string Password);
        IEnumerable<CustomerAccount> GetAccounts();

        IEnumerable<CustomerAccount> SearchAccounts(string SearchQuery);
        CustomerAccount UpdateCustomer(string AccountNumber, AccountDto NewUpdate);
        CustomerAccount Login(string Email, string password);
        void DeleteCustomer(int Id);
        CustomerAccount GetAccountById(int Id);
        CustomerAccount GetAccountByName(string Name);
        CustomerAccount GetAccountByAccountNumber(string AccountNumber);
    }
}
