using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SUTLoginTest
{
    public class Tests
    {
        IWebDriver _driver;

        public Tests(IWebDriver driver)
        {
            _driver = driver;
        }

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximazed");
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/login.php");
            _driver.Manage().Window.Minimize();

            _driver.FindElement(By.XPath("//input[@name='email']")).Clear();
            _driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("admin@automation.com");

            _driver.FindElement(By.XPath("//input[@name='pass']")).Clear();
            _driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("pass123");

            _driver.FindElement(By.XPath("//button[@name='btn-login']")).Click();

            Assert.IsTrue(_driver.FindElement(By.XPath("//h1[.='Hello, Admin Automation']")).Displayed);


        }
        [TearDown]
        public void DisposeDriver()
        {
            _driver.Dispose();
        }

    }
}