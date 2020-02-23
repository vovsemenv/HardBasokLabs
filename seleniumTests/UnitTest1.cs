using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HardBasokLabs;
namespace seleniumTests
{
    [TestClass]
    public class lab2Test
    {
        private Lab2 lab;
        [TestInitialize]
        public void lab2dec()
        {
            lab = new Lab2();
        }

        [TestMethod]
        [DataRow("../../../../lab2test1.txt", "../../../../lab2test1res.txt")]
        [DataRow("../../../../lab2test2.txt", "../../../../lab2test2res.txt")]

        public void everythingTest(string inpUrl, string outUrl)
        {
            (var img, var store) = lab.inputData(inpUrl);
            var res = lab.checkPages(img, store);
            var expexted = Lab2.Readtestvals(outUrl);
            if (res.Count == expexted.Count)
            {
                for (int i = 0; i < expexted.Count; i++)
                {
                    if (expexted[i] != res[i]) Assert.Fail("wrong");
                }
            }
            else
            {
                Assert.Fail("Wrodng");
            }


        }
    }

    [TestClass]
    public class vkFriendTest{
        private Lab5 lab;
        [TestInitialize]
        public void lab2dec()
        {
            lab = new Lab5();
        }
        
        [TestMethod]

        public void lab5test()
        {
            if (confidentials.password == "undefined" || confidentials.username == "undefined")
            {
                Assert.Fail("Undefined login data in confidentials.cs");
            }
            var friendonline = lab.loginAndGetOnline(confidentials.username,confidentials.password);
            Assert.IsTrue(friendonline.Count!=0);
        }


    }
}
