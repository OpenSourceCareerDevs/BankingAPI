using BankingAPIs.Controllers;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPIs.Test.ControllerUnitTest
{
    public class AddUser
    {
        private readonly Mock<ISignUp> CreateUserService;

        public AddUser()
        {
            CreateUserService = new Mock<ISignUp>();
        }
        [Fact]
        public void CreateNew_User()
        {
            // Arrange 
            SignUp customer = new SignUp()
            {
                Id = 5,
                FirstName = "Lopez",
                MiddleName = "ziee",
                LastName = "Sammy",
                Email = "Samxza@gmail.com",
                BVN = 23234545678,
                AccountTypes = "savings",
                Password = "Anu",
                ConfirmPassword ="Anu",
                PhoneNumber = "12344",             
                DateOfBirth = DateTime.Now

            };

            CreateUserService.Setup(x => x.Create(customer, customer.Password, customer.ConfirmPassword)).Returns(customer);
            var controller = new SignUpController(CreateUserService.Object);
            // Act 
            var result = controller.CreateNewAccount(customer);
            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));


        }
        
    }
}
