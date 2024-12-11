using GymUniverse.Controllers;
using GymUniverse.Data;
using GymUniverse.Models;
using GymUniverse.ViewModels.CourseViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymUniverse.UnitTests
{
    public class CourseControllerTests
    {
        private Mock<GymUniverseDbContext> _mockContext;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private CourseController _controller;

        [SetUp]
        public void Setup()
        {
            // Mocking the DbContext and UserManager
            _mockContext = new Mock<GymUniverseDbContext>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null
            );
            _controller = new CourseController(_mockContext.Object, _mockUserManager.Object);
        }
    }
}
