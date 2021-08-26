using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    class LogInPage
    {
        IWebDriver driver;

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitToLoadLogInPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath("//span[contains(text(),'Sign in to your i2i account')]")));
        }
        public void ClickLoginButton()
        {
            IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id='root']/div/div/div[2]/span/div/div/div[2]/div/div/span[1]/div/button"));
            loginbutton.Click();
        }
        public void EnterEmailAddress(string emailInput)
        {
            IWebElement email = driver.FindElement(By.Name("email"));
            email.SendKeys(emailInput);
        }
        public void EnterPassword(string passwordInput)
        {
            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys(passwordInput);
        }
        public string GetErrorMessage()
        {
            string errorContainerXPath = "//*[@id='root']/div/div/div[2]/span/div/div/div[2]/div/span[3]/div";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));         
            wait.Until(driver => driver.FindElement(By.XPath(errorContainerXPath)));
            IWebElement errormessage = driver.FindElement(By.XPath(errorContainerXPath));
            return errormessage.Text;
        }
        public string GetInvalidEmailErrorMessage()
        {
            string errorEmailContainerXPath = "//*[@id='root']/div/div/div[2]/span/div/div/div[2]/div/span[3]/form/div[1]/div[3]";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath(errorEmailContainerXPath)));
            IWebElement errorEmailMessage = driver.FindElement(By.XPath(errorEmailContainerXPath));
            return errorEmailMessage.Text;
        }
        public string GetInvalidPasswordMessage()
        {
            string errorPasswordContainerXPath = "//*[@id='root']/div/div/div[2]/span/div/div/div[2]/div/span[3]/form/div[2]/div[2]";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.XPath(errorPasswordContainerXPath)));
            IWebElement errorPasswordMessage = driver.FindElement(By.XPath(errorPasswordContainerXPath));
            return errorPasswordMessage.Text;
        }

    }

}
