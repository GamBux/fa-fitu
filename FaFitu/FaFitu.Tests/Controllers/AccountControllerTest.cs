using FaFitu.Controllers;
using FaFitu.Models;
using FaFitu.Tests.MockedDatabaseUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace FaFitu.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        AccountController CreateAccountController()
        {
            return new AccountController(new MockedUsersRepository(), true);
        }

        [TestMethod]
        public void RegisterNonexistent()
        {
            // Arrange
            var urepo = new MockedUsersRepository();
            var controller = new AccountController(urepo, true);
            Assert.IsFalse(urepo.UserExists("ojezujzu"));

            // Act
            ActionResult result = controller.Register(new RegisterModel { UserName = "ojezujzu", Password = "a" });

            // Assert
            Assert.IsTrue(urepo.UserExists("ojezujzu"));
        }
    }
}
