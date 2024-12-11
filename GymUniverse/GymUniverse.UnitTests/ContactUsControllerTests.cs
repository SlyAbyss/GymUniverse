using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.ContactUsViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymUniverse.UnitTests
{
    public class ContactUsControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private ContactUsController _controller;

        [SetUp]
        public void Setup()
        {
            // Mocking the DbContext and UserManager
            _mockContext = new Mock<GymUniverseDbContext>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), 
                null, null, null, null, null, null, null, null
            );
            _controller = new ContactUsController(_mockContext.Object, _mockUserManager.Object);
        }

        [Test]
        public async Task Index_ShouldReturnCorrectViewModel()
        {
            // Arrange
            var user = new ApplicationUser { UserName = "testuser", Email = "testuser@test.com" };
            _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _controller.Index() as ViewResult;
            var model = result?.Model as ContactMessageViewModel;

            // Assert
            Assert.That(model, Is.InstanceOf<ContactMessageViewModel>());
            Assert.That(model?.LoggedInUsername, Is.EqualTo("testuser"));
            Assert.That(model?.LoggedInEmail, Is.EqualTo("testuser@test.com"));
        }

        [Test]
        public async Task Submit_ShouldSaveMessageAndRedirect_WhenModelIsValid()
        {
            // Arrange
            var model = new ContactMessageViewModel
            {
                Name = "Test User",
                Email = "testuser@test.com",
                Message = "Test message"
            };

            // Mock DbSet to simulate saving
            var mockDbSet = new Mock<DbSet<ContactMessage>>();
            _mockContext.Setup(c => c.ContactMessages).Returns(mockDbSet.Object);

            // Act
            var result = await _controller.Submit(model) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("Index"));
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task Submit_ShouldReturnView_WhenModelIsInvalid()
        {
            // Arrange
            var model = new ContactMessageViewModel
            {
                Name = "", // Invalid model
                Email = "invalidemail", // Invalid email
                Message = ""
            };
            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.Submit(model) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task UserMessages_ShouldReturnMessagesForAdmin()
        {
            // Arrange
            var messages = new List<ContactMessage>
            {
                new ContactMessage { Id = 1, Name = "User 1", Email = "user1@test.com", Message = "Message 1", SubmittedAt = DateTime.Now },
                new ContactMessage { Id = 2, Name = "User 2", Email = "user2@test.com", Message = "Message 2", SubmittedAt = DateTime.Now }
            };
            var mockDbSet = CreateMockDbSet(messages);
            _mockContext.Setup(c => c.ContactMessages).Returns(mockDbSet.Object);

            // Act
            var result = await _controller.UserMessages() as ViewResult;
            var model = result?.Model as UserMessagesViewModel;

            // Assert
            Assert.That(model, Is.InstanceOf<UserMessagesViewModel>());
            Assert.That(model?.ContactMessages.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteMessage_ShouldDeleteMessage_WhenMessageExists()
        {
            // Arrange
            var message = new ContactMessage { Id = 1, Name = "Test", Email = "test@test.com", Message = "Test message" };
            _mockContext.Setup(c => c.ContactMessages.FindAsync(It.IsAny<int>())).ReturnsAsync(message);
            var mockDbSet = CreateMockDbSet(new List<ContactMessage> { message });
            _mockContext.Setup(c => c.ContactMessages).Returns(mockDbSet.Object);

            // Act
            var result = await _controller.DeleteMessage(1) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            _mockContext.Verify(c => c.ContactMessages.Remove(It.IsAny<ContactMessage>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task DeleteMessage_ShouldNotDelete_WhenMessageDoesNotExist()
        {
            // Arrange
            _mockContext.Setup(c => c.ContactMessages.FindAsync(It.IsAny<int>())).ReturnsAsync((ContactMessage)null);

            // Act
            var result = await _controller.DeleteMessage(999) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            _mockContext.Verify(c => c.ContactMessages.Remove(It.IsAny<ContactMessage>()), Times.Never);
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockDbSet;
        }
    }
}
