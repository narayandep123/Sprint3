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
    public  class TaskTest
    {
        private readonly TaskController _controller;
        private readonly ITaskService _service;

        public TaskTest()
        {
            _service = new TaskServiceFake();
            _controller = new TaskController(_service);
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
           TaskModel testItem = new TaskModel(6, 1, 2, 1, "This ia test Task", DateTime.Parse("2022-01-13"));

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int notExistingGuid = 7;

            // Act
            var badResponse = _controller.Delete(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}
