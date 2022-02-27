using APIWeb.Controllers;
using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Contracts;
using Xunit;

namespace web_api_tests
{
    public class UserTest
    {
        private readonly UserController _controller;
        private readonly IUserService _service;

        public UserTest()
        {
            _service = new UserServiceFake();
            _controller = new UserController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            UserModel testItem = new UserModel(1, "deep","lohra","deep@gmail.com","123");
         
            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int notExistingGuid = 5;

            // Act
            var badResponse = _controller.Delete(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}
