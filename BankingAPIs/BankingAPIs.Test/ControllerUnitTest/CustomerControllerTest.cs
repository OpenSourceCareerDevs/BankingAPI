using BankingAPIs.Controllers;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BankingAPIs.Test.ControllerUnitTest
{
    public class CustomerControllerTest
    {



        private readonly ICustomerAccount _CustomerAccount;
        private readonly IList<CustomerAccount> _accRepo;

        public CustomerControllerTest()
        {

            _CustomerAccount = A.Fake<ICustomerAccount>();
            _accRepo = A.CollectionOfFake<CustomerAccount>(9);

        }

        [Fact]
        public void CustomerController_GetUsersList_ReturnUsers()
        {
            // Arrange 
            var User = A.Fake<ICollection<CustomerAccount>>().ToList();

            var Controller = new AccountController(_CustomerAccount);
            // Act 
            var result = Controller.GetDetails() as OkObjectResult;
            // Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            Assert.IsType<OkObjectResult>(result as OkObjectResult);

            result.Should().NotBeNull();


        }
        [Fact]
        public void CustomerController_GetUserByAccNum_ReturnUser()
        {
            // Arrange 
            var CustomerAccount = A.Fake<CustomerAccount>();

            string accnum = CustomerAccount.AccountGenerated;

            var Controller = new AccountController(_CustomerAccount);
            // Act 
            var result = Controller.GetAccountByAccountNumber(accnum) as OkObjectResult;
            // Assert
            result.Should().NotBeNull();
            Assert.IsType<OkObjectResult>(result);


        }
       

        [Fact]
        public void CustomerController_DeleteUserBy_Acc_ReturnNOContent()
        {
            // Arrange  
            var CustomerAccount = A.Fake<CustomerAccount>();
            string accnum = CustomerAccount.AccountGenerated;

            var Controller = new AccountController(_CustomerAccount);
            // Act 
            var result = Controller.DeleteCustomer(accnum);
            // Assert
            Assert.IsType<NoContentResult>(result);
            result.Should().NotBeNull();

        }
        [Fact]
        public void CustomerController_Delete_NotExisitinAcc_ReturnsNotFoundResponse()
        {
            // Arrange 
            var CustomerAccount = A.Fake<CustomerAccount>();

            string acc = CustomerAccount.AccountGenerated;

            // Act
            var Controller = new AccountController(_CustomerAccount);
            A.CallTo(() => _CustomerAccount.GetAccountByAccountNumber("")).Returns(null);
            //A.CallTo(() => _CustomerAccount.DeleteCustomer(CustomerAccount.Id)).Returns(false);

            var result = Controller.DeleteCustomer("");
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            //Assert.True(true);
        }
        [Fact]
        public void CustomerController_updateUser_ReturnUser()
        {
            // Arrange 
            var CustomerAccount = A.Fake<CustomerAccount>();
            var CustomerDto = A.Fake<AccountDto>();
            string accnum = CustomerAccount.AccountGenerated;
             
            var Controller = new AccountController(_CustomerAccount);
            // Act
            var result = Controller.UpdateCustomer(CustomerDto, accnum);
            // Assert
            Assert.IsType<OkObjectResult>(result);
            result.Should().NotBeNull();

        }

        [Fact]
        public void CustomerController_Login_ReturnUser()
        {
            // Arrange 
            var CustomerAccount = A.Fake<CustomerAccount>();
            var Login = A.Fake<LoginDTO>();
            string email = CustomerAccount.Email;
            string pass = CustomerAccount.Password;

            var Controller = new AccountController(_CustomerAccount);
            // Act 
            var result = Controller.Login(Login) as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(result);


            result.Should().NotBeNull();

        }

    }
}

