using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pen69.Pages;
using Pen69Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen69.Pages.Tests
{
    [TestClass()]
    public class AuthPageTests
    {
        [TestMethod()]
        public void AuthPageTest()
        {
            string login = "1";
            Pencil1Entities DB = new Pencil1Entities();
            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();
            Assert.IsTrue(loginCheck != null);
        }
    }
}