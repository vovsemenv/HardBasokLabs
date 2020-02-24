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
        [DataRow("../../../../lab2InputTest1.txt", "../../../../lab2InputTest1res.txt")]        
        public void getDataTest(string inputUrl,string resurl)
        {
            (var img, var store) = lab.inputData(inputUrl);
            var exprcted = lab.inputData(resurl);
            Assert.AreEqual(img, exprcted.Item1);
            if (store.Count == exprcted.Item2.Count)
            {
                for (int i = 0; i < exprcted.Item2.Count; i++)
                {
                    if (exprcted.Item2[i] != store[i]) Assert.Fail("wrong");
                }
            }
            else
            {
                Assert.Fail("Wrodng");
            }
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
                for (int    i = 0; i < expexted.Count; i++)
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
        [DataRow(confidentials.invalidUsername,confidentials.invalidpassword,false)]
        [DataRow(confidentials.username, confidentials.password,true)]
        public void loginTest(string login,string pass,bool res)
        {
            var status = lab.login(login, pass);
            Assert.AreEqual(res, status);
        }
        [TestMethod]
        [DataRow("file:///C:/Users/vovse/source/repos/HardBasokLabs/test0.html", 0)]
        [DataRow("file:///C:/Users/vovse/source/repos/HardBasokLabs/test10.html", 10)]
        public void getfriendsTest(string url,int expected)
        {
            var real = lab.getFriendsFromUrl(url);
            Assert.AreEqual(real, expected);

        }



    }
}
