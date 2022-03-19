using JuiceShopAutomation.PageModels.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JuiceShopAutomation.PageModels
{
    public class RegistrationPage : BasePage
    {

        const string registrationLabelSelector = ".mat-card > h1:nth-child(1)"; // css
        const string emailInputSelector = "emailControl"; // id
        const string passwordInputSelector = "passwordControl";// id
        const string repeatPassInputSelector = "repeatPasswordControl"; //id
        const string passwordAdviceSelector = "mat-slide-toggle-thumb"; //class
        const string securityQuestionSelector = "/html/body/app-root/div/mat-sidenav-container/mat-sidenav-content/app-register/div/mat-card/div[2]/div[1]/mat-form-field[1]/div/div[1]/div[3]/mat-select"; // id
        const string securityAnswerSelector = "securityAnswerControl"; // id
        const string registerButtonSelector = "registerButton"; //id
        const string alreadyCustomerSelector = "alreadyACustomerLink"; // id

        public Boolean CheckRegistrationLabel(string label)
        {
            return String.Equals(label.ToLower(), driver.FindElement(By.CssSelector(registrationLabelSelector)).Text.ToLower());
        }

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }

        public void RegisterUser(string email, string password, bool showPasswordAdvice, int securityQuestionIndex, string answer)
        {
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var repeatPaswordInput = driver.FindElement(By.Id(repeatPassInputSelector));
            repeatPaswordInput.Clear();
            repeatPaswordInput.SendKeys(password);
            if (showPasswordAdvice)
            {
                var showPasswordAdviceInput = driver.FindElement(By.ClassName(passwordAdviceSelector));
                showPasswordAdviceInput.Click();
            }
            // remove the http password error
            var label = driver.FindElement(By.CssSelector(registrationLabelSelector));
            label.Click();
            // Click on drop down
            var select = Utils.WaitForFluentElement(driver, 10, By.XPath(securityQuestionSelector));
            select.Click();
            string selector = String.Format("mat-option-{0}", 3 + securityQuestionIndex);
            var securityQuestionSelection = driver.FindElement(By.Id(selector));
            //Console.WriteLine(securityQuestionSelection.Text);
            securityQuestionSelection.Click();

            // alternative
            /*var select2 = driver.FindElements(By.XPath("/html/body/div[3]/div[2]/div/div/div/mat-option"));
            foreach (var elem in select2)
            {
                Console.WriteLine(elem.FindElement(By.XPath("span")).Text);
            }*/

            var answerInput = driver.FindElement(By.Id(securityAnswerSelector));
            answerInput.Clear();
            answerInput.SendKeys(answer);

            var submitButton = Utils.WaitForElementClickable(driver, 10, By.Id(registerButtonSelector));
            submitButton.SendKeys(Keys.Return);

        }
    }
}
