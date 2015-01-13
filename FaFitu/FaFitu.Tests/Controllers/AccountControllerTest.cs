using FaFitu.Controllers;
using FaFitu.DatabaseUtils;
using FaFitu.Models;
using FaFitu.Tests.MockedDatabaseUtils;
using Microsoft.Practices.Unity;
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
       // public IUsersRepository urepo { set; get; }

      /*  [TestInitialize()]
        public void AssemblyInit()
        {
           // var cont = Bootstrapper.Initialise();
            urepo = new MockedUsersRepository();
        }*/

        AccountController CreateAccountController(IUsersRepository iur)
        {
            return new AccountController(iur, true/*new IUsersRepository(), true*/);
        }

        [TestMethod]
        public void RegisterNonexistent()
        {
            // Arrange
            var iur = new MockedUsersRepository();
            var controller = CreateAccountController(iur);
          //  IUnityContainer cont = Bootstrapper.Initialise();

            Assert.IsFalse(iur.UserExists("ojezujzu"));

            // Act
            ActionResult result = controller.Register(new RegisterModel { UserName = "ojezujzu", Password = "a" });

            // Assert
            Assert.IsTrue(iur.UserExists("ojezujzu"));
        }
    }
}
