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
        public void CheckSwaggerEndpoint()
        {
            _driver.Url = "http://localhost:52729/swagger/v1/swagger.json";
            var swaggerJson = _driver.FindElementByXPath("/html/body/pre");
            swaggerJson.Text.Contains("My Hotels APIs");
            Assert.IsTrue(swaggerJson.Text.Contains("My Hotels APIs"));
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            _driver.Url = "http://localhost:52729/index.html";
            Assert.AreEqual("Swagger UI", _driver.Title);
        }



        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
