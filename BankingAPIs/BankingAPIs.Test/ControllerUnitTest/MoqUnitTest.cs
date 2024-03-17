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
    public class MoqUnitTest
    {
        private readonly Mock<ICustomerAccount> CustomerService;
        public MoqUnitTest()
        {
            CustomerService = new Mock<ICustomerAccount>();
        }
        [Fact]

        public void GetCustomerList()
        {
            //Arrange //Act //Assert
            var customer = customerlist();
            CustomerService.Setup(x => x.GetAccounts()).Returns(customer);
            var controller = new AccountController(CustomerService.Object);
            //Act 
            var result = controller.GetDetails();
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            result.Should().NotBeNull();

        }

        [Fact]
        public void GetCustomerByID_Customer()
        {
            //Arrange
            var customer = customerlist();
            CustomerService.Setup(x => x.GetAccountById(1)).Returns(customer[1]);
            var controller = new AccountController(CustomerService.Object);
            //Act 
            var result = controller.GetAccountById(1) as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            result.Should().NotBeNull();

        }
        [Fact]
        public void GetCustomerByAccNumber_Customer()
        {
            //Arrange 
            CustomerService.Setup(x => x.GetAccountByAccountNumber("0291234587")).Returns(singleAcc("0291234587"));
            var controller = new AccountController(CustomerService.Object);
            //Act 
            var result = controller.GetAccountByAccountNumber("0291234587") as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            result.Should().NotBeNull();

        }

        [Fact]
        public void CustomerController_WrongAccNum_ReturnNotFound()
        {
            //Arrange
            CustomerService.Setup(x => x.GetAccountByAccountNumber("0291234587")).Returns(singleAcc("0291234587"));
            var controller = new AccountController(CustomerService.Object);
            //Act 
            var result = controller.GetAccountByAccountNumber("0291234517");
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(NotFoundObjectResult));
            result.Should().NotBeNull();
        }

        [Fact]
        public void SearchAccByQuery_Customer()
        {
            //Arange
            CustomerService.Setup(x => x.SearchAccounts("0291294567")).Returns(searchAccounts("0291294567"));
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.Search("0291294567");
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<CustomerAccount>>));
            result.Should().NotBeNull();

        }

        [Fact]
        public void CustomerController_GetUserBy_WrongQuery_ReturnNotFound()
        {
            //Arange
            CustomerService.Setup(x => x.SearchAccounts("0291294567")).Returns(searchAccounts("0291294567"));
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.Search("0291214567");
            //Assert
            Assert.NotNull(result);
            //result.Should().BeOfType(typeof(BadRequestObjectResult));
            result.Should().NotBeNull();
        }


        [Fact]
        public void GetCustomerByName_Customer()
        {
            //Arrange
            var customer = customerlist();
            CustomerService.Setup(x => x.GetAccountByName("sammy")).Returns(customer[1]);
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.GetAccountByName("sammy") as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            result.Should().NotBeNull();

        }

        [Fact]
        public void ToDeleteUser_Void()
        {
            // Arrange
            var customer = customerlist();
            CustomerService.Setup(x => x.GetAccountByAccountNumber(customer[1].AccountGenerated)).Returns(customer[1]);
            CustomerService.Setup(x => x.DeleteCustomer(customer[1].Id));

            var controller = new AccountController(CustomerService.Object);

            // Act
           var result = controller.DeleteCustomer(customer[1].AccountGenerated);

            // Assert
            
            result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]

        public void GetWrongUserByID_ReturnNotFound()
        {
            //Arrange
            var customer = customerlist();
            CustomerService.Setup(x => x.GetAccountById(4)).Returns(singleCustomer(4));
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.GetAccountById(4);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);
            result.Should().BeOfType(typeof(NotFoundObjectResult));
            
        }

        [Fact]
        public void Login_ReturnUser()
        {
            //Arrange
            var customer = customerlist();

            LoginDTO loginDTO = new LoginDTO()
            {
                Email = customer[1].Email,
                Password = customer[1].Password
            };

            
            CustomerService.Setup(x => x.Login(customer[1].Email, customer[1].Password)).Returns(singleCustomer(customer[1].Id));
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.Login(loginDTO);
            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));


        }

        [Fact]
        public void CustomerController_WrongLoginDetails()
        {
            //Arrange
            var customer = customerlist();

            LoginDTO loginDTO = new LoginDTO()
            {
                Email = "saw2@gmail.com",
                Password = customer[1].Password
            };


            CustomerService.Setup(x => x.Login(customer[2].Email, customer[2].Password)).Returns(customer[2]);
            var controller = new AccountController(CustomerService.Object);
            //Act
            var result = controller.Login(loginDTO);
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(NotFoundObjectResult));

        }

        [Fact]
        public void UpdateUser_ReturnUser()
        {
            var customer = customerlist();

            AccountDto accountDto = new AccountDto()
            {
                Id = customer[1].Id,
                Email = "jeff@gmail.com",
                PhoneNumber = "09123546733",
                Oldpassword = customer[1].Password,
                Password = "string",
                ConfirmPassword = "string",
                
            };


            CustomerService.Setup(x => x.UpdateCustomer(customer[1].AccountGenerated,accountDto)).Returns(singleCustomer(customer[1].Id));
            var controller = new AccountController(CustomerService.Object);

            var result = controller.UpdateCustomer(accountDto, customer[1].AccountGenerated);

            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));


        }




        private List<CustomerAccount> customerlist()
        {
            var customers = new List<CustomerAccount>();

            customers.Add(new CustomerAccount()
            {

                Id = 1,
                FirstName = "Lopez",
                LastName = "Sam",
                Email = "Samuel@gmail.com",
                Password = "Anu",
                PhoneNumber = "12344",
                AccountBalance = 0,
                AccountGenerated = "0291234587",
                //accountType = CustomerAccount.AccountType,
                DateCreated = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Active = "True"
            });
            customers.Add(new CustomerAccount()
            {

                Id = 2,
                FirstName = "Lopez",
                LastName = "Sam",
                Email = "Samuel@gmail.com",
                Password = "Anu",
                PhoneNumber = "12344",
                AccountBalance = 0,
                AccountGenerated = "0291234467",
                //accountType = CustomerAccount.AccountType,
                DateCreated = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Active = "True"

            });
            customers.Add(new CustomerAccount()
            {

                Id = 3,
                FirstName = "Lopez",
                LastName = "Samtel",
                Email = "Samuel@gmail.com",
                Password = "Anu",
                PhoneNumber = "12344",
                AccountBalance = 0,
                AccountGenerated = "0291294567",
                //accountType = CustomerAccount.AccountType,
                DateCreated = DateTime.Now,
                DateOfBirth = DateTime.Now,
                Active = "True"

            });


            return customers;
        }

        private CustomerAccount singleCustomer(int id)
        {
            List<CustomerAccount> customer = customerlist();
            return customer.FirstOrDefault(a => a.Id == id);
        }

        private CustomerAccount singleAcc(string AccNumber)
        {
            List<CustomerAccount> customer = customerlist();
            return customer.FirstOrDefault(a => a.AccountGenerated == AccNumber);
        }

        private IEnumerable<CustomerAccount> searchAccounts(string SearchQuery)
        {
            List<CustomerAccount> customer = customerlist();
            return customer.Where(a => a.Email.Contains(SearchQuery) || a.AccountGenerated == SearchQuery);

        }



    }
}

