using CodeChallenge1.Models;
using Microsoft.AspNetCore.Mvc;
using UserInfo.API.Controllers;
using Xunit;
using FluentAssertions;
using Microsoft.OpenApi.Writers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace CodeChallenge1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        [Fact]
        public void Test_GetAll_Users_ShouldReturn200Status()
        {
            //Arrange
            var controller = new UserController();
            var actionResult = controller.GetUsers();

            //Act
            var result = actionResult.Result as  OkObjectResult;


            //Assert
           result.StatusCode.Should().Be(200);
            
        }

        [Fact]       
        public void Test_GetAll_Users_Count()

        {
            //Arrange
            
            var controller = new UserController();
            var actionResult = controller.GetUsers();

            //Act
            var result = actionResult.Result as OkObjectResult;
            var userCount = ((IEnumerable<UserDto>)result.Value).Count();
            //Assert
            userCount.Should().Be(2);
          

        }

        [Fact]
        public void Test_AddNewUser()

        {
            //Arrange

            var controller = new UserController();
            var actionResult = controller.GetUsers();

            //Act
            var result = actionResult.Result as OkObjectResult;
            var userCount = ((IEnumerable<UserDto>)result.Value).Count();
            //Assert
            userCount.Should().Be(2);


        }
    }
}