using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using F1;
using F1.Controllers;
using F1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using PartialViewResult = Microsoft.AspNetCore.Mvc.PartialViewResult;

namespace F1Test
{
    public class ControllersTests
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }
        [Test]
        public void HomeControllerIndex()
        {
            var controller = new HomeController(_logger, _context);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [Test]
        public void HomeControllerPrivacy()
        {
            var controller = new HomeController(_logger, _context);
            var result = controller.Privacy() as ViewResult;
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerIndex()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerDetails()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Details(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerCreate()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Create();
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerEdit()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Edit(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerDelete()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Delete(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerDrivers()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Drivers(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void NationalitiesControllerTeams()
        {
            var controller = new NationalitiesController(_context);
            var result = controller.Teams(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void TeamsControllerIndex()
        {
            var controller = new TeamsController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
        [Test]
        public void TeamsControllerDetails()
        {
            var controller = new TeamsController(_context);
            var result = controller.Details(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void TeamsControllerEdit()
        {
            var controller = new TeamsController(_context);
            var result = controller.Edit(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void TeamsControllerDelete()
        {
            var controller = new TeamsController(_context);
            var result = controller.Delete(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void TeamsControllerDrivers()
        {
            var controller = new TeamsController(_context);
            var result = controller.Drivers(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void RacingDriversControllerIndex()
        {
            var controller = new RacingDriversController(_context);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
        [Test]
        public void RacingDriversControllerDetails()
        {
            var controller = new RacingDriversController(_context);
            var result = controller.Details(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void RacingDriversControllerEdit()
        {
            var controller = new RacingDriversController(_context);
            var result = controller.Edit(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void RacingDriversControllerDelete()
        {
            var controller = new RacingDriversController(_context);
            var result = controller.Delete(1);
            Assert.IsNotNull(result);
        }
    }
}