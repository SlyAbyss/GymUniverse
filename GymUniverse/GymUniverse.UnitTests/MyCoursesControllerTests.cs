using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.UnitTests
{
    public class MyCoursesControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private MyCoursesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<GymUniverseDbContext>();

            var store = new Mock<IUserStore<ApplicationUser>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

            // Initialize the controller with mock context and user manager
            _controller = new MyCoursesController(_mockContext.Object, _mockUserManager.Object);
        }

        [Test]
        public async Task Index_ShouldReturnUnauthorized_WhenUserIsNotAuthenticated()
        {
            // Arrange
            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _controller.Index() as UnauthorizedResult;

            // Assert
            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}
