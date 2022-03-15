using JuiceShopAutomation.PageModels.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceShopAutomation.PageModels
{
    public class LoginPage : BasePage
    {

        const string emailSelector = "email"; // id
        const string emailErrorSelector = "mat-error-0"; // id
        const string passwordSelector = "password"; //
        const string passwordErrorSelector = "mat-error-1"; //id
        const string forgotPasswordSelector = "#login-form > a"; // css
        const string loginButtonSelector = "#loginButton > span.mat-button-wrapper"; // css
        const string rememberMeSelector = "#rememberMe > label > span.mat-checkbox-label"; //
        const string registerLinkSelector = "#newCustomerLink > a"; // css
        const string loginLabelSelector = "body > app-root > div > mat-sidenav-container > mat-sidenav-content > app-login > div > mat-card > h1"; // css

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public Boolean CheckLoginLabel(string label)
        {
            //return String.Compare(label, driver.FindElement(By.CssSelector(loginButtonSelector)).Text) == 0;
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(loginLabelSelector)).Text.ToLower());
        }


        public void Login(string email, string password)
        {
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            loginButton.Click();
        }


    }
}
