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

        [TestMethod()]
        public void AddPageTest()
        {

            Pencil1Entities db = new Pencil1Entities();
            string Login = "765";
            string Password = "2";
            string Name = "3";

            User user = new User { Login = Login, Name = Name, Password = Password };
            db.User.Add(user);
            db.SaveChanges();
            var logincheck2 = db.User.Where(x => x.Login == Login).FirstOrDefault();

            Assert.IsTrue(logincheck2 != null);
        }

        [TestMethod()]
        public void AddEditPageTest()
        {
            Pencil1Entities db = new Pencil1Entities();
            string login = "765";
            string buffer = "asdad";

            var logincheck = db.User.Where(x => x.Login == login).FirstOrDefault();
            logincheck.Name = buffer;
            db.SaveChanges();
            var logincheck2 = db.User.Where(x => x.Login == login).FirstOrDefault();

            Assert.IsTrue(logincheck2.Name == buffer);
        }

        [TestMethod()]
        public void DeleteTest()
        {

            Pencil1Entities db = new Pencil1Entities();
            string login = "765";
            var logincheck = db.User.Where(x => x.Login == login).FirstOrDefault();
            db.User.Remove(logincheck);
            db.SaveChanges();
            var logincheck2 = db.User.Where(x => x.Login == login).FirstOrDefault();

            Assert.IsTrue(logincheck2 == null);
        }
    }
    
}
