using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.RoomViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.UnitTests
{
    public class RoomControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private RoomController _controller;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<GymUniverseDbContext>();
            _controller = new RoomController(_mockContext.Object);
        }

        [Test]
        public async Task CreateRoom_ShouldReturnView_WhenModelStateIsInvalid()
        {
            // Arrange
            var model = new CreateRoomViewModel { LocationId = 1 };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = await _controller.CreateRoom(model) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.Model, Is.EqualTo(model));
        }

        [Test]
        public async Task CreateRoom_ShouldRedirect_WhenModelStateIsValid()
        {
            // Arrange
            var model = new CreateRoomViewModel
            {
                LocationId = 1,
                Name = "Room A",
                Description = "A test room",
                ImageUrl = "imageUrl"
            };

            var location = new Location { Id = 1, Name = "Location A" };
            _mockContext.Setup(c => c.Locations.FindAsync(model.LocationId)).ReturnsAsync(location);
            _mockContext.Setup(c => c.Rooms.Add(It.IsAny<Room>()));
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _controller.CreateRoom(model) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("LocationDetails"));
            Assert.That(result?.RouteValues["id"], Is.EqualTo(model.LocationId));
        }

        [Test]
        public async Task EditRoom_ShouldReturnNotFound_WhenRoomDoesNotExist()
        {
            // Arrange
            var roomId = 1;
            _mockContext.Setup(c => c.Rooms.FindAsync(roomId)).ReturnsAsync((Room)null);

            // Act
            var result = await _controller.EditRoom(roomId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task EditRoom_ShouldReturnView_WhenRoomExists()
        {
            // Arrange
            var room = new Room
            {
                Id = 1,
                Name = "Room A",
                Description = "Room A Description",
                ImageUrl = "imageUrl"
            };

            _mockContext.Setup(c => c.Rooms.FindAsync(room.Id)).ReturnsAsync(room);

            var viewModel = new RoomEditViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
                ImageUrl = room.ImageUrl
            };

            // Act
            var result = await _controller.EditRoom(room.Id) as ViewResult;
            var model = result?.Model as RoomEditViewModel;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(model?.Name, Is.EqualTo(viewModel.Name));
        }
    }
}
