using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.EquipmentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymUniverse.UnitTests
{
    public class EquipmentControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private EquipmentController _controller;

        [SetUp]
        public void Setup()
        {
            // Mocking the DbContext
            _mockContext = new Mock<GymUniverseDbContext>();
            _controller = new EquipmentController(_mockContext.Object);
        }

        [Test]
        public void CreateEquipment_Get_ShouldReturnCorrectViewModel()
        {
            // Arrange
            var roomId = 1;

            // Act
            var result = _controller.CreateEquipment(roomId) as ViewResult;
            var model = result?.Model as CreateEquipmentViewModel;

            // Assert
            Assert.That(model, Is.InstanceOf<CreateEquipmentViewModel>());
            Assert.That(model?.RoomId, Is.EqualTo(roomId));
        }

        [Test]
        public async Task CreateEquipment_Post_ShouldCreateEquipment_WhenModelIsValid()
        {
            // Arrange
            var model = new CreateEquipmentViewModel
            {
                RoomId = 1,
                Name = "Treadmill",
                ImageUrl = "http://example.com/treadmill.jpg",
                Description = "A high-quality treadmill."
            };

            var mockDbSet = CreateMockDbSet(new List<Equipment>());
            _mockContext.Setup(c => c.Equipment).Returns(mockDbSet.Object);

            // Act
            var result = await _controller.CreateEquipment(model) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("AddEquipment"));
            Assert.That(result?.RouteValues["roomId"], Is.EqualTo(model.RoomId));

            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task CreateEquipment_Post_ShouldReturnView_WhenModelIsInvalid()
        {
            // Arrange
            var model = new CreateEquipmentViewModel
            {
                RoomId = 1,
                Name = "",
                ImageUrl = "",
                Description = ""
            };
            _controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await _controller.CreateEquipment(model) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.ViewName, Is.EqualTo(string.Empty)); // Default view
        }

        [Test]
        public async Task DeleteEquipment_ShouldDeleteEquipment_WhenEquipmentExists()
        {
            // Arrange
            var equipmentId = 1;
            var equipment = new Equipment
            {
                Id = equipmentId,
                Name = "Dumbbell",
                ImageUrl = "url",
                Description = "Heavy dumbbell"
            };
            _mockContext.Setup(c => c.Equipment.FindAsync(It.IsAny<int>())).ReturnsAsync(equipment);

            // Act
            var result = await _controller.DeleteEquipment(equipmentId) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("Index"));
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task DeleteEquipment_ShouldReturnNotFound_WhenEquipmentDoesNotExist()
        {
            // Arrange
            var equipmentId = 999;
            _mockContext.Setup(c => c.Equipment.FindAsync(It.IsAny<int>())).ReturnsAsync((Equipment)null);

            // Act
            var result = await _controller.DeleteEquipment(equipmentId, null);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task RemoveEquipment_ShouldRemoveEquipmentFromRoom_WhenRoomAndEquipmentExist()
        {
            // Arrange
            var roomId = 1;
            var equipmentId = 1;
            var roomEquipment = new RoomEquipment { RoomId = roomId, EquipmentId = equipmentId };

            _mockContext.Setup(c => c.RoomsEquipments.FirstOrDefault(It.IsAny<Func<RoomEquipment, bool>>()))
                        .Returns(roomEquipment);

            // Act
            var result = await _controller.RemoveEquipment(roomId, equipmentId) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("AddEquipment"));
            _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task RemoveEquipment_ShouldReturnNotFound_WhenRoomEquipmentDoesNotExist()
        {
            // Arrange
            var roomId = 1;
            var equipmentId = 999; // Invalid equipment ID
            _mockContext.Setup(c => c.RoomsEquipments.FirstOrDefault(It.IsAny<Func<RoomEquipment, bool>>()))
                        .Returns((RoomEquipment)null);

            // Act
            var result = await _controller.RemoveEquipment(roomId, equipmentId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
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
