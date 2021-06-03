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
    public class AdminControllerTests
    {
        [TestMethod()]
        public void SessionAddTest()
        {
            AdminController AC = new AdminController();
            Session ses = new Session();
            ses.FilmId = 3;
            ses.HallId = 1;
            ses.DateTime = DateTime.Now.AddDays(1);
            ses.ShowStatus = 1;
            int price = 150;

            ActionResult exp = AC.SessionAdd(ses, price) as ActionResult;
            Assert.IsNotNull(exp);
        }
        [TestMethod()]
        public void ChangeStatusTest()
        {
            AdminController AC = new AdminController();
            int id = 4;
            ActionResult exp = AC.ChangeStatus(id) as ActionResult;
            Assert.IsNotNull(exp);
        }
    }
}
