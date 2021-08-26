using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject
{
    public class MainTest
    {
        IWebDriver driver;
        HomePage homePage;
        LogInPage loginPage;

        private const string invalidEmailErrorText = "Please input a valid email address";
        private const string invalidPasswordErrorText = "Please input your password";
        private const string invalidEmailAndPasswordText = "Invalid email/password combination";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            loginPage = new LogInPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://app-stg.i2i.ubx.ph/");
        }

        [Test]
        public void CheckBlankEmailAndPassword()
        {
            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress("");
            loginPage.EnterPassword("");
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidEmailErrorMessage(), invalidEmailErrorText);
            Assert.AreEqual(loginPage.GetInvalidPasswordMessage(), invalidPasswordErrorText);
        }
        [Test]
        public void CheckBlankEmailAndValidPassword()
        {
            string validPassword = "samplevalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress("");
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidEmailErrorMessage(), invalidEmailErrorText);
        }
        [Test]
        public void CheckValidEmailAndBlankPassword()
        {
            string validEmail = "samplevalidemail@gmail.com";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.EnterPassword("");
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidPasswordMessage(), invalidPasswordErrorText);
        }
        [Test]
        public void CheckInvalidEmailAndInvalidPassword()
        {
            string invalidEmail = "sampleinvalidemail@gmail.com";
            string invalidPassword = "sampleinvalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress(invalidEmail);
            loginPage.EnterPassword(invalidPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetErrorMessage(), invalidEmailAndPasswordText);
        }
        [Test]
        public void CheckInvalidEmailWithoutEmailDomainAndValidPassword()
        {
            string invalidEmailWithoutDomain = "sampleinvalidemailwithoutemaildomain";
            string validPassword = "samplevalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress(invalidEmailWithoutDomain);
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetInvalidEmailErrorMessage(), invalidEmailErrorText);
        }
        [Test]
        public void CheckValidEmailAndInvalidPassword()
        {
            string validEmail = "samplevalidemail@gmail.com";
            string invalidPassword = "sampleinvalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.EnterPassword(invalidPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetErrorMessage(), invalidEmailAndPasswordText);
        }
        [Test]
        public void CheckValidEmailAndOldPassword()
        {
            string validEmail = "samplevalidemail@gmail.com";
            string oldPassword = "sampleinvalidpassword";

            homePage.WaitToLoadHomePage();
            homePage.ClickLoginButton();
            loginPage.WaitToLoadLogInPage();
            loginPage.ClickLoginButton();
            loginPage.EnterEmailAddress(validEmail);
            loginPage.EnterPassword(oldPassword);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetErrorMessage(), invalidEmailAndPasswordText);
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

    }
}