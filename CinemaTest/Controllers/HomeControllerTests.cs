using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CinemaTR3.Models;
using CinemaTR3.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CinemaTest.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            HomeController HC = new HomeController();
            User u = new User();
            u.Login = "TopBor";
            u.Password = "ebidod90";

            ViewResult exp = HC.Login(u.Login, u.Password) as ViewResult;
            Assert.IsNotNull(exp);
        }
    }
}
