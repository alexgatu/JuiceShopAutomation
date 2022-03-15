using JuiceShopAutomation.PageModels.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceShopAutomation.PageModels
{
    public class RegistrationPage : BasePage
    {

        const string registrationLabelSelector = ""; // 
        const string emailInputSelector = ""; //
        const string passwordInputSelector = "";//
        const string repeatPassInputSelector = ""; //
        const string passwordAdviceSelector = ""; //
        const string securityQuestionSelector = "";
        const string securityAnswerSelector = ""; //
        const string registerButtonSelector = ""; //
        const string alreadyCustomerSelector = ""; //

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }
    }
}
