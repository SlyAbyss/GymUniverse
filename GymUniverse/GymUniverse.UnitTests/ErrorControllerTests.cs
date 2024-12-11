using GymUniverse.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace GymUniverse.UnitTests
{
    public class ErrorControllerTests
    {
        private ErrorController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ErrorController();
        }

        [Test]
        public void Error_ShouldReturnError500View()
        {
            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.ViewName, Is.EqualTo("Error500"));
        }

        [Test]
        public void HandleStatusCode_ShouldReturnError404View_WhenStatusCodeIs404()
        {
            // Act
            var result = _controller.HandleStatusCode(404) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.ViewName, Is.EqualTo("Error404"));
        }

        [Test]
        public void HandleStatusCode_ShouldReturnError500View_WhenStatusCodeIsNot404()
        {
            // Act
            var result = _controller.HandleStatusCode(500) as ViewResult;

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            Assert.That(result?.ViewName, Is.EqualTo("Error500"));
        }
    }
}
