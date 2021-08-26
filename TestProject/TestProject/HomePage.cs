using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickLoginButton()
        {
            IWebElement loginbutton = driver.FindElement(By.XPath("//span[contains(text(),'Login')]"));
            loginbutton.Click();
        }
        public void WaitToLoadHomePage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.ClassName("MuiIconButton-label")));
        }
    }

}
