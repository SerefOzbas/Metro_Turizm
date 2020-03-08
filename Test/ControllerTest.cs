using System;
using System.Web.Mvc;
using Bll.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using NSubstitute;
using UI.MVC.Controllers;

namespace Test
{
    [TestClass]
    public class ControllerTest
    {
        private IBusService _busService;
        private ITicketService _ticketService;
        private IUserService _userService;
        private HomeController _homecontroller;

        [TestInitialize]
        public void Initialize()
        {
            _busService = Substitute.For<IBusService>();
            _ticketService = Substitute.For<ITicketService>();
            _userService = Substitute.For<IUserService>();
            _homecontroller = new HomeController(_busService, _ticketService, _userService);
        }
        [TestMethod]
        public void TestPay()
        {
            Bus result = _busService.Get(0);
            Assert.IsNull(result);
        }
    }
}
