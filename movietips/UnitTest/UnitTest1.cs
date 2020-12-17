using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using static DataLayer.DBContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            Login t = new Login();
            Assert.IsTrue(t.user_check("yura", "pass"));
        }
        [TestMethod]
        public void TestLogin1()
        {
            Login t1 = new Login();
            Assert.IsFalse(t1.user_check("maxim","pass"));
        }

        [TestMethod]
        public void TestMovie()
        {
            BusinessLayer.Movie m = new BusinessLayer.Movie("ForestGump");
            var mov = dbContext.Movie.First(m=> m.Name == "ForestGump");
            Assert.IsTrue(mov.Name== "ForestGump");
        }

        [TestMethod]
        public void TestMovie1()
        {
            BusinessLayer.Movie m = new BusinessLayer.Movie("ForestGump");
            var mov = dbContext.Movie.First(m=> m.Name == "ForestGump");
            Assert.IsTrue(mov.Id== 53);
        }

        [TestMethod]
        public void TestMovieTip()
        {
            BusinessLayer.MovieTip mt = new BusinessLayer.MovieTip("some tip","yura", 53, 77);
            mt.commitTipToDB();
            Assert.IsTrue(mt.getCommentText() == "some tip");
        }
        
        [TestMethod]
        public void TestRegistration()
        {
            Login t = Registration.registrate("User_arsen8","pass","Arsen");
            Assert.IsTrue(t.getStatus() == "ok");
        }

        [TestMethod]
        public void TestRegistration1()
        {
            Login t = Registration.registrate("User_arsen8","pass","Arsen");
            Assert.IsTrue(t.getStatus() == "User already exists");
        }
    }
}
