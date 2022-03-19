using JuiceShopAutomation.PageModels.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceShopAutomation.PageModels
{
    class MainPage : BasePage
    {
        const string closeOpenBannerSelector = "//*[@id='mat-dialog-0']/app-welcome-banner/div/div[2]/button[2]"; //xpath
        const string acceptCookiesSelector = "cc-dismiss"; // class
        const string loginButtonSelector = "#navbarAccount > span.mat-button-wrapper > span"; // css
        const string loginButtonExpandedSelector = "#navbarLoginButton > span"; // css
        const string reloadPageSelector = "mat-button-wrapper"; // css

        public MainPage(IWebDriver driver) : base(driver)
        {

        }

        public void CloseOpenBanner()
        {
            driver.FindElement(By.XPath(closeOpenBannerSelector)).Click();
            driver.FindElement(By.ClassName(acceptCookiesSelector)).Click();
            //driver.FindElement(By.ClassName(reloadPageSelector)).Click();
        }

        public void MoveToLoginPage()
        {
            driver.FindElement(By.CssSelector(loginButtonSelector)).Click();
            driver.FindElement(By.CssSelector(loginButtonExpandedSelector)).Click();
        }

    }
}
