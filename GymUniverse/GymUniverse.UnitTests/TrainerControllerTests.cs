using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymUniverse.UnitTests
{
    public class TrainerControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private TrainerController _controller;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<GymUniverseDbContext>();
            _controller = new TrainerController(_mockContext.Object);
        }

        [Test]
        public async Task CreateTrainer_ShouldReturnView_WhenModelStateIsInvalid()
        {
            // Arrange
            var viewModel = new CreateTrainerViewModel { LocationId = 1 };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = await _controller.CreateTrainer(viewModel) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.Model, Is.EqualTo(viewModel));
        }

        [Test]
        public async Task CreateTrainer_ShouldRedirect_WhenModelStateIsValid()
        {
            // Arrange
            var viewModel = new CreateTrainerViewModel
            {
                LocationId = 1,
                Name = "John Doe",
                Age = 30,
                Bio = "Fitness Trainer",
                ImageUrl = "imageUrl"
            };

            var location = new Location { Id = 1, Name = "Gym Location" };
            _mockContext.Setup(c => c.Locations.FindAsync(viewModel.LocationId)).ReturnsAsync(location);
            _mockContext.Setup(c => c.Trainers.Add(It.IsAny<Trainer>()));
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _controller.CreateTrainer(viewModel) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("LocationDetails"));
            Assert.That(result?.RouteValues["id"], Is.EqualTo(viewModel.LocationId));
        }

        [Test]
        public async Task EditTrainer_ShouldRedirect_WhenTrainerIsUpdated()
        {
            // Arrange
            var trainer = new Trainer
            {
                Id = 1,
                Name = "John Doe",
                Age = 30,
                Bio = "Fitness Trainer",
                ImageUrl = "imageUrl"
            };

            _mockContext.Setup(c => c.Trainers.FindAsync(trainer.Id)).ReturnsAsync(trainer);
            _mockContext.Setup(c => c.Trainers.Update(It.IsAny<Trainer>()));
            _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var viewModel = new TrainerEditViewModel
            {
                Id = trainer.Id,
                Name = "John Doe Updated",
                Age = 31,
                Bio = "Updated Bio",
                ImageUrl = "updatedImageUrl"
            };

            // Act
            var result = await _controller.EditTrainer(viewModel) as RedirectToActionResult;

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            Assert.That(result?.ActionName, Is.EqualTo("TrainerDetails"));
            Assert.That(result?.RouteValues["id"], Is.EqualTo(viewModel.Id));
        }
    }
}
