using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Cheap.Awesome.WebDriver.Test
{
    [TestClass]
    public class ChromeDriverTest
    {
        private ChromeDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        /// Will check if file from http://localhost:52729/swagger/v1/swagger.json is accessible
        /// In same cases when swagger in not configured correctly the file isn't present 
        /// and swagger UI dont't work
        /// </summary>

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


        /// <summary>
        /// This method will open chrome browser and will test swagger UI by compliting automatically 
        /// destinationId and number of nights.
        /// </summary>
        [TestMethod]
        [Obsolete]
        public void CheckIfCanCallAPIbySwagger()
        {
            _driver.Url = "http://localhost:52729/index.html";

            var hotelAPI = _driver.FindElementByXPath("//*[@id=\"operations-Hotel-get_Hotel__destinationId___nights_\"]/div[1]");
            hotelAPI.Click();

            var tryItOutBtn = _driver.FindElementByXPath("//*[@id=\"operations-Hotel-get_Hotel__destinationId___nights_\"]/div[2]/div/div[1]/div[1]/div[2]/button");
            tryItOutBtn.Click();

            var destinationIdTextBox = _driver.FindElementByXPath("//*[@id=\"operations-Hotel-get_Hotel__destinationId___nights_\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[2]/input");
            destinationIdTextBox.SendKeys("279");

            var nightsTextBox = _driver.FindElementByXPath("//*[@id=\"operations-Hotel-get_Hotel__destinationId___nights_\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[2]/td[2]/input");
            nightsTextBox.SendKeys("9");

            var executeAPIbtn = _driver.FindElementByXPath("//*[@id=\"operations-Hotel-get_Hotel__destinationId___nights_\"]/div[2]/div/div[2]/button");
            executeAPIbtn.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]")));
            var status =_driver.FindElementByXPath("//*/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]");

            Assert.AreEqual("200", status.Text);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
