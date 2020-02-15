using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Cheap.Awesome.WebDriver.Test
{
    [TestClass]
    public class ChromeDriverTest
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            _driver.Url = "https://www.bing.com";
            Assert.AreEqual("Bing", _driver.Title);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
