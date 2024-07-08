using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ZooTracker.Models.ViewModels;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Controllers;
using ZooTracker.Models.Entity;
using ZooTracker.Utility.Interface;

namespace ZooTracker.UnitTests
{
    public class ZoosControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<ZooController>> _mockLogger;
        private readonly ZooController _controller;
        private readonly Mock<IZooHelpers> _helpers;

        public ZoosControllerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ZooController>>();
            _helpers = new Mock<IZooHelpers>();
            _controller = new ZooController(_mockUnitOfWork.Object, _mockLogger.Object, _helpers.Object);
        }

        [Fact]
        public async Task GetAllZoos_ReturnsActiveZoos()
        {
            // Arrange
            var zoos = new List<Zoo>
        {
            new Zoo { Id = 1, IsActive = true },
            new Zoo { Id = 2, IsActive = false },
            new Zoo { Id = 3, IsActive = true }
        };

            _mockUnitOfWork.Setup(u => u.Zoos.GetAll(It.IsAny<string>()))
                .Returns(zoos);

            // Set up the HttpContext for the controller
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, "test@example.com") };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = await _controller.GetAllZoos(includeInactive: false) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedZoos = result.Value as IEnumerable<ZooVM>;
            Assert.NotNull(returnedZoos);
            Assert.Equal(2, returnedZoos.Count());
        }

        [Fact]
        public async Task GetAllZoos_ReturnsAllZoos_WhenIncludeInactiveIsTrue()
        {
            // Arrange
            var zoos = new List<Zoo>
        {
            new Zoo { Id = 1, IsActive = true },
            new Zoo { Id = 2, IsActive = false },
            new Zoo { Id = 3, IsActive = true }
        };

            _mockUnitOfWork.Setup(u => u.Zoos.GetAll(It.IsAny<string>()))
                .Returns(zoos);

            // Set up the HttpContext for the controller
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, "test@example.com") };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = await _controller.GetAllZoos(includeInactive: true) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedZoos = result.Value as IEnumerable<ZooVM>;
            Assert.NotNull(returnedZoos);
            Assert.Equal(3, returnedZoos.Count());
        }
    }
}