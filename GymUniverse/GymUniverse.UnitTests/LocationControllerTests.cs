using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.LocationViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymUniverse.UnitTests
{
    public class LocationControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private LocationController _controller;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<GymUniverseDbContext>();

            // Initialize controller with mock context
            _controller = new LocationController(_mockContext.Object);
        }

        [Test]
        public async Task CreateLocation_POST_ShouldRedirectToIndex_WhenModelIsValid()
        {
            // Arrange
            var model = new CreateLocationViewModel
            {
                Name = "New Location",
                Address = "New Address",
                ImageUrl = "newImage.jpg",
                Description = "New Description"
            };

            // Act
            var result = await _controller.CreateLocation(model) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task CreateLocation_POST_ShouldReturnView_WhenModelIsInvalid()
        {
            // Arrange
            var model = new CreateLocationViewModel
            {
                Name = "",
                Address = "",
                ImageUrl = "",
                Description = ""
            };

            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.CreateLocation(model) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public async Task LocationDetails_ShouldReturnNotFound_WhenLocationDoesNotExist()
        {
            // Act
            var result = await _controller.LocationDetails(99) as NotFoundResult;

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_ShouldRedirectToIndex_WhenLocationExists()
        {
            // Arrange
            var location = new Location { Id = 1, Name = "Location 1" };
            _mockContext.Setup(c => c.Locations.FindAsync(1)).ReturnsAsync(location);

            // Act
            var result = await _controller.Delete(1) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task Delete_ShouldReturnNotFound_WhenLocationDoesNotExist()
        {
            // Act
            var result = await _controller.Delete(99) as NotFoundResult;

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task EditLocation_GET_ShouldReturnViewResult_WithEditLocationViewModel()
        {
            // Arrange
            var location = new Location { Id = 1, Name = "Location 1", Address = "Address 1" };
            _mockContext.Setup(c => c.Locations.FindAsync(1)).ReturnsAsync(location);

            // Act
            var result = await _controller.EditLocation(1) as ViewResult;
            var model = result?.Model as EditLocationViewModel;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(model, Is.Not.Null);
            Assert.That(model?.Name, Is.EqualTo("Location 1"));
        }

        [Test]
        public async Task EditLocation_POST_ShouldRedirectToIndex_WhenModelIsValid()
        {
            // Arrange
            var model = new EditLocationViewModel
            {
                Id = 1,
                Name = "Updated Location",
                Address = "Updated Address",
                ImageUrl = "updatedImage.jpg",
                Description = "Updated Description"
            };

            var location = new Location { Id = 1, Name = "Old Location" };
            _mockContext.Setup(c => c.Locations.FindAsync(1)).ReturnsAsync(location);

            // Act
            var result = await _controller.EditLocation(model) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task EditLocation_POST_ShouldReturnView_WhenModelIsInvalid()
        {
            // Arrange
            var model = new EditLocationViewModel { Name = "" };
            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.EditLocation(model) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
