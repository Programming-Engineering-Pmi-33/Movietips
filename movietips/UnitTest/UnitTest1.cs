using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using DataLayer;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestLogin()
        {
            Login result = new User("yura","pass");//test for existing username
            Assert.isTrue(result, String.Format("Expected for '{1}':false; Actual: {0}"));
        }
    }
}
